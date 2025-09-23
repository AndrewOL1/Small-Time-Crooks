using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    public float moveSpeed;
    private Vector3 _moveDirection;
    //private PlayerControls playerControls;
    public InputActionReference move;
    public InputActionReference fire;
    public InputActionReference jump;
    public float jumpForce;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //playerControls = new PlayerControls();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _moveDirection = move.action.ReadValue<Vector3>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(_moveDirection.x * moveSpeed, _moveDirection.y * moveSpeed, _moveDirection.z * moveSpeed);
    }

    private void OnEnable()
    {
        fire.action.started += Fire;
    }

    private void OnDisable()
    {
        fire.action.started -= Fire;
    }

    private void Fire(InputAction.CallbackContext obj)
    {
        Debug.Log("Fired");
    }

    private void OnJump()
    {
        Debug.Log("Jump");
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

}
