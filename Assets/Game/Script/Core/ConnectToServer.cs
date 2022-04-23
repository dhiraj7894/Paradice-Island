using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
    
public class ConnectToServer : MonoBehaviourPunCallbacks
{
    public TMP_InputField usernameInput;    
    public TextMeshProUGUI buttonText;
    public void OnClickConnect()
    {
        if (usernameInput.text.Length >= 1)
        {
            PhotonNetwork.NickName=usernameInput.text;
            buttonText.text = "Connecting......";
            PhotonNetwork.ConnectUsingSettings();

        }
    }
    public override void OnConnectedToMaster()
    {
        SceneManager.LoadScene("Lobby");
    }

}
