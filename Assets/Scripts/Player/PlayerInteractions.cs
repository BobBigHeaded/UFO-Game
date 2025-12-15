using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractions : MonoBehaviour
{
    private float _timerStarted;
    private float _timerEnded;
    [SerializeField] private InputActionReference shootInput;
    private GameObject _projectileSpawnPosition;

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

    private void Start()
    {
        //Finding the position of the weapon so we can find where to spawn a projectile
        _projectileSpawnPosition = GameObject.Find("Player/GunPos");
        //setting the offset for the spawn pos of projectiles
        _projectileSpawnPosition.transform.position += _projectileSpawnPosition.transform.forward * 0.1f;
        _projectileSpawnPosition.transform.position += _projectileSpawnPosition.transform.up * 0.3f;
    }

    private void Attack(InputAction.CallbackContext context)
    {
        var weaponScript = GetComponentInChildren<GunShoot>();
        //ensure the player has a weapon
        if (weaponScript == null) return;
        
        //give position for projectile and Time for the end of the timer
        weaponScript.FireWeapon(_projectileSpawnPosition.transform.position, Time.time);
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
