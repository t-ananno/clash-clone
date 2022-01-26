using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    float movementSpeed = 5;

    // Update is called once per frame
    void Update()
    {
        //get the Input from Horizontal axis
        float xAxisInput = Input.GetAxis("Vertical");
        float zAxisInput = Input.GetAxis("Horizontal");
       

        //update the position
        transform.position = transform.position + new Vector3(xAxisInput * movementSpeed * Time.deltaTime, 0,
                             zAxisInput * movementSpeed * Time.deltaTime);

        
    }
}
