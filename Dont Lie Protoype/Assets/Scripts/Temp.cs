using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace Com.MyCompany.MyGame{
    public class Launcher : MonoBehaviourPunCallbacks
    {
        #region Private Serializable Fields
        [Tooltip("The maximum number of players per room. When a room is full, it can't be joined by new players, and so new room will be created")]
        [SerializeField]
        private byte maxPlayersPerRoom = 4;

        [Tooltip("The UI Panel to let the user enter name, connect and play")]
        [SerializeField]
        private GameObject controlPanel;
        [Tooltip("The UI Label to inform user tha connection is in progress")]
        [SerializeField]
        private GameObject progressLabel;
        #endregion

        #region Private Fields
        /* Client's version number. Users are separated from 
            each other by gameVersion 
            (which allows you to make breaking changes). */
        string gameVersion = "1";
        #endregion

        #region MonoBehavior CallBacks
        /* MonoBehavior method called on GameObject by Unity
            during early initialization phase */

        void Awake(){
            /*CRITICAL: Makes sure we can use PhotonNetwork.LoadLevel() on the master client 
                and all clients in the same room sync their level automatically */
            PhotonNetwork.AutomaticallySyncScene = true;
        }
        // Start is called before the first frame update
        void Start()
        {
            progressLabel.SetActive(false);
            controlPanel.SetActive(true);
        }
        #endregion

        #region Public Methods
        //Start the connection process
        public void Connect(){
            progressLabel.SetActive(true);
            controlPanel.SetActive(false);
            //If connected, we join a random room, otherwise, we initiation connection to server
            if (PhotonNetwork.IsConnected){
                /*CRITICAL: We need at this point to attempt joining a Random Room. 
                    If it fails, we'll get notified in OnJoinRandomFailed() and we'll create one. */
                PhotonNetwork.JoinRandomRoom();
            }
            else
            {
                //CRITICAL: We must first and foremost connect to Photon Online Server
                PhotonNetwork.ConnectUsingSettings();
                PhotonNetwork.GameVersion = gameVersion;
            }
        }
        #endregion

        #region MonoBehaviorPunCallbacks Callbacks
        public override void OnConnectedToMaster(){
            Debug.Log("PUN Bascis Tutorial/Launcher: OnConnectedToMaster() was called by PUN");
            //We try to join a room, if doesn't work, we'll be called back w/ OnJoinRandomFailed()
            PhotonNetwork.JoinRandomRoom();
        }

        public override void OnDisconnected(DisconnectCause cause){
            progressLabel.SetActive(false);
            controlPanel.SetActive(true);
            Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0}", cause);
        }

        public override void OnJoinRandomFailed(short returnCode, string message){
            Debug.Log("PUN Basics Tutorial/Launcher:OnJoinRandomFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");
            PhotonNetwork.CreateRoom(null, new RoomOptions {MaxPlayers = maxPlayersPerRoom});
        }

        public override void OnJoinedRoom(){
            Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");
        }
        #endregion
    }
}

