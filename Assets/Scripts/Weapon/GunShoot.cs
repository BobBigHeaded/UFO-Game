using System;
using UnityEngine;

public class GunShoot : MonoBehaviour
{ 
    [SerializeField] private WeaponBase weaponInfo;
    private Vector3 _projectileSpawn;
    
    private float _timerStarted = 0f;

    public void Start()
    {
        //place the gun model in the correct position on the player
        var weaponModel = Instantiate(weaponInfo.weaponModel, GameObject.Find("Player/GunPos").transform.position, GameObject.Find("Player/Main Camera").transform.rotation);
        weaponModel.transform.parent = GameObject.Find("Weapon/GFX").transform;
    }

    public void HoldTime(float startTime)
    {
        _timerStarted = startTime;
    }
    
    public void FireWeapon(Vector3 position, float endTime)
    {
        //check if the condition of the weapon is met
        if (!weaponInfo.CanShoot(_timerStarted, endTime)) return;
        
        SpawnProjectile(position);
    }

    private void SpawnProjectile(Vector3 position)
    {
        //spawn the projectile on the given position matching the rotation
        var projectile = Instantiate(weaponInfo.projectilePrefab, position, transform.rotation);
        projectile.GetComponent<Rigidbody>().linearVelocity += (projectile.transform.forward * weaponInfo.GetProjectileSpeed());
    }
}
