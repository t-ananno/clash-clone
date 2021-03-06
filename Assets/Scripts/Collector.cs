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
    [SerializeField]
    private Animator npcWalkAnimator;
    [SerializeField]
    private ParticleSystem destroyEffect;
    [SerializeField]
    private GameObject NPCHolder;
    

    private int walkAnimHash,NPCHolderCount;

    bool _isLeftChanged = false, _isRightChaged=false;
    private void Start()
    {

        EventManager.LeftMovementEvent += MoveLeft;
        EventManager.RightMovementEvent += MoveRight;
        EventManager.ForwardMovement += MoveForward;
        walkAnimHash = Animator.StringToHash("isWalking");
        NPCHolderCount = NPCHolder.transform.childCount;


    }


    private void OnTriggerEnter(Collider other)

    {
        int _playerCount = 0;

        if (other.transform.CompareTag("Player"))
        {
      

            for (int i = 0; i < NPCHolderCount; i++)
            {         
                GameObject _go = NPCHolder.transform.GetChild(i).gameObject;

                if (_go.GetComponent<Collector>().groupID == this.groupID)
                {
                    _go.transform.GetChild(0).GetComponent<Renderer>().material.SetColor("_Color", Color.yellow);
                    _go.GetComponent<Collector>().npcWalkAnimator.SetBool(walkAnimHash, true);
                    _go.GetComponent<Collector>().movementSpeed = 1;
                    _go.GetComponent<Collector>().leftMoveSpeed = 1;
                    _go.GetComponent<Collector>().rightMoveSpeed = 1;
                    _go.GetComponent<Collector>().isPlayer = true;
                    _go.tag = "Player";
                    _playerCount++;

                 
                }
            }

        }

        else if (other.transform.CompareTag("obs"))
        {

            gameObject.SetActive(false);
            _playerCount--;

        }

        else if (other.transform.CompareTag("enemy"))
        {
            EventManager.LeftMovementEvent -= MoveLeft;
            EventManager.RightMovementEvent -= MoveRight;
            EventManager.ForwardMovement -= MoveForward;
            _playerCount--;        
        }

        Manager.instance.playerCount += _playerCount;

       

        
    }

    void MoveLeft()
    {
       
        if (zAxisValue<4f)
        {
            
            transform.position += new Vector3(0, 0, leftMoveSpeed * Time.deltaTime);

            if (_isLeftChanged==true)
            {
                _isLeftChanged = false;
                for (int i = 0; i < NPCHolderCount; i++)
                {
                    GameObject _go = NPCHolder.transform.GetChild(i).gameObject;
                    if (_go.GetComponent<Collector>().isPlayer == true)
                    {
                        _go.GetComponent<Collector>().leftMoveSpeed = 1;
                       
                    }

                }
            }

        }
        else
        {
            _isLeftChanged = true;
            for (int i = 0; i < NPCHolderCount; i++)
            {                
                GameObject _go = NPCHolder.transform.GetChild(i).gameObject;
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
            if (_isRightChaged==true)
            {
                _isRightChaged = false;
                for (int i = 0; i < NPCHolderCount; i++)
                {
                    GameObject _go = NPCHolder.transform.GetChild(i).gameObject;
                    if (_go.GetComponent<Collector>().isPlayer == true)
                    {                        
                        _go.GetComponent<Collector>().rightMoveSpeed = 1;
                    }
                }


            }
        }
        else
        {
            _isRightChaged = true;
            for (int i = 0; i < NPCHolderCount; i++)
            {
                
                GameObject _go = NPCHolder.transform.GetChild(i).gameObject;
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
