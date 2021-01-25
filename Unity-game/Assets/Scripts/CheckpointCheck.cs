using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointCheck : MonoBehaviour
{
    Vector3 lastCheckpointPos;
    Quaternion lastCheckpointRot;

    [HideInInspector] public bool victory = false;

    [HideInInspector] public int laps = 0;
    public int lapsToWin = 1;

    public List<GameObject> checks;

    // Start is called before the first frame update
    void Start()
    {
        lastCheckpointPos = transform.position;
        lastCheckpointRot = transform.rotation;

        GameObject go = GameObject.Find("Checkpoints");

        foreach (Transform child in go.transform)
        {
            checks.Add(child.gameObject);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            respawnLastCheckpoint();
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Checkpoint")
        {
            lastCheckpointPos = transform.position;
            lastCheckpointRot = transform.rotation;

            collision.gameObject.SetActive(false);
        }

        else if (collision.gameObject.tag == "Goal")
        {
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
    }

    public void respawnLastCheckpoint()
    {
        transform.position = lastCheckpointPos;
        transform.rotation = lastCheckpointRot;
    }
}
