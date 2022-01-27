using System;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action LeftMovementEvent, RightMovementEvent,ForwardMovement;

    private void Awake()
    {
        if (LeftMovementEvent != null) 
        {
            LeftMovementEvent();
        }
        if (RightMovementEvent != null)
        {
            LeftMovementEvent();
        }
        if (ForwardMovement != null)
        {
            ForwardMovement();
        }
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            LeftMovementEvent();
        }

        if (Input.GetKey(KeyCode.D))
        {
            RightMovementEvent();
        }

        ForwardMovement();


    }
}
 