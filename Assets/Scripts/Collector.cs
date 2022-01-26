using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField]
    private int groupID;
    [SerializeField]
    private bool isPlayer=false;


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
                }
            }
            
        }
    }
}
