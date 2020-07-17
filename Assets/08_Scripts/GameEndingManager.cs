using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEndingManager : MonoBehaviour
{

    [SerializeField]
    GameObject[] pipesToDestroy;


    void Update()
    {
        Debug.Log(pipesToDestroy.Length);

        if (CheckIfAllDestroyed())
        {
            SceneManager.LoadScene(6);
        }
    }

    private bool CheckIfAllDestroyed()
    {
        if (pipesToDestroy [0] == null && pipesToDestroy [1] == null && pipesToDestroy[2] == null && pipesToDestroy[3] == null && pipesToDestroy[4] == null)
            return true;

        else
            return false;
    }
}
