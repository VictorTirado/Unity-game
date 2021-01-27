using Photon.Pun;
using UnityEngine;

public class GameController : MonoBehaviourPun
{
    public Transform[] SpawnPoint = null;
    private void Awake()
    {
        int rand = Random.Range(0, 3);
        int i = PhotonNetwork.CurrentRoom.PlayerCount - 1;
        //Debug.Log(GameObject.Find("Cars").GetComponent<ChangeCar>().car_name);
        //PhotonNetwork.Instantiate(GameObject.Find("Cars").GetComponent<ChangeCar>().car_name, SpawnPoint[i].position,SpawnPoint[i].rotation);
        if(rand == 0)
        {
            PhotonNetwork.Instantiate("Toyota", SpawnPoint[i].position, SpawnPoint[i].rotation);
        }
        else if (rand == 1)
        {
            PhotonNetwork.Instantiate("ToyotaB", SpawnPoint[i].position, SpawnPoint[i].rotation);
        }
        else if (rand == 2)
        {
            PhotonNetwork.Instantiate("ToyotaR", SpawnPoint[i].position, SpawnPoint[i].rotation);
        }
        else if (rand == 3)
        {
            PhotonNetwork.Instantiate("ToyotaP", SpawnPoint[i].position, SpawnPoint[i].rotation);
        }
       
    }
}
