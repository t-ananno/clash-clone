using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
 

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("obs"))
        {
            gameObject.SetActive(false);
            Manager.instance.playerCount--;
        }
    }

   
}
