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
        var weaponModel = Instantiate(weaponInfo.weaponModel, GameObject.Find("Player/Main Camera/GunPos").transform.position, GameObject.Find("Player/Main Camera").transform.rotation);
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
        
        AudioSource.PlayClipAtPoint(weaponInfo.shotSound, transform.position);
        SpawnProjectile(position);
    }

    private void SpawnProjectile(Vector3 position)
    {
        //spawn the projectile on the given position matching the rotation
        var projectile = Instantiate(weaponInfo.projectilePrefab, position, transform.rotation);
        
        //solution from https://discussions.unity.com/t/shooting-projectiles-towards-the-centre-of-the-camera/676396/7
        //altered to adhere to rider IDE and for my naming conventions
        
        // create a ray from screen centre towards horizon (where we are aiming)
        var screenCentreCoordinates = new Vector3(0.5f, 0.5f, 0f);    
        var ray = GameObject.Find("Main Camera").GetComponent<Camera>().ViewportPointToRay(screenCentreCoordinates);

        // if the raycast collides with an object, then make that our projectile target
        var projectileDestination = Physics.Raycast(ray, out var hit) ? hit.point :
            // if it doesn't hit anything, make our projectile target 1000 away from us (adjust this accordingly)
            ray.GetPoint(1000f);
        projectile.transform.LookAt(projectileDestination);
        
        projectile.GetComponent<Rigidbody>().linearVelocity += (projectile.transform.forward * weaponInfo.GetProjectileSpeed());
    }
}
