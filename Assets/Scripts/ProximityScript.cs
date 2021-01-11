using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityScript : MonoBehaviour
{
    public GameObject GameController;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameController.GetComponent<MoveDoorScript>().moveTrue();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameController.GetComponent<MoveDoorScript>().moveFalse();
        }
    }
}
