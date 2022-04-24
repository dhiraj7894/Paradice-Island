using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using TMPro;
public class LobbyManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField roomInputField;
    public TextMeshProUGUI roomName;
    void Start()
    {
        PhotonNetwork.JoinLobby();   
    }

    public  void OnClickCreate()
    {
        if(roomInputField.text.Length>=1)
            PhotonNetwork.CreateRoom(roomInputField.tag, new RoomOptions() { MaxPlayers = 25 });
    }

    public override void OnJoinedRoom()
    {
        roomName.text = "Room Name: " + PhotonNetwork.CurrentRoom.Name;
        SceneManager.LoadScene("Game");

    }
}
