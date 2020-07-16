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
    private GameObject bombModel;


    [SerializeField]
    private GameObject bombVisualizer;

    [SerializeField]
    private float throwingForce = 100;

    private int currentAmount = 0;

    private int currentBombs = 0;

    [SerializeField]
    private bool funModeEnabled = false;

    void Start()
    {
        if (funModeEnabled)
        {
            throwingForce = 3000;
            currentAmount = 3000;
        }

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

        if (Input.GetKeyDown(KeyCode.B))
        {
            TryThrowBomb();
        }

        VisualizeBomb();

    }

    private void VisualizeBomb()
    {
        if (currentBombs > 0)
        {
            bombVisualizer.SetActive(true);
        }
        else
        {
            bombVisualizer.SetActive(false);
        }

    }

    private void TryThrowBomb()
    {
        if (currentBombs > 0)
        {
            GameObject currentTrash = Instantiate(bombModel, spawnPoint.transform.position, Camera.main.transform.rotation) as GameObject;
            currentTrash.GetComponent<Rigidbody>().AddForce(currentTrash.transform.forward * 2000);
            currentTrash.GetComponent<BombScript>().isActive = true;

            currentBombs -= 1;
        }
    }

    private void TryToPickup()
    {
        var ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject.tag == "Trash" && currentAmount < carryingCapacity && hit.distance <= 5)
            {
                Destroy(hit.transform.gameObject);
                Debug.Log("Picked Up Trash");
                currentAmount += 1;
            }

            else if (hit.transform.gameObject.tag == "Bomb" && hit.distance <= 5)
            {
                Destroy(hit.transform.gameObject);
                Debug.Log("Picked Up Bomb");
                currentBombs += 1;
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
