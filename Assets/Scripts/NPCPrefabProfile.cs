using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NPCPrefabProfile : MonoBehaviour {

    public string DisplayName;

    public bool DrawBones;

    public bool GetBonesFromAvatar;
    public bool OverwriteAssignedBones;
    public Animator AnimatorComponent;
    public Avatar AnimationHumanoidAvatar;
    public Transform HealthMonitorPosition;

    public NPCBoneProfile_Capsule
        Head,
        UpperArmLeft,
        LowerArmLeft,
        HandLeft,
        UpperLegLeft,
        LowerLegLeft,
        UpperArmRight,
        LowerArmRight,
        HandRight,
        UpperLegRight,
        LowerLegRight;

    public NPCBoneProfile_Box
        Chest,
        Hips,
        FootLeft,
        FootRight;

    public enum BoneDirection { X = 0, Y = 1, Z = 2 }

    private Dictionary<string, string> BoneNames = new Dictionary<string, string>();

    public static void CopyBoneProfileToCapsule(NPCBoneProfile_Capsule profile, CapsuleCollider capsule) {
        profile.Bone.transform.position = capsule.transform.position;
        profile.Bone.transform.rotation = capsule.transform.rotation;
        capsule.direction = (int)profile.Direction;
        capsule.center = profile.Offset;
        capsule.radius = profile.Radius;
        capsule.height = profile.Length;

        ConfigurableJoint joint = capsule.GetComponent<ConfigurableJoint>();
        if (joint) {
            joint.angularXMotion = ConfigurableJointMotion.Free;
            joint.angularYMotion = ConfigurableJointMotion.Free;
            joint.angularZMotion = ConfigurableJointMotion.Free;
            joint.connectedAnchor = profile.Bone.transform.localPosition;
        }

    }

    public static void CopyBoneProfileToBox(NPCBoneProfile_Box profile, BoxCollider box) {
        profile.Bone.transform.position = box.transform.position;
        profile.Bone.transform.rotation = box.transform.rotation;
        box.center = profile.Offset;
        box.size = new Vector3(profile.Width, profile.Height, profile.Length);

        ConfigurableJoint joint = box.GetComponent<ConfigurableJoint>();
        if (joint) {
            joint.angularXMotion = ConfigurableJointMotion.Free;
            joint.angularYMotion = ConfigurableJointMotion.Free;
            joint.angularZMotion = ConfigurableJointMotion.Free;
            joint.connectedAnchor = profile.Bone.transform.localPosition;
        }
    }

    

    [Serializable]
    public struct NPCBoneProfile_Capsule {

        public Transform Bone;
        public Transform NextBone;
        public bool AutoCalculate;
        public bool FlipCalculatedOffset;
        public float Length;
        public float Radius;
        public Vector3 Offset;
        public BoneDirection Direction;

#if UNITY_EDITOR
        public void DrawBoneGizmo() {
            if (Bone == null) return;
            DrawWireCapsule(Bone.position + Bone.TransformVector(Offset), Bone.rotation, Radius, Length, (int)Direction, Color.cyan);
        }
#endif

        public void AutoCalculateBone() {
            if (!AutoCalculate) return;
            if (Bone == null) return;
            if (NextBone == null) return;

            Length = Vector3.Distance(Bone.position, NextBone.position);

            switch ((int)Direction) {
                case 0:
                    Offset = Vector3.right * (0.5f * Length);
                    break;
                case 1:
                    Offset = Vector3.up * (0.5f * Length);
                    break;
                case 2:
                    Offset = Vector3.forward * (0.5f * Length);
                    break;
                default:
                    Offset = Vector3.right * (0.5f * Length);
                    break;
            }

            if (FlipCalculatedOffset) Offset = -Offset;

            if (Radius == 0) Radius = 0.2f * Length;
        }
    }

    [Serializable]
    public struct NPCBoneProfile_Box {

        public Transform Bone;
        public Transform NextBone;
        public bool AutoCalculate;
        public float Length;
        public float Width;
        public float Height;
        public Vector3 Offset;

#if UNITY_EDITOR
        public void DrawBoneGizmo() {
            if (Bone == null) return;
            Matrix4x4 angleMatrix = Matrix4x4.TRS(Bone.position, Bone.rotation, Bone.lossyScale);
            using (new Handles.DrawingScope(angleMatrix)) {
                Handles.color = Color.cyan;
                Handles.DrawWireCube(Offset, new Vector3(Width, Height, Length));
            }
        }
#endif

        public void AutoCalculateBone() {

        }

    }

    private void OnValidate() {

        if (AnimationHumanoidAvatar == null && AnimatorComponent != null) {
            AnimationHumanoidAvatar = AnimatorComponent.avatar;
        }

        if (GetBonesFromAvatar) {
            BonesFromAvatar();
            GetBonesFromAvatar = false;
        }

        Head.AutoCalculateBone();
        UpperArmLeft.AutoCalculateBone();
        LowerArmLeft.AutoCalculateBone();
        HandLeft.AutoCalculateBone();
        UpperLegLeft.AutoCalculateBone();
        LowerLegLeft.AutoCalculateBone();
        UpperArmRight.AutoCalculateBone();
        LowerArmRight.AutoCalculateBone();
        HandRight.AutoCalculateBone();
        UpperLegRight.AutoCalculateBone();
        LowerLegRight.AutoCalculateBone();
    }

    public void BonesFromAvatar() {
        if (AnimationHumanoidAvatar == null) return;

        //Setup dictionary for string lookup
        BoneNames.Clear();
        foreach (HumanBone bone in AnimationHumanoidAvatar.humanDescription.human) {
            BoneNames.Add(bone.humanName, bone.boneName);
        }

        //Map the bones
        //AutoMapBone("Spine", BoneNames["Spine"], ref Chest.Bone);
        AutoMapBone("Chest",            ref Chest.Bone);
        AutoMapBone("Head",             ref Head.Bone);
        AutoMapBone("Hips",             ref Hips.Bone);

        AutoMapBone("LeftFoot",         ref FootLeft.Bone);
        AutoMapBone("LeftHand",         ref HandLeft.Bone);
        AutoMapBone("LeftLowerArm",     ref LowerArmLeft.Bone);
        AutoMapBone("LeftLowerLeg",     ref LowerLegLeft.Bone);
        AutoMapBone("LeftUpperArm",     ref UpperArmLeft.Bone);
        AutoMapBone("LeftUpperLeg",     ref UpperLegLeft.Bone);

        AutoMapBone("RightFoot",        ref FootRight.Bone);
        AutoMapBone("RightHand",        ref HandRight.Bone);
        AutoMapBone("RightLowerArm",    ref LowerArmRight.Bone);
        AutoMapBone("RightLowerLeg",    ref LowerLegRight.Bone);
        AutoMapBone("RightUpperArm",    ref UpperArmRight.Bone);
        AutoMapBone("RightUpperLeg",    ref UpperLegRight.Bone);

        //Map the NextBones for limb chains
        AutoMapBone("LeftFoot",         ref LowerLegLeft.NextBone);
        AutoMapBone("LeftHand",         ref LowerArmLeft.NextBone);
        AutoMapBone("LeftLowerArm",     ref UpperArmLeft.NextBone);
        AutoMapBone("LeftLowerLeg",     ref UpperLegLeft.NextBone);

        AutoMapBone("RightFoot",        ref LowerLegRight.NextBone);
        AutoMapBone("RightHand",        ref LowerArmRight.NextBone);
        AutoMapBone("RightLowerArm",    ref UpperArmRight.NextBone);
        AutoMapBone("RightLowerLeg",    ref UpperLegRight.NextBone);


    }

    public void AutoMapBone(string HumanBoneName, ref Transform BoneReference) {
        if (BoneReference != null && OverwriteAssignedBones == false) {
            Debug.Log($"Bone already assigned for {HumanBoneName}.");
            return;
        }

        if (!BoneNames.ContainsKey(HumanBoneName)) {
            Debug.LogError($"BoneNames dictionary does not contain the key: {HumanBoneName}.");
            return;
        }

        string RigBoneName = BoneNames[HumanBoneName];
        if (RigBoneName == null || RigBoneName == "") {
            Debug.LogError($"BoneNames dictionary contains an empty or null value for the key: {HumanBoneName}.");
            return;
        }

        Transform foundBone = transform.FindChildRecursive(RigBoneName);
        if (foundBone == null) {
            Debug.LogError($"No transform found with the name {RigBoneName} when attempt to map {HumanBoneName} bone.");
            return;
        }

        Debug.Log($"<color=green>Successfully mapped bone {RigBoneName} to {HumanBoneName}</color>");
        BoneReference = foundBone;

    }

#if UNITY_EDITOR
    public static void DrawWireCapsule(Vector3 _pos, Quaternion _rot, float _radius, float _height, int direction = 0, Color _color = default(Color)) {
        if (_color != default(Color))
            Handles.color = _color;

        Matrix4x4 angleMatrix = Matrix4x4.TRS(_pos, _rot, Handles.matrix.lossyScale);
        using (new Handles.DrawingScope(angleMatrix)) {
            var pointOffset = (_height - (_radius * 2)) / 2;

            Vector3 up, down, left, right, forward, back;

            switch (direction) {
                case 0:
                    up = Vector3.right;
                    down = Vector3.left;
                    left = Vector3.down;
                    right = Vector3.up;
                    forward = Vector3.forward;
                    back = Vector3.back;
                    break;
                case 1:
                    up = Vector3.up;
                    down = Vector3.down;
                    left = Vector3.left;
                    right = Vector3.right;
                    forward = Vector3.forward;
                    back = Vector3.back;
                    break;
                case 2:
                    up = Vector3.forward;
                    down = Vector3.back;
                    left = Vector3.left;
                    right = Vector3.right;
                    forward = Vector3.up;
                    back = Vector3.down;
                    break;
                default:
                    up = Vector3.right;
                    down = Vector3.left;
                    left = Vector3.down;
                    right = Vector3.up;
                    forward = Vector3.forward;
                    back = Vector3.back;
                    break;
            }

            //Handles.DrawLine(new Vector3(-_radius, pointOffset, 0), new Vector3(-_radius, -pointOffset, 0));
            //Handles.DrawLine(new Vector3(0, pointOffset, _radius), new Vector3(0, -pointOffset, _radius));
            //Handles.DrawLine(new Vector3(0, pointOffset, -_radius), new Vector3(0, -pointOffset, -_radius));
            //Handles.DrawLine(new Vector3(_radius, pointOffset, 0), new Vector3(_radius, -pointOffset, 0));

            //Draw top cap
            Handles.DrawWireArc(up * pointOffset, left, back, 180, _radius);
            Handles.DrawWireArc(up * pointOffset, back, left, -180, _radius);
            Handles.DrawWireDisc(up * pointOffset, up, _radius);

            //Draw Sides
            Handles.DrawLine((up * pointOffset) + (back * _radius), (down * pointOffset) + (back * _radius));
            Handles.DrawLine((up * pointOffset) + (forward * _radius), (down * pointOffset) + (forward * _radius));
            Handles.DrawLine((up * pointOffset) + (left * _radius), (down * pointOffset) + (left * _radius));
            Handles.DrawLine((up * pointOffset) + (right * _radius), (down * pointOffset) + (right * _radius));

            //Draw bottom cap
            Handles.DrawWireArc(down * pointOffset, back, left, 180, _radius);
            Handles.DrawWireArc(down * pointOffset, left, back, -180, _radius);
            Handles.DrawWireDisc(down * pointOffset, up, _radius);
            //draw center

        }
    }
#endif

}
