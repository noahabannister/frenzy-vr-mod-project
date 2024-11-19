local tubbyScene = {
 sceneAddress = 'Assets/Example/Tubbies/Scene/Scenes/Tubby Hill.unity',
 spriteAddress = 'Assets/Example/Tubbies/Scene/Art/TubbySceneMenuSprite.png',
 displayName = 'Tubby Hill'
}

sceneTable[tubbyScene.sceneAddress] = tubbyScene

local TinkyWinky = {
 prefabAddress = 'Assets/Example/Tubbies/Enemies/Prefabs/TinkyWinky.prefab',
 displayName = 'Tinky Winky',
 replaceNPCs = {'enemyMale', 'gangMember'} 
}

npcTable[TinkyWinky.prefabAddress] = TinkyWinky

local Dipsy = {
 prefabAddress = 'Assets/Example/Tubbies/Enemies/Prefabs/Dipsy.prefab',
 displayName = 'Dipsy',
 replaceNPCs = {'enemyMale', 'gangMember'} 
}

npcTable[Dipsy.prefabAddress] = Dipsy

local LaLa = {
 prefabAddress = 'Assets/Example/Tubbies/Enemies/Prefabs/LaLa.prefab',
 displayName = 'LaLa',
 replaceNPCs = {'enemyMale', 'gangMember'} 
}

npcTable[LaLa.prefabAddress] = LaLa

local Po = {
 prefabAddress = 'Assets/Example/Tubbies/Enemies/Prefabs/Po.prefab',
 displayName = 'Po',
 replaceNPCs = {'enemyMale', 'gangMember'} 
}

npcTable[Po.prefabAddress] = Po