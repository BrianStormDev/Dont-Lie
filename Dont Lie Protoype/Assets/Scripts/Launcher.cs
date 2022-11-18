using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;
using System.Linq;

public class Launcher : MonoBehaviourPunCallbacks
{
    public static Launcher Instance;
    private static Dictionary<string, RoomInfo> cachedRoomList = new Dictionary<string, RoomInfo>();

    [SerializeField] TMP_InputField roomNameInputField;
    [SerializeField] TMP_Text errorText;
    [SerializeField] TMP_Text roomNameText;
    [SerializeField] Transform roomListContent;
    [SerializeField] Transform playerListContent;
    [SerializeField] GameObject roomListItemPrefab;
    [SerializeField] GameObject PlayerListItemPrefab;
    [SerializeField] GameObject startGameButton;

    private void Awake(){
        Instance = this;
    }

    //Start is called before the first frame update
    void Start(){
        Debug.Log("Connecting to Server");
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster(){
        PhotonNetwork.JoinLobby(); //You must be in the lobby to make or join rooms
        PhotonNetwork.AutomaticallySyncScene = true; //Determines if we are going to automatically load the scene for all cients
    }

    public override void OnJoinedLobby(){
        MenuManager.Instance.OpenMenu("Title");
        Debug.Log("You have successfully joined a lobby");
        PhotonNetwork.NickName = "Player " + Random.Range(0, 1000).ToString("0000"); //Player name placeholder
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

        Player[] players = PhotonNetwork.PlayerList;

        foreach(Transform child in playerListContent)
            Destroy(child.gameObject);

        for (int i = 0; i < players.Count(); i++)
            Instantiate(PlayerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(players[i]);

        startGameButton.SetActive(PhotonNetwork.IsMasterClient); //If player is host of room, start game button is set as active
    }

    public override void OnMasterClientSwitched(Player newMasterClient){ //If host leaves, new player is assigned host
        startGameButton.SetActive(PhotonNetwork.IsMasterClient);
    }

    public override void OnCreateRoomFailed(short returnCode, string message){
        errorText.text = "Room Creation Failed" + message;
        MenuManager.Instance.OpenMenu("Error");
        //Have Menu Manager open OnClick the title menu
    }

    public void StartGame(){
        PhotonNetwork.LoadLevel(1);
    }

    public void LeaveRoom(){
        PhotonNetwork.LeaveRoom();
        MenuManager.Instance.OpenMenu("Loading");
    }

    public void JoinRoom(RoomInfo info){
        PhotonNetwork.JoinRoom(info.Name);
        MenuManager.Instance.OpenMenu("Loading");
    }

    public override void OnLeftRoom(){
        MenuManager.Instance.OpenMenu("Title");
        cachedRoomList.Clear();
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList){
        foreach (Transform trans in roomListContent)
            Destroy(trans.gameObject);

        for (int i = 0; i < roomList.Count; i++)
        {
            RoomInfo info = roomList[i];
            if (info.RemovedFromList)
                cachedRoomList.Remove(info.Name);
            else
                cachedRoomList[info.Name] = info;
        }
        foreach (KeyValuePair<string, RoomInfo> entry in cachedRoomList)
            Instantiate(roomListItemPrefab, roomListContent).GetComponent<RoomListItem>().SetUp(cachedRoomList[entry.Key]);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer){
        Instantiate(PlayerListItemPrefab, playerListContent).GetComponent<PlayerListItem>().SetUp(newPlayer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
