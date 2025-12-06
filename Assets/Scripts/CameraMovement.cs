using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    [Range(5f, 15f)]
    public float rotateSpeed = 5f;
    
    private Vector3 _lookInput = Vector3.zero;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnLook(InputValue value)
    {
        _lookInput = new  Vector3(value.Get<Vector2>().y, value.Get<Vector2>().x, 0);
        _lookInput *= rotateSpeed * Time.deltaTime;
    }
}
