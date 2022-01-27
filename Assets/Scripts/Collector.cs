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
    int movementSpeed=0;

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
                    _go.tag = "Player";

                }
            }
            
        }
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
