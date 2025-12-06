using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Range(0, 15)]
    public float speed;
    [Range(0, 10)]
    public float rotateSpeed;
    
    private Vector3 _movementInput = Vector3.zero;
    private Vector3 _lookInput = Vector3.zero;
    
    private CharacterController _characterController;
    private Camera _camera;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        _characterController.Move( _movementInput * (speed * Time.deltaTime));

        transform.Rotate(Vector3.up * _lookInput.y);
    }

    void OnMove(InputValue value)
    {
        _movementInput = new  Vector3(value.Get<Vector2>().x, -9.81f, value.Get<Vector2>().y);
    }

    void OnLook(InputValue value)
    {
        _lookInput = new  Vector3(value.Get<Vector2>().y, value.Get<Vector2>().x, 0);
        _lookInput *= rotateSpeed * Time.deltaTime;
    }

    void OnJump()
    {
        
    }
}
