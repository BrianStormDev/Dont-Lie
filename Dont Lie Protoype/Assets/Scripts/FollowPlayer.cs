using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    public float currentX;
    public float currentY;
    public float currentZ;
    private Vector3 offset = new Vector3(0, 1.2f, 0.5f);

    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    void Update(){

    }
    // Update is called once per frame
    void LateUpdate()
    {
        //offest the camera behind the player by adding to the player
        transform.position = player.transform.position + offset;
    }
}
