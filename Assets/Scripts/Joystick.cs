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
    public Vector2 pointerVec;

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
                pointerVec = pointerPos - origin;
                transform.position = pointerPos;
                transform.localPosition = Vector3.ClampMagnitude(transform.localPosition, 100);
            }

        }
        else
        {
            transform.localPosition = Vector2.zero;
            pointerVec = Vector2.zero;
        }
    }
}