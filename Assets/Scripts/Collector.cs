/// <summary>
/// This class describes the functionality of
/// NPC GameObjects.
/// </summary>
///

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{

    [SerializeField]
    private int groupID;
    [SerializeField]
    private bool isPlayer=false;
    [SerializeField]
    int movementSpeed,leftMoveSpeed,rightMoveSpeed;
    [SerializeField]
    float zAxisValue;

    private void Start()
    {

        EventManager.LeftMovementEvent += MoveLeft;
        EventManager.RightMovementEvent += MoveRight;
        EventManager.ForwardMovement += MoveForward;
    }


    private void OnTriggerEnter(Collider other)

    {
       
        if (other.transform.CompareTag("Player"))
        {
            //gameObject.GetComponent<Renderer>().material.SetColor("_Color",Color.yellow);
            int _count = Manager.instance.NPCList.Count;
            for (int i = 0; i < _count; i++)
            {
                GameObject _go = Manager.instance.NPCList[i];

                if (_go.GetComponent<Collector>().groupID==this.groupID)
                {
                    _go.GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);           
                    _go.GetComponent<Collector>().movementSpeed = 1;
                    _go.GetComponent<Collector>().leftMoveSpeed = 1;
                    _go.GetComponent<Collector>().rightMoveSpeed = 1;
                    _go.GetComponent<Collector>().isPlayer = true;
                    _go.tag = "Player";

                }
            }
           
        }

        else if (other.transform.CompareTag("obs"))
        {
            gameObject.SetActive(false);           
        }
    }

    void MoveLeft()
    {
        if (zAxisValue<4f)
        {
            
            transform.position += new Vector3(0, 0, leftMoveSpeed * Time.deltaTime);
        }
        else
        {
            for (int i = 0; i < Manager.instance.NPCList.Count; i++)
            {
                GameObject _go = Manager.instance.NPCList[i];
                if (_go.GetComponent<Collector>().isPlayer==true)
                {
                    _go.GetComponent<Collector>().leftMoveSpeed = 0;
                    _go.GetComponent<Collector>().rightMoveSpeed = 1;
                }
            }

      
        }
       
    }

    void MoveRight()
    {
        if (zAxisValue>-4f)
        {
            transform.position += new Vector3(0, 0, -rightMoveSpeed * Time.deltaTime);
        }
        else
        {
            for (int i = 0; i < Manager.instance.NPCList.Count; i++)
            {
                GameObject _go = Manager.instance.NPCList[i];
                if (_go.GetComponent<Collector>().isPlayer == true)
                {
                    _go.GetComponent<Collector>().leftMoveSpeed =  1;
                    _go.GetComponent<Collector>().rightMoveSpeed = 0;
                }
            }


        }

    }

    void MoveForward()
    {
        zAxisValue = gameObject.transform.position.z;
        transform.position += new Vector3(movementSpeed * Time.deltaTime, 0, 0);
    }


    private void OnDisable()
    {
        EventManager.LeftMovementEvent -= MoveLeft;
        EventManager.RightMovementEvent -= MoveRight;
        EventManager.ForwardMovement -= MoveForward;
    }


}
