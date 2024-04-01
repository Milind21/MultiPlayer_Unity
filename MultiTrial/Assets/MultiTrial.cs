using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MultiTrial : MonoBehaviourPunCallbacks
{
    public GameObject player;
    [Space]
    public Transform spawnPoint;
    private bool roomCreated;
    void Start()
    {
        Debug.Log("Connecting to server");
        PhotonNetwork.ConnectUsingSettings();  //Master Server using which we can connect to different rooms
    }
    public override void OnConnectedToMaster() {
        base.OnConnectedToMaster();
        Debug.Log("Connected to Server");
        PhotonNetwork.JoinLobby();
    }
    public override void OnJoinedLobby(){
        base.OnJoinedLobby();
        var op= PhotonNetwork.JoinOrCreateRoom("test",null,null);
        Debug.Log("Connected and in a room now");
    }
    public override void OnJoinedRoom ()
    {
        base.OnJoinedRoom();
        var roomName = PhotonNetwork.CurrentRoom.Name;
        Debug.Log($"Joined room {roomName}");
        // Spawn Player
        GameObject _player = PhotonNetwork.Instantiate(player.name, spawnPoint.position, Quaternion.identity);
        _player.GetComponent<PlayerSetup>().IsLocalPlayer(); // To make the movement and camera set only for the local player
    }
}
