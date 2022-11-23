using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.SceneManagement;
using System.IO;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager Instance;

    void Awake()
    {
        if (Instance) //Checks if another RoomManager exists
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject); //does not destroy when scene switches
        Instance = this;
    }

    //overrides
    public override void OnEnable() 
    {
        base.OnEnable(); //need to call from base for Photon to function
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public override void OnDisable()
    {
        base.OnDisable(); //need to call from base for Photon to function , this is only important for OnEnable and OnDisable
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode )
    {
        
        if (scene.buildIndex == 1) //We are in the game scene, so spawn playerManager
        {
            PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "PlayerManager"), Vector3.zero, Quaternion.identity);   
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
