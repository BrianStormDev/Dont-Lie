using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject door;
    private float rotation = 90.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider player){
        if (player.CompareTag("Player")){
            Open();
            Debug.Log("Open the damn door!");
        }    
        else
        {
            Debug.Log("oof");
        }
    }

    private void OnTriggerExit(Collider player){
        Close();
    }

    public void Open(){
        door.transform.Rotate(0.0f, -rotation, 0.0f, Space.Self);
    }

    public void Close(){
        door.transform.Rotate(0.0f, rotation, 0.0f, Space.Self);
    }
}
