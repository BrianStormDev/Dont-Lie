using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;


public class PlayerManager : MonoBehaviour
{
    PhotonView PV;
    Vector3 position = new Vector3 (4.5f, -3.6f, 6.1f);

    void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    void CreateController()
    {
        //instantiate player controller
        Debug.Log("Instantiated Player Controller");

        PhotonNetwork.Instantiate(Path.Combine("PhotonPrefabs", "Stylized Astronaut"), position, Quaternion.identity );
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
