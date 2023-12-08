using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPrefabProfile : MonoBehaviour {

    //General Settings
    //[Header("---GENERAL SETTINGS---")]

    public string
        UniqueName,
        PrefabAddress,
        ModelAddress,
        MaterialAddress,
        AlbedoTextureAddress,
        ImpactMaterialAddress;

    public float
        Weight;

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
        Stabber_IsDoubleSided;

    public string
        StabberSettingsAddress;

    public float
        Stabber_AngleThreshold,
        Stabber_Sharpness,
        Stabber_UnstabThreshold,
        Stabber_UnstabDelay,
        Stabber_PerpendicularThreshold;

    public int
        Stabber_AllowedStabs;

    //Gun Settings
    [Header("---GUN SETTINGS---")]

    public bool
        IsGun;

    public float
        Gun_Damage,
        Gun_Force,
        Gun_BulletSpeed,
        Gun_Cooldown;

    public int
        Gun_FireType;

    public bool
        Gun_ChambersAfterFiring,
        Gun_EjectCasingAfterFiring,
        Gun_BoltPushedBackAfterEmpty;

    public Transform
        Gun_AmmoSocket,
        Gun_UpRecoil_UpVector,
        Gun_BackRecoil_ForwardVector,
        Gun_BulletOrigin_Barrel, 
        Gun_BulletOrigin_IronSights,
        Gun_BulletOrigin_Optic,
        Gun_BulletOrigin_Silencer;

    public Collider
        Gun_AmmoSocketTrigger,
        Gun_AutoMagDropTrigger,
        Gun_CockingHandleTrigger,
        Gun_MagGrabTrigger,
        Gun_StabilizerGrabTrigger;


    //Gun Recoil Settings
    [Header("---GUN RECOIL SETTINGS---")]
    
    public string
        Recoil_SettingsAddress;

    public bool
        Recoil_UseTwoHandRecoilForce,
        Recoil_ImpulseForce,
        Recoil_RandomSideToSideRecoil,
        Recoil_LimitRecoilForce,
        Recoil_UseTwoHandMaxUpforce,
        Recoil_UseTwoHandMaxSideForce;

    public float
        Recoil_UpForce,
        Recoil_BackwardsForce,
        Recoil_TwoHandBackwardsForce,
        Recoil_SideToSideMin,
        Recoil_SideToSideMax,
        Recoil_TwoHandSideToSideMin,
        Recoil_TwoHandSideToSideMax,
        Recoil_MaxUpForce,
        Recoil_MaxBackForce,
        Recoil_TwoHandMaxUpForce,
        Recoil_MaxSideForce,
        Recoil_TwoHandMaxSideForce,
        Recoil_RecoveryDelay,
        Recoil_TwoHandedRecoveryDelay,
        Recoil_RecoveryTime,
        Recoil_TwoHandedRecoveryTime;

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
        StringDrawLimit,
        StringDropLimit,
        ShootThreshold,
        Speed,
        StringSpring,
        StringHeldSpring;
}
