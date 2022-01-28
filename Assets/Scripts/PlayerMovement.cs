using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float movementSpeed = 1,leftMoveSpeed=1,rightMoveSpeed=1;

    private float zAxis;

    private void Start()
    {
        EventManager.LeftMovementEvent += MoveLeft;
        EventManager.RightMovementEvent += MoveRight;
        EventManager.ForwardMovement += MoveForward;
    }

 

    void MoveLeft()
    {
        if (zAxis<4)
        {
            leftMoveSpeed = 1;
            transform.position += new Vector3(0, 0, leftMoveSpeed * Time.deltaTime);
        }
        else
        {
            leftMoveSpeed = 0;
            rightMoveSpeed = 1;
        }
       
    }

    void MoveRight()
    {
        if (zAxis > -4)
        {
            rightMoveSpeed = 1;
            transform.position += new Vector3(0, 0, -rightMoveSpeed * Time.deltaTime);
        }
        else
        {
            leftMoveSpeed = 1;
            rightMoveSpeed = 0;
        }



        
    }

    void MoveForward()
    {
        zAxis = gameObject.transform.position.z;
        transform.position += new Vector3(movementSpeed * Time.deltaTime, 0, 0);
    }

  

    private void OnDisable()
    {
        EventManager.LeftMovementEvent -= MoveLeft;
        EventManager.RightMovementEvent -= MoveRight;
        EventManager.ForwardMovement -= MoveForward;
    }
}
