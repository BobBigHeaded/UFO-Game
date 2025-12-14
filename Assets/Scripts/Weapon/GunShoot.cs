using UnityEngine;

public class GunShoot : MonoBehaviour
{ 
    [SerializeField] private WeaponBase weaponInfo;
    
    private float _timerStarted = 0f;
    
    public void HoldTime(float startTime)
    {
        _timerStarted = startTime;
    }
    
    public void FireWeapon(Vector3 position, float endTime)
    {
        if (!weaponInfo.CanShoot(_timerStarted, endTime)) return;
        
        SpawnProjectile(position);
    }

    public void SpawnProjectile(Vector3 position)
    {
        var projectile = Instantiate(weaponInfo.projectilePrefab, position, transform.rotation);
        projectile.GetComponent<Rigidbody>().linearVelocity += (projectile.transform.forward * weaponInfo.GetProjectileSpeed());
    }
}
