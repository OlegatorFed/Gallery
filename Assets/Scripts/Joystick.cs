using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler
{
    [HideInInspector]
    public bool statusDown = false;

    public Vector2 TouchDist;
    int pointerId;
    Vector2 pointerPos;

    Vector2 origin;

    [HideInInspector]
    public Vector2 offset;

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Rabotaet");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        statusDown = true;
        pointerId = eventData.pointerId;
        pointerPos = eventData.position;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        statusDown = false;
    }

    void Awake()
    {
        origin = transform.position;

        Debug.Log(origin);
    }

    // Update is called once per frame
    void Update()
    {
        JoyStickPosUpdate();
    }

    void JoyStickPosUpdate()
    {
        if (statusDown)
        {
            if (pointerId >= 0 && pointerId < Input.touches.Length)
            {
                TouchDist = Input.touches[pointerId].position - pointerPos;
                pointerPos = Input.touches[pointerId].position;
            }
            else
            {
                pointerPos = Input.mousePosition;
                transform.position = pointerPos;

                offset = transform.position;
                offset -= origin;
                offset = Vector2.ClampMagnitude(offset, 50);
                transform.position = origin + Vector2.ClampMagnitude(offset, 50);
                
            }

        }
        else
        {
            transform.position = origin;
            offset = Vector3.zero;
        }
        Debug.Log(offset);
    }
}