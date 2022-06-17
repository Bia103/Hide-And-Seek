using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;             
using UnityEngine.InputSystem.Controls;  

public class PlayerMovementAndroid : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    private PlayerInput playerInput;
    private Transform cameraTransform;
    public float turnSmoothTime = 0.4f;
    float turnSmoothVelocity;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        playerInput = GetComponent<PlayerInput>();
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 input = playerInput.actions["Move"].ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0, input.y);
        move = move.x * cameraTransform.right + move.z * cameraTransform.forward;
        move.y = 0f;
        move = move.normalized;
        controller.Move(move * Time.deltaTime * playerSpeed);

        if(move != Vector3.zero){
            float targetAngle = Mathf.Atan2(move.x, move.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle,  ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f).normalized;
        }
        // Changes the height position of the player..
        if (playerInput.actions["Jump"].triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity.normalized * Time.deltaTime);

    }
}
