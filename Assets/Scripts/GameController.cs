using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameController : MonoBehaviourPun
{
    public Transform[] SpawnPoint = null;
    
    
    public void Awake()
    {
        int i = PhotonNetwork.CurrentRoom.PlayerCount - 1;

        PhotonNetwork.Instantiate("robot kyle", SpawnPoint[i].position, SpawnPoint[i].rotation);
        //PhotonNetwork.Instantiate("robot kyle", Vector3.zero, Quaternion.identity);
    }
}
