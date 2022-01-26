using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static Manager instance;

    public List<GameObject> NPCList;
    public GameObject NPCHolder;

    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        AssignNPCList();
    }

    void AssignNPCList()
    {
        if (NPCList!=null)
        {
            NPCList.Clear();
        }

        for (int i = 0; i < NPCHolder.transform.childCount; i++)
        {
            NPCList.Add(NPCHolder.transform.GetChild(i).gameObject);
        }
       
        
    }


}
