using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoomListItem : MonoBehaviour
{

    [SerializeField] TMP_Text text;

    public RoomInfo info; // Is public so we can access in launcher script 

    public void SetUp(RoomInfo _info)
    {
        info = _info;
        text.text = _info.Name;
    }

    public void OnClick()
    {
        Launcher.Instance.JoinRoom(info);
    }
}
