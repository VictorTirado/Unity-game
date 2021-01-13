using Photon.Pun;
using UnityEngine;

public class GameController : MonoBehaviourPun
{
    public Transform[] SpawnPoint = null;
    private void Awake()
    {
        int i = PhotonNetwork.CurrentRoom.PlayerCount - 1;
        Debug.Log(GameObject.Find("Cars").GetComponent<ChangeCar>().car_name);
        PhotonNetwork.Instantiate(GameObject.Find("Cars").GetComponent<ChangeCar>().car_name, SpawnPoint[i].position,SpawnPoint[i].rotation);
    }
}
