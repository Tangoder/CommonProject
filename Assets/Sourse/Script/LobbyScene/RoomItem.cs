using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class RoomItem : MonoBehaviourPunCallbacks
{
    public Text roomName;

    CreateAndJoinRoom manager;

    public void Start()
    {
        manager = FindObjectOfType<CreateAndJoinRoom>();
    }

    public void SetRoomName(string _roomName)
    {
        roomName.text = _roomName;
    }

    public void OnClickItem()
    {
        manager.JoinRoom(roomName.text);
    }
}
