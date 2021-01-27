using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointCheck : MonoBehaviour
{
    Vector3 lastCheckpointPos;
    Quaternion lastCheckpointRot;

    

    [HideInInspector] public bool victory = false;

    public int laps = 0;
    public int lapsToWin = 1;

    public List<GameObject> checks;

    private Rigidbody car_body;

    public float lap_time = 0.0f;
    public float fast_lap = 0.0f;
    bool passed_goal = false;

    // Start is called before the first frame update
    void Start()
    {
        lastCheckpointPos = transform.position;
        lastCheckpointRot = transform.rotation;

        car_body = GetComponent<Rigidbody>();

        GameObject go = GameObject.Find("Checkpoints");

        if (go)
        {
            foreach (Transform child in go.transform)
            {
                checks.Add(child.gameObject);
            }
        }        
    }

    void Update()
    {

        lap_time += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.T))
        {
            respawnLastCheckpoint();
        }
        if(victory == true)
        {
            //WIN CONDITION
            gameObject.GetComponent<GameController>().enabled = false;
            
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        Debug.Log("COLLIDING!");

        if (collider.gameObject.tag == "Checkpoint")
        {
            Debug.Log("COLLIDING WITH A CHECKPOINT!");

            passed_goal = false;

            lastCheckpointPos = transform.position;
            lastCheckpointRot = transform.rotation;

            collider.gameObject.SetActive(false);
        }

        else if (collider.gameObject.tag == "Goal")
        {         
            if(fast_lap == 0.0f && passed_goal == false)
            {
                fast_lap = lap_time;
            }
            else if(lap_time < fast_lap && passed_goal == false)
            {
                fast_lap = lap_time;
            }

            passed_goal = true;

            lap_time = 0.0f;

            Debug.Log("COLLIDING WITH THE GOAL!");

            bool passedAllChecks = true;

            foreach (GameObject checkpoint in checks)
            {
                if (checkpoint.activeInHierarchy)
                {
                    passedAllChecks = false;
                    break;
                }                
            }

            if (passedAllChecks)
            {
                foreach (GameObject checkpoint in checks)
                {
                    checkpoint.SetActive(true);
                }

                laps++;

                if (laps >= lapsToWin)
                {
                    victory = true;
                }
            }
        }
        else if(collider.gameObject.tag == "Map")
        {
            Debug.Log("COLLIDING WITH MAP! YOU ARE OUT OF THE ROAD");
            //respawnLastCheckpoint();
        }
    }

    public void respawnLastCheckpoint()
    {
        transform.position = lastCheckpointPos;
        transform.rotation = lastCheckpointRot;
        car_body.velocity = Vector3.zero;
    }

    
}
