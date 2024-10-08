using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ControllerEvents : MonoBehaviour {

    static List<ControllerEvents> 
        Instances = new List<ControllerEvents>();

    static List<InputDevice> 
        LeftHandedControllers = new List<InputDevice>(),
        RightHandedControllers = new List<InputDevice>();

    static bool
        LeftTriggerIsDown,
        LeftGripIsDown,
        LeftPrimaryIsDown,
        LeftSecondaryIsDown,
        LeftStickIsDown,        
        RightTriggerIsDown,
        RightGripIsDown,
        RightPrimaryIsDown,
        RightSecondaryIsDown,
        RightStickIsDown;

    static int
        LastButtonUpdate = 0,
        LastControllerUpdate = 0;

    public UnityEvent 
        OnTriggerPressed,
        OnTriggerReleased,
        OnGripPressed,
        OnGripReleased,
        OnPrimaryButtonPressed,
        OnPrimaryButtonReleased,
        OnSecondaryButtonPressed,
        OnSecondaryButtonReleased,
        OnStickPressed,
        OnStickReleased;

    private static void UpdateButtonStates() {
        if (LeftHandedControllers.Count > 0) { 
            InputDevice lhc = LeftHandedControllers[0];
            bool pressed;
            lhc.IsPressed(InputHelpers.Button.TriggerButton, out pressed);
            if (pressed != LeftTriggerIsDown) {
                foreach (ControllerEvents c_event in Instances)
                    c_event.OnTriggerPressed?.Invoke();
                LeftTriggerIsDown = pressed; 
            }

            lhc.IsPressed(InputHelpers.Button.GripButton, out pressed);
            if (pressed != LeftGripIsDown) {
                foreach (ControllerEvents c_event in Instances)
                    c_event.OnGripPressed?.Invoke();
                LeftGripIsDown = pressed;
            }

            lhc.IsPressed(InputHelpers.Button.PrimaryButton, out pressed);
            if (pressed != LeftPrimaryIsDown) {
                foreach (ControllerEvents c_event in Instances)
                    c_event.OnPrimaryButtonPressed?.Invoke();
                LeftPrimaryIsDown = pressed;
            }

            lhc.IsPressed(InputHelpers.Button.SecondaryButton, out pressed);
            if (pressed != LeftSecondaryIsDown) {
                foreach (ControllerEvents c_event in Instances)
                    c_event.OnSecondaryButtonPressed?.Invoke();
                LeftSecondaryIsDown = pressed;
            }

            lhc.IsPressed(InputHelpers.Button.Primary2DAxisClick, out pressed);
            if (pressed != LeftStickIsDown) {
                foreach (ControllerEvents c_event in Instances)
                    c_event.OnStickPressed?.Invoke();
                LeftStickIsDown = pressed;
            }
        }

        if (RightHandedControllers.Count > 0) {
            InputDevice rhc = RightHandedControllers[0];
            bool pressed;

            rhc.IsPressed(InputHelpers.Button.TriggerButton, out pressed);
            if (pressed != RightTriggerIsDown) {
                foreach (ControllerEvents c_event in Instances)
                    c_event.OnTriggerPressed?.Invoke();
                RightTriggerIsDown = pressed;
            }

            rhc.IsPressed(InputHelpers.Button.GripButton, out pressed);
            if (pressed != RightGripIsDown) {
                foreach (ControllerEvents c_event in Instances)
                    c_event.OnGripPressed?.Invoke();
                RightGripIsDown = pressed;
            }

            rhc.IsPressed(InputHelpers.Button.PrimaryButton, out pressed);
            if (pressed != RightPrimaryIsDown) {
                foreach (ControllerEvents c_event in Instances)
                    c_event.OnPrimaryButtonPressed?.Invoke();
                RightPrimaryIsDown = pressed;
            }

            rhc.IsPressed(InputHelpers.Button.SecondaryButton, out pressed);
            if (pressed != RightSecondaryIsDown) {
                foreach (ControllerEvents c_event in Instances)
                    c_event.OnSecondaryButtonPressed?.Invoke();
                RightSecondaryIsDown = pressed;
            }

            rhc.IsPressed(InputHelpers.Button.Primary2DAxisClick, out pressed);
            if (pressed != RightStickIsDown) {
                foreach (ControllerEvents c_event in Instances)
                    c_event.OnStickPressed?.Invoke();
                RightStickIsDown = pressed;
            }
        }

        LastButtonUpdate = Time.frameCount;
    }
    
    private static void UpdateControllerList() {
        InputDeviceCharacteristics lhcCharacteristics = InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Left | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(lhcCharacteristics, LeftHandedControllers);

        foreach (InputDevice device in LeftHandedControllers) {
            Debug.Log(string.Format("Device name '{0}' has characteristics '{1}'", device.name, device.characteristics.ToString()));
        }

        InputDeviceCharacteristics rhcCharacteristics = InputDeviceCharacteristics.HeldInHand | InputDeviceCharacteristics.Right | InputDeviceCharacteristics.Controller;
        InputDevices.GetDevicesWithCharacteristics(rhcCharacteristics, RightHandedControllers);

        foreach (InputDevice device in RightHandedControllers) {
            Debug.Log(string.Format("Device name '{0}' has characteristics '{1}'", device.name, device.characteristics.ToString()));
        }

        LastControllerUpdate = Time.frameCount;
    }

    private void TryStateUpdate() {
        if (Time.frameCount > LastControllerUpdate + 600) {
            UpdateControllerList();            
        }
        if (Time.frameCount > LastButtonUpdate) {
            UpdateButtonStates();            
        }
    }

    private void OnEnable() {
        Instances.Add(this);
    }
    private void OnDisable() {
        Instances.Remove(this);
    }

    private void Start() {
        TryStateUpdate();
    }

    private void Update() {
        TryStateUpdate();
    }
}
