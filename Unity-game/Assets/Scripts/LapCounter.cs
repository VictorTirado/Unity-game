using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LapCounter : MonoBehaviour
{
    public GameObject lapsCount;
    public GameObject cameratoRotate;
    public GameObject cameratoStop;
    

    public int lapsDown;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ColliderBody")
        {
            if (Time.time > 10f)
            {
            Debug.Log("HIIIIIIIIIIIIIIIII");
            lapsDown += 1;
            }            
        }
        lapsCount.GetComponent<Text>().text = "" + lapsDown;
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
            cameratoRotate.transform.Rotate(0, 0.5f, 0, Space.World);
            
        }
    }
}
