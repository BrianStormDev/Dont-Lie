using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class Launcher : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_InputField roomNameInputField;
    [SerializeField] TMP_Text errorText;
    [SerializeField] TMP_Text roomNameText;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Connecting to Server");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster(){
        PhotonNetwork.JoinLobby(); //You must be in the lobby to make or join rooms
    }

    public override void OnJoinedLobby(){
        MenuManager.Instance.OpenMenu("Title");
        Debug.Log("You have successfully joined a lobby");
    }

    public void CreateRoom(){
        if (string.IsNullOrEmpty(roomNameInputField.text))
            return;  
        PhotonNetwork.CreateRoom(roomNameInputField.text);
        MenuManager.Instance.OpenMenu("Loading");
    }

    public override void OnJoinedRoom(){ //Called when u join or create a room
        MenuManager.Instance.OpenMenu("Room");
        roomNameText.text = PhotonNetwork.CurrentRoom.Name;
    }

    public override void OnCreateRoomFailed(short returnCode, string message){
        errorText.text = "Room Creation Failed" + message;
        MenuManager.Instance.OpenMenu("Error");
        //Have Menu Manager open OnClick the title menu
    }

    public void LeaveRoom(){
        PhotonNetwork.LeaveRoom();
        MenuManager.Instance.OpenMenu("Loading");
    }

    public override void OnLeftRoom(){
        MenuManager.Instance.OpenMenu("Title");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
