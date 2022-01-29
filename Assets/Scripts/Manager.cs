using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public static Manager instance;

    public List<GameObject> NPCList;
    public GameObject NPCHolder, menuUI;
    public int playerCount;
    
 


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
        playerCount = 1;
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

    private void Update()
    {
        

        if (playerCount==0)
        {
            playerCount = -1;
            OpenMenuUI();
        }
        
    }

    void OpenMenuUI()
    {
        menuUI.SetActive(true);
    }

  
}
