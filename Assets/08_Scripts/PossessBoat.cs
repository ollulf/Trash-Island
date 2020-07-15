using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PossessBoat : MonoBehaviour
{
    public GameObject boat;
    public GameObject player;
    public GameObject boatCamera;


    [SerializeField]
    bool InTrigger = false;
    bool isPossessed;


    [SerializeField]
//    public GameObject spawnpoint;



    public void Start()
    {
        UnPossess();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player Entered Trigger");
            InTrigger = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            InTrigger = false;
            Debug.Log("Player Exits Trigger");
        }
    }

    public void Update()
    {
        if (InTrigger && !isPossessed && Input.GetKeyDown(KeyCode.F))
        {
            Possess();

        }
        else if(isPossessed && Input.GetKeyDown(KeyCode.F))
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
        isPossessed = true;
        player.transform.parent = boat.transform;

    }

    private void UnPossess()
    {
        player.GetComponent<PlayerMovement>().enabled = true;
        boat.GetComponent<BoatController>().enabled = false;
        player.GetComponentInChildren<Camera>().enabled = true;
        boatCamera.SetActive(false);
        isPossessed = false;
        player.transform.parent = null;
        Debug.Log("unpossessed");
        
    }

}
