﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecyclingMachineController : MonoBehaviour
{
    [SerializeField]
    public GameObject bomb;

    [SerializeField]
    public GameObject spawnPoint;

    [SerializeField]
    public int trashNeededToMakeBomb = 10;
    

    public int currentTrash = 0;

    // Update is called once per frame
    void Update()
    {
        TryToMakeBomb();
    }
    void OnTriggerEnter(Collider recycleCollider)
    {
        if (recycleCollider.gameObject.tag == "Trash")
        {
            Destroy(recycleCollider.gameObject);
            currentTrash += 1;
        }
    }

    private void TryToMakeBomb()
    {
        if (trashNeededToMakeBomb <= currentTrash)
        {
            GameObject bomb_ = Instantiate(bomb, spawnPoint.transform.position, Quaternion.identity) as GameObject;
            bomb_.GetComponent<Rigidbody>().AddForce(bomb_.transform.forward * 600);

            currentTrash = 0;

            Debug.Log("Made a Bomb");
         
        }
    }
}
