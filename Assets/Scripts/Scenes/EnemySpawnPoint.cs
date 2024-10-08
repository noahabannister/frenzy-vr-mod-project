using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnPoint : MonoBehaviour {

    [Tooltip("Use the prefab address for the enemy you want to spawn here. Works with modded content. Addresses can be found in the 'data' lua scripts of other mods.")]
    public string PriorityEnemyPrefabAddress;

    [Tooltip("If Priority Enemy ID is left blank or cannot find a matching enemy, the game will spawn this built-in enemy here.")]
    public BuiltInEnemyID FallbackEnemy = BuiltInEnemyID.gangMember;

    public enum BuiltInEnemyID {
        beefBaby,
        boatStaff,
        factoryStaff,
        gangLeader,
        gangMember,
        labGuard,
        policeOfficer,
        zombie
    }

    [Tooltip("Enemy mods allow for enemys to be automatically replaced. Disable this option to force this enemy to be the one configured here.")]
    public bool AllowReplacements;

}
