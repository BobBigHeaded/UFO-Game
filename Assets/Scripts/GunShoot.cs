using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public float bulletSpeed = 20f;
    
    public GameObject bulletPrefab;
    
    public void Shoot(Vector3 position)
    {
        var bullet = Instantiate(bulletPrefab, position, transform.rotation);
        bullet.GetComponent<Rigidbody>().linearVelocity += (bullet.transform.forward * bulletSpeed);
    }
}
