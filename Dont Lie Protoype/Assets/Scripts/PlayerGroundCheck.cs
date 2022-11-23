using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundCheck : MonoBehaviour
{
    PlayerController PlayerController;
    // Start is called before the first frame update

    void Awake()
    {
        PlayerController = GetComponentInParent<PlayerController>(); //Probably needs changing
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == PlayerController.gameObject)
        {
            return;
        }

        PlayerController.SetGroundedState(true);
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == PlayerController.gameObject)
        {
            return;
        }

        PlayerController.SetGroundedState(false);


    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == PlayerController.gameObject)
        {
            return;
        }

        PlayerController.SetGroundedState(true);
    }

    void OnCollisionEnter (Collision collision)
    {
        if (other.gameObject == PlayerController.gameObject)
        {
            return;
        }

        PlayerController.SetGroundedState(true);
    }

    void OnCollisionExit (Collision collision)
    {
        if (other.gameObject == PlayerController.gameObject)
        {
            return;
        }

        PlayerController.SetGroundedState(false);
    }

    void OnCollisionStay (Collision collision)
    {
        if (other.gameObject == PlayerController.gameObject)
        {
            return;
        }

        PlayerController.SetGroundedState(true);
    }
}
