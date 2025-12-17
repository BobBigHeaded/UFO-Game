using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
        _projectileSpawnPosition = GameObject.Find("Player/Main Camera/GunPos");
    }

    private void Attack(InputAction.CallbackContext context)
    {
        var weaponScript = GetComponentInChildren<GunShoot>();
        //ensure the player has a weapon
        if (weaponScript == null) return;
        
        //setting the offset for the spawn pos of projectiles
        var newPos = (_projectileSpawnPosition.transform.forward * 0.1f) + (_projectileSpawnPosition.transform.up * 0.3f);
        newPos += _projectileSpawnPosition.transform.position;
        //give position for projectile and Time for the end of the timer
        weaponScript.FireWeapon((newPos), Time.time);
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

    private void OnEscape()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0) return;
        SceneManager.LoadScene(0);
    }
}
