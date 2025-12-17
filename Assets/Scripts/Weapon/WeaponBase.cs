using UnityEngine;

public abstract class WeaponBase : ScriptableObject
{
    public GameObject weaponModel;
    public GameObject projectilePrefab;
    public AudioClip shotSound;
    
    public float projectileSpeed;
    
    //condition specific to type of gun
    public abstract bool CanShoot(float timeStarted, float timeEnded);
    //for any math required for any projectile speeds
    public abstract float GetProjectileSpeed();
}
