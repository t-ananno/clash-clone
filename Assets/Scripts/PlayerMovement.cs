using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float movementSpeed = 1;

    private void Start()
    {
        EventManager.LeftMovementEvent += MoveLeft;
        EventManager.RightMovementEvent += MoveRight;
        EventManager.ForwardMovement += MoveForward;
    }

 

    void MoveLeft()
    {
        transform.position += new Vector3(0, 0, movementSpeed * Time.deltaTime);
    }

    void MoveRight()
    {
        transform.position += new Vector3(0, 0, -movementSpeed * Time.deltaTime);
    }

    void MoveForward()
    {
        transform.position += new Vector3(movementSpeed * Time.deltaTime, 0, 0);
    }

    private void OnDisable()
    {
        EventManager.LeftMovementEvent -= MoveLeft;
        EventManager.RightMovementEvent -= MoveRight;
        EventManager.ForwardMovement -= MoveForward;
    }
}
