using UnityEngine;
using UnityEngine.Serialization;

public class GunShoot : MonoBehaviour
{ 
    [SerializeField] private WeaponBase weaponInfo;
    
    public void FireWeapon(Vector3 position)
    {
        weaponInfo.Shoot();
    }

    public void SpawnProjectile(Vector3 position)
    {
        var projectile = Instantiate(weaponInfo.projectilePrefab, position, transform.rotation);
        projectile.GetComponent<Rigidbody>().linearVelocity += (projectile.transform.forward * weaponInfo.projectileSpeed);
    }
}
