using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Respawn : MonoBehaviour
{
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().Respawn();
         }
    }
}

