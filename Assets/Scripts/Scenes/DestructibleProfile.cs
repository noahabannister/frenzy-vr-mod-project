using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructibleProfile : MonoBehaviour {
    public string DestroyedObjectPrefabAddress;
    public string DestructionAudioClipAddress;
    public float Health = 5f;

    public enum DestructableMaterial { wood, metal, plastic, glass, stone}
    public DestructableMaterial FallbackDestructionAudioClip = DestructableMaterial.wood;
}
