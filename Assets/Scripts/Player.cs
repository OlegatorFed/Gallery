using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Transform playerCamera;

    public Joystick joystick;
    public Joystick cameraJoystick;

    float moveSpeed = 0.5f;
    float gravity = -13.0f;

    float velocityY = 0.0f;

    CharacterController characterController;

    float cameraPitch = 0.0f;
    // Start is called before the first frame update
    void Awake()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateMove();

        UpdateLook();
    }

    void UpdateLook()
    {
        if (cameraJoystick.statusDown)
        {
            transform.Rotate(Vector3.up, cameraJoystick.offset.x * 0.01f);



            cameraPitch -= cameraJoystick.offset.y * 0.01f;

            cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);

            playerCamera.localEulerAngles = Vector3.right * cameraPitch;
        }
        
    }

    void UpdateMove()
    {

        if (characterController.isGrounded)
            velocityY = 0.0f;
        velocityY += gravity * Time.deltaTime;

        Vector3 velocity = (transform.forward * joystick.offset.y + transform.right * joystick.offset.x) * moveSpeed + Vector3.up * velocityY;

        characterController.Move(velocity * Time.deltaTime);
        
    }
}
