using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessBoat : MonoBehaviour
{
    public GameObject boat;
    public GameObject player;
    public GameObject boatCamera;

    bool IsPossessed = false;
    bool InTrigger = false;
    public void Start()
    {
        UnPossess();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InTrigger = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) &&InTrigger == true)
        {
            Possess();
        }
        if (Input.GetKeyDown(KeyCode.F) && InTrigger == false)
        {
            UnPossess();
        }
    }

    private void Possess()
    {

        Debug.Log("E was pressed");


        player.GetComponent<PlayerMovement>().enabled = false;
        boat.GetComponent<BoatController>().enabled = true;
        player.GetComponentInChildren<Camera>().enabled = false;
        boatCamera.SetActive(true);
        IsPossessed = true;
        player.transform.parent = boat.transform;
    }

    private void UnPossess()
    {
        player.GetComponent<PlayerMovement>().enabled = true;
        boat.GetComponent<BoatController>().enabled = false;
        player.GetComponentInChildren<Camera>().enabled = true;
        boatCamera.SetActive(false);
        IsPossessed = false;
        player.transform.parent = null;
    }

}
