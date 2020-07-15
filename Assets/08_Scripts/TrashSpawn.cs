using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashSpawn : MonoBehaviour
{

    ObjectPooler objectPooler;

    private void Start()
    {
        objectPooler = ObjectPooler.instance;
        StartCoroutine(HERE());
    }


    public IEnumerator HERE()
    {
       
        while (true)
        {
            yield return new WaitForSeconds(1.0f); //this stops the coroutine for 1 second.
            objectPooler.SpawnFromPool("Trash", transform.position, Quaternion.identity);
        }
    }


}
