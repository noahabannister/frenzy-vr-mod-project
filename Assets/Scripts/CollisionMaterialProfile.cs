using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionMaterialProfile : MonoBehaviour
{
    public enum ImpactMaterial {Fists, Soft, Wood, Metal, Bullet, Concrete};
    
    public ImpactMaterial CollisionMaterial;
}
