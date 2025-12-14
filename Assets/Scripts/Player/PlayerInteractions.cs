using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractions : MonoBehaviour
{
    private float _timerStarted;
    private float _timerEnded;
    [SerializeField] private InputActionReference shootInput;

    private void OnEnable()
    {
        //setting what functions are linked to what input context
        shootInput.action.performed += Attack;
        shootInput.action.started += StartTimer;
    }

    private void OnDisable()
    {
        //unsetting
        shootInput.action.performed -= Attack;
        shootInput.action.started -= StartTimer;
    }

    private void Attack(InputAction.CallbackContext context)
    {
        var weaponScript = GetComponentInChildren<GunShoot>();
        //ensure the player has a weapon
        if (weaponScript == null) return;
        
        //give position for projectile and Time for the end of the timer
        weaponScript.FireWeapon(transform.position, Time.time);
    }

    private void StartTimer(InputAction.CallbackContext context)
    {
        var weaponScript = GetComponentInChildren<GunShoot>();
        //ensure the player has a weapon
        if (weaponScript == null) return;
        
        //starts the timer when te player starts holding the button
        //this is used to find the power of the slingshot and for hold weapons
        _timerStarted = Time.time;
        
        weaponScript.HoldTime(_timerStarted);
    }
}
