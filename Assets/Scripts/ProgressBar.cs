using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressBar : MonoBehaviour
{
    [SerializeField]
    private Image barImage;
    [SerializeField]
    private float val,initialDistance;
    [SerializeField]
    private GameObject currentPos, endPos, startPos;

    private void Start()
    {
        Vector3 player_current_position_without_y = new Vector3(currentPos.transform.position.x, 0, currentPos.transform.position.z);
        Vector3 end_point_without_y = new Vector3(endPos.transform.position.x, 0, endPos.transform.position.z);
        initialDistance = Vector3.Dot(Vector3.one, end_point_without_y - player_current_position_without_y);


    }
        private void Update()
        {
            Vector3 player_current_position_without_y = new Vector3(currentPos.transform.position.x, 0, currentPos.transform.position.z);
            Vector3 end_point_without_y = new Vector3(endPos.transform.position.x, 0, endPos.transform.position.z);
            float distanceLeft = Vector3.Dot(Vector3.one, end_point_without_y - player_current_position_without_y);
            float progress = 1 - (distanceLeft / initialDistance);
            if (progress < 0)
            {
                progress = 0;
            }
            else if (progress > 1)
            {
                Manager.instance.isDestination = true;
                progress = 1;
            }

            barImage.fillAmount = progress;
          
        }


    
    }
