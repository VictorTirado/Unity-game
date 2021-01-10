using Photon.Pun;
using UnityEngine;

public class GameController : MonoBehaviourPun
{
    public Transform[] SpawnPoint = null;
    private void Awake()
    {
        int i = PhotonNetwork.CurrentRoom.PlayerCount - 1;

        PhotonNetwork.Instantiate("Car", SpawnPoint[i].position,SpawnPoint[i].rotation);
    }
}
