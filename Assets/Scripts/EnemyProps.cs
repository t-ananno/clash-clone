using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProps : MonoBehaviour
{
    [SerializeField]
    private bool isPlayerFound=false;

    private Collider col;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player") && isPlayerFound!=true)
        {
            col = gameObject.GetComponent<Collider>();
            col.enabled = false;
            isPlayerFound = true;
            print("player found");
        }
    }
}
