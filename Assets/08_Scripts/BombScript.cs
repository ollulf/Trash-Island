using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    GameObject trashParticles;

    [SerializeField]
    ParticleSystem explosionParticleSystem;

    public bool isActive = false;

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {

        if (isActive)
        {
            ExplosionVisualisation();

            Debug.Log("Boom!");

            Destroy(gameObject);
        }
        
        
    }

    private void ExplosionVisualisation() 
    {
        Instantiate(explosionParticleSystem, transform.position, Quaternion.identity);

        Instantiate(trashParticles, transform.position, Quaternion.identity);
        Instantiate(trashParticles, transform.position, Quaternion.identity);
        Instantiate(trashParticles, transform.position, Quaternion.identity);
        Instantiate(trashParticles, transform.position, Quaternion.identity);
        Instantiate(trashParticles, transform.position, Quaternion.identity);
        Instantiate(trashParticles, transform.position, Quaternion.identity);
        Instantiate(trashParticles, transform.position, Quaternion.identity);
    }
}
