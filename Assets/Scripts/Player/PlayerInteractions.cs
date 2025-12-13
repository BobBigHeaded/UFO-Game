using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractions : MonoBehaviour
{
    private float _timerStarted;
    private float _timerEnded;
    private bool _hasWeapon = true;
    [SerializeField] private InputActionReference shootInput;

    private void OnEnable()
    {
        shootInput.action.performed += Attack;
        shootInput.action.started += StartTimer;
    }

    private void OnDisable()
    {
        shootInput.action.performed -= Attack;
        shootInput.action.started -= StartTimer;
    }

    private void Update()
    {
    }

    private void Attack(InputAction.CallbackContext context)
    {
        if(_hasWeapon)
        {
            EndTimer();       
        }
    }

    private void StartTimer(InputAction.CallbackContext context)
    {
        _timerStarted = Time.time;
        
        Debug.Log(_timerStarted);
    }

    private void EndTimer()
    {
        _timerEnded = Time.time;
        
        Debug.Log(_timerEnded - _timerStarted);
    }
}
