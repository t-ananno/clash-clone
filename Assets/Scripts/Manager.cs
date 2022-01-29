using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{
    public static Manager instance=null;

   
    public int playerCount;
    public bool isDestination=false;
    
 


    private void Awake()
    {
        if (instance==null)
        {
            instance = this;
           

         
        }
        else if (instance!=this)
        {
            DestroyImmediate(gameObject);
            return;  
        }

        DontDestroyOnLoad(gameObject);

  

    }





 

  

  
}
