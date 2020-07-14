using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController : MonoBehaviour
{
    [SerializeField]
    private int carryingCapacity = 5;

    [SerializeField]
    private GameObject spawnPoint;

    [SerializeField]
    private GameObject trashModel;

    [SerializeField]
    private float throwingForce = 100;

    private int currentAmount = 0;

    [SerializeField]
    private bool funModeEnabled = false;

    void Start()
    {
        throwingForce = 3000;
        currentAmount = 3000;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryToPickup();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            TryThrowTrash();
        }

        if (funModeEnabled)
        {
            if (Input.GetKey(KeyCode.Q))
                TryThrowTrash();
        }

    }

    private void TryToPickup()
    {
        var ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if(hit.transform.gameObject.tag == "Trash" && currentAmount < carryingCapacity)
            {
                Destroy(hit.transform.gameObject);
                Debug.Log("Picked Up Trash");
                currentAmount += 1;
            }
        }
    }

    private void TryThrowTrash()
    {
        if(currentAmount > 0)
        {
            GameObject currentTrash = Instantiate(trashModel, spawnPoint.transform.position, Camera.main.transform.rotation) as GameObject;
            currentTrash.GetComponent<Rigidbody>().AddForce(currentTrash.transform.forward * throwingForce);

            currentAmount -= 1;
        }


    }


}
