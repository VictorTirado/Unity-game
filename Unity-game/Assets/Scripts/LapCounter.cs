using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapCounter : MonoBehaviour
{
    public GameObject lapsCount;
    public GameObject cameratoRotate;
    public GameObject cameratoStop;
    private bool on = false;

    public int lapsDown;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "start_collider")
        {
            Debug.Log("IS TRUE");
            on = true;
        }
        if (other.name == "finish_collider")
        {
            
            if (Time.time > 10f && on == false)
            {
                Debug.Log("IS FALSE");
                Debug.Log("HIIIIIIIIIIIIIIIII");
                lapsDown += 1;
                
            }
            lapsCount.GetComponent<Text>().text = "" + lapsDown;
        }
        if(other.name == "end_collider")
        {
            on = false;
        }
        
        
        
        
    }
    private void Start()
    {
        cameratoRotate.SetActive(false);
    }
    private void Update()
    {
        if(lapsDown == 3)
        {
            //TODO CONDITION WIN
            
            cameratoStop.SetActive(false);
            cameratoRotate.SetActive(true);
            cameratoRotate.transform.Rotate(0, 0.2f, 0, Space.World);
            
        }
    }
}
