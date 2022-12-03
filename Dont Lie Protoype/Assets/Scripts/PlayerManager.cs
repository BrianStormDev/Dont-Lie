using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;


public class PlayerManager : MonoBehaviour
{
    PhotonView PV;

    void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    void CreateController()
    {
        //instantiate player controller
        Debug.Log("Instantiated Player Controller");

        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Stylized Astronaut"), new Vector3 (16f, 1.861f, 7.0f), Quaternion.identity );
    }

    // Start is called before the first frame update
    void Start()
    {
        if (PV.IsMine)
        {
            CreateController();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
