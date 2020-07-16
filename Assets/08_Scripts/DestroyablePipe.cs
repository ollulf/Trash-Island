using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyablePipe : MonoBehaviour
{

    [SerializeField]
    private GameObject thisPipe;

    [SerializeField]
    private GameObject destroyedPipe;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Bomb")
        {
            GameObject newPipe = Instantiate(destroyedPipe, thisPipe.transform.position, thisPipe.transform.rotation) as GameObject;
            newPipe.transform.localScale = thisPipe.transform.localScale;

            Destroy(thisPipe);
        }
    }
}
