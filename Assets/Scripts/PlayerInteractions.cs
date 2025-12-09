using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractions : MonoBehaviour
{
    private bool _hasWeapon = true;
    
    void OnAttack()
    {
        if(_hasWeapon)
        {
            GetComponentInChildren<GunShoot>().Shoot(transform.position + (transform.forward * 1.3f) + (transform.right * 1.2f));
        }
    }
}
