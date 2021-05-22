using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Joystick joystick;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (joystick.statusDown)
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(joystick.pointerVec.x, 0, joystick.pointerVec.y) * 0.1f;
        }
    }
}
