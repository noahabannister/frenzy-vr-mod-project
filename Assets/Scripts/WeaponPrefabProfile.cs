using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPrefabProfile : MonoBehaviour {

    //General Settings
    [Header("---ESSENTIAL SETTINGS---")]

    public string
        DisplayName;

    [Header("---GENERAL SETTINGS---")]

    public Transform GrabPoint;

    [Tooltip("Unused. Set up art in editor")]
    public string
        ModelAddress;
    [Tooltip("Unused. Set up art in editor")]
    public string
        MaterialAddress,
        AlbedoTextureAddress,
        ImpactMaterialAddress;

    public float
        Weight = 3.0f;

    //Melee Settings
    [Header("---MELEE SETTINGS---")]

    public float
        Melee_Damage;

    //Stabber Settings
    [Header("---STABBER SETTINGS---")]

    public Collider[]
        StabberColliders;

    public bool
        IsStabber,
        Stabber_IsDoubleSided = false;

    public string
        StabberSettingsAddress;

    public float
        Stabber_AngleThreshold = 0.5f,
        Stabber_Sharpness = 0.8f,
        Stabber_UnstabThreshold = 0.01f,
        Stabber_UnstabDelay = 0.25f,
        Stabber_PerpendicularThreshold = 0.2f;

    public int
        Stabber_AllowedStabs = 5;

    //Gun Settings
    [Header("---GUN SETTINGS---")]

    public bool
        IsGun;

    public float
        Gun_Damage = 80f,
        Gun_Force = 20f,
        Gun_BulletSpeed = 80f,
        Gun_Cooldown = 0.12f;

    [Tooltip("0 - single, 1 - burst, 2 - automatic")]
    public int
        Gun_FireType = 2;

    public bool
        Gun_ChambersAfterFiring = true,
        Gun_EjectCasingAfterFiring = false,
        Gun_BoltPushedBackAfterEmpty = false;

    public Transform
        Gun_AmmoSocket,
        Gun_UpRecoil_UpVector,
        Gun_BackRecoil_ForwardVector,
        Gun_BulletOrigin_Barrel,
        Gun_BulletOrigin_IronSights,
        Gun_BulletOrigin_Optic,
        Gun_BulletOrigin_Silencer,
        Gun_CockingGrabPoint,
        Gun_StabilizerGrabPoint;

    public BoxCollider
        Gun_AmmoSocketTrigger,
        Gun_AutoMagDropTrigger,
        Gun_CockingHandleTrigger,
        Gun_MagGrabTrigger,
        Gun_StabilizerGrabTrigger;

    public GameObject
        Gun_CockingHandleMesh,
        Gun_MagMesh;

    //Gun Cocking Component Settings
    [Header("---GUN COCKING SETTINGS---")]
    public Vector3
        Gun_CockingMechanism_ForwardPosition;
    public Vector3
        Gun_CockingMechanism_BackPosition,
        Gun_CockingMechanism_EjectPosition,
        Gun_CockingMechanism_ChamberRoundPosition;

    public float
        Gun_CockingMechanism_ForwardSpeed = 10f,
        Gun_CockingMechanism_Difficulty = 0.05f,
        Gun_CockingMechanism_LockTriggerThreshold = 0.7f,
        Gun_CockingMechanism_LockAccelerationThreshold = 2f;

    public bool
        Gun_CockingMechanism_ImmediateReleaseWhenOpen = false,
        Gun_CockingMechanism_LockBackOverride = true,
        Gun_CockingMechanism_LocksForward = false,
        Gun_CockingMechanism_TriggerUnlocks = false;

    [Tooltip("0 - Reciprocating, 1 - Nonreciprocating, 2 - Pump")]
    public int  Gun_CockingMechanism_Type;


    //Gun Recoil Settings
    [Header("---GUN RECOIL SETTINGS---")]

    public string
        Recoil_SettingsAddress;

    public bool
        Recoil_UseTwoHandRecoilForce = true,
        Recoil_ImpulseForce = true,
        Recoil_RandomSideToSideRecoil = true,
        Recoil_LimitRecoilForce = true,
        Recoil_UseTwoHandMaxUpforce = false,
        Recoil_UseTwoHandMaxSideForce = true;

    public float
        Recoil_UpForce = 8f,
        Recoil_BackwardsForce = 18f,
        Recoil_TwoHandBackwardsForce = 5f,
        Recoil_SideToSideMin = -1f,
        Recoil_SideToSideMax = 1f,
        Recoil_TwoHandSideToSideMin = -0.5f,
        Recoil_TwoHandSideToSideMax = 0.5f,
        Recoil_MaxUpForce = 30f,
        Recoil_MaxBackForce = 0f,
        Recoil_TwoHandMaxUpForce = 0f,
        Recoil_MaxSideForce = 20f,
        Recoil_TwoHandMaxSideForce = 0f,
        Recoil_RecoveryDelay = 0.2f,
        Recoil_TwoHandedRecoveryDelay = 0.2f,
        Recoil_RecoveryTime = 0.1f,
        Recoil_TwoHandedRecoveryTime = 0.05f;

    //Bow Settings
    [Header("---BOW SETTINGS---")]

    public bool
        IsBow;

    public Transform
        ArrowRestLeft,
        ArrowRestRight,
        ArrowNock,
        ForwardMarker;

    public float
        StringDrawLimit = 0.4f,
        StringDropLimit = 0.45f,
        ShootThreshold = 0.2f,
        Speed = 50f,
        StringSpring = 1000f,
        StringHeldSpring = 100f;
}
