using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NetworkController : MonoBehaviourPunCallbacks
{
    public Text textStatus = null;
    public GameObject ButtonStart = null;
    public byte MaxPlayers = 4;

    private void Start()
    {
        //Debug.Log("Connecting to Master");
        PhotonNetwork.ConnectUsingSettings();
        ButtonStart.SetActive(false);
        Status("Connecting to server");
    }

    //callbacks to connect to master server
    public override void OnConnectedToMaster()
    {
        //Debug.Log("Connected to Master");
        base.OnConnectedToMaster();

        //PhotonNetwork.AutomaticallySyncScene = true; //all players same scene
        ButtonStart.SetActive(true);
        //Status("Connected to Master");
        Status("Connected to " + PhotonNetwork.ServerAddress);        
    }

    //click button to get into the room
    public void ButtonStart_Click()
    {
        string roomName = "Room1";
        Photon.Realtime.RoomOptions opts = new Photon.Realtime.RoomOptions(); //opts is a variable, option
        opts.IsOpen = true;
        opts.IsVisible = true;                                                //be able to see in the lobby
        opts.MaxPlayers = MaxPlayers;                                         //take up max player to join the room

        PhotonNetwork.JoinOrCreateRoom(roomName, opts, Photon.Realtime.TypedLobby.Default);
        ButtonStart.SetActive(false);
        Status("Joining " + roomName);
    }

    //load scene
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();

        SceneManager.LoadScene("Multiplayer"); //go to scene player
    }

    private void Status(string msg)
    {
        Debug.Log(msg);
        textStatus.text = msg;
    }
}
