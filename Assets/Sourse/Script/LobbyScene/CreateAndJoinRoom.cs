using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CreateAndJoinRoom : MonoBehaviourPunCallbacks
{
    public InputField createInput;
    public InputField joinInput;
    public static bool isFort = false;
    public static bool isMonster = false;
    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text);
        isMonster = true;
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.text);
        isFort = true;
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }
}
