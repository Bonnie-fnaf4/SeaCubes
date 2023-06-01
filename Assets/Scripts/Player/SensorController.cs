using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SensorController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    public Vector3 origin, direction, directionOld;

    public bool isMove;

    public PlayerController2 playerController2;
    public void OnPointerDown(PointerEventData eventData)
    {
        origin = eventData.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 currentPosition = eventData.position;
        Vector3 directionRaw = currentPosition - origin;
        direction = directionRaw + directionOld;

        if(direction.x <= -50 && !isMove)
        {
            playerController2.LeftMove();
            isMove = true;
        }

        if (direction.x >= 50 && !isMove)
        {
            playerController2.RightMove();
            isMove = true;
        }

        if (direction.y >= 50 && !isMove)
        {
            playerController2.JumpMove();
            isMove = true;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isMove = false;
    }
}
