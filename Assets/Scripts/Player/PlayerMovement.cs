using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Range(0, 15)]
    public float speed;
    [Range(8, 30)]
    public float sensitivity;
    [Range(-20f, -10f)]
    public float gravityForce = -5;
    [Range(0, 5)]
    public float jumpForce = 1;
    
    //for movement
    private float _moveX;
    private float _moveZ;
    //for Camera Movement
    private float _currentYRotation = 0f;
    private Vector3 _lookInput = Vector3.zero;
    //for jumping
    private float _currentYVelocity = 0f;
    
    private CharacterController _characterController;
    private Transform _cameraTransform;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        _cameraTransform = transform.Find("Main Camera");
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Move the player
        var movementInput = new Vector3(0, _currentYVelocity, 0);
        //gets input an ensure direction is taken into account
        movementInput += (transform.forward * _moveZ) + (transform.right * _moveX);
        _characterController.Move(movementInput * Time.deltaTime);

        //Camera Movement
        
        //Camera vertical rotation
        _currentYRotation -= _lookInput.x;
        //ensure value is within acceptable range
        _currentYRotation = Mathf.Clamp(_currentYRotation, -90f, 90f);
        //Set the rotation
        _cameraTransform.localRotation = Quaternion.Euler(_currentYRotation, 0f, 0f);
        
        //rotates along the horizontal axis
        transform.Rotate(Vector3.up * _lookInput.y);

        if (_currentYVelocity < -2f && _characterController.isGrounded)
        {
            _currentYVelocity = -2f;
        }
        
        //apply gravity
        _currentYVelocity += gravityForce * Time.deltaTime;
    }

    void OnMove(InputValue value)
    {
        _moveX = value.Get<Vector2>().x * speed;
        _moveZ = value.Get<Vector2>().y * speed;
    }

    void OnLook(InputValue value)
    {
        _lookInput = new  Vector3(value.Get<Vector2>().y, value.Get<Vector2>().x, 0);
        _lookInput *= sensitivity * Time.deltaTime;
    }

    void OnJump()
    {
        if (_characterController.isGrounded)
        {
            _currentYVelocity = Mathf.Sqrt(jumpForce * -2f * gravityForce);
        }
    }
}
