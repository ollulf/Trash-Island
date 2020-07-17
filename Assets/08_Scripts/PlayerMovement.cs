using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody Rigidbody;

    public float speed = 12f;
    public float jumpforce = 3f;

    float lastGroundedTimeStamp;
    private Transform respawnTarget;

    void Update()
    {


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        

        if(Input.GetButtonDown("Jump") && IsGrounded())
        {

            Rigidbody.AddForce(new Vector3(0,jumpforce,0),ForceMode.VelocityChange);
        }


        Move(new Vector3(move.x * speed,0,move.z*speed));
    }

    public void Respawn()
    {
        if(respawnTarget == null)
            
        {
            Debug.LogWarning("Cannot respawn, no checkpoint reached");
        }
        else
        {
            transform.position = respawnTarget.position;
            Physics.SyncTransforms();
            Debug.Log("Respawn");
        }
       
    }
    public void SetRespawn(Transform target)
    {
        respawnTarget = target;
        Debug.Log("Setting respawn to " + target.name);
    }
    private void Move(Vector3 forceInput)
    {
        Rigidbody.velocity = new Vector3(forceInput.x, Rigidbody.velocity.y, forceInput.z);

    }
    private bool IsGrounded()
    {
        return Time.time - lastGroundedTimeStamp < 0.1f;

    }
    private void OnCollisionStay(Collision collision)
    {
        float impactAngle = Vector3.Dot(collision.GetContact(0).normal, Vector3.up);
        if(impactAngle > 0.1)
        {
            lastGroundedTimeStamp = Time.time;
        }
    }
}
