using UnityEngine;

public abstract class WeaponBase : ScriptableObject
{
    public GameObject weaponModel;
    public GameObject projectilePrefab;
    
    public float projectileSpeed;

    public abstract bool Shoot();
}
