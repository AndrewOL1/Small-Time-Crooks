using PurrNet;
using System.Runtime.InteropServices;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : NetworkIdentity
{
    [SerializeField] private Transform CameraTransform;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpHeight = 2f;
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private CinemachineCamera camera;
    [SerializeField] private bool shouldFaceMoveDirection = false;
    [SerializeField] Camera mainCam;

    private CharacterController controller;
    private Vector2 moveInput;
    private Vector3 velocity;
    PlayerInput _playerInput;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controller = GetComponent<CharacterController>();
        _playerInput = GetComponent<PlayerInput>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        Debug.Log($"Move Input: {moveInput}");
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        Debug.Log($"Jumping {context.performed} - Is.Grounded: {controller.isGrounded}");
        if (context.performed && controller.isGrounded)
        {
            Debug.Log("We are supposed to jump");
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);

        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    protected override void OnSpawned()
    {
        base.OnSpawned();
        enabled = isOwner;
        //controller.enabled = isOwner;
        _playerInput = GetComponent<PlayerInput>();
        _playerInput.enabled = isOwner;
        mainCam.enabled = isOwner;
        mainCam.transform.GetComponent<AudioListener>().enabled = isOwner;
        camera.enabled = isOwner;
    }

    private void FixedUpdate()
    {
        Vector3 forward = CameraTransform.forward;
        Vector3 right = CameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        Vector3 moveDirection = forward * moveInput.y + right * moveInput.x;
        controller.Move(moveDirection * speed*Time.deltaTime);

        if (shouldFaceMoveDirection && moveDirection.sqrMagnitude > 0.001f)
        {
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, 10f * Time.deltaTime);
        }

        //Vector3 move = new Vector3(moveInput.x, 0, moveInput.y);
        //controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
