using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Transform playerCamera;

    public Joystick joystick;
    public Joystick cameraJoystick;

    float cameraPitch = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (joystick.statusDown)
        {
            this.GetComponent<Rigidbody>().velocity = Vector3.ClampMagnitude(new Vector3(joystick.offset.x, 0, joystick.offset.y), 20);
            //Debug.Log(this.GetComponent<Rigidbody>().velocity);
        }

        UpdateLook();
    }

    void UpdateLook()
    {
        if (cameraJoystick.statusDown)
        {
            playerCamera.Rotate(Vector3.up, cameraJoystick.offset.x * 0.01f);

            

            cameraPitch -= cameraJoystick.offset.y * 0.01f;

            cameraPitch = Mathf.Clamp(cameraPitch, -90.0f, 90.0f);

            playerCamera.localEulerAngles = Vector3.right * cameraPitch;
        }
    }
}
