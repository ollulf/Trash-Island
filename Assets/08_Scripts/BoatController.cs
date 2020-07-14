using UnityEngine;

public class BoatController : MonoBehaviour
{
    public Transform Motor;
    public float SteerPower = 5f;
    public float Power = 5f;
    public float MaxSpeed = 10f;
    public float Drag = 0.1f;
    float Rotation = 0;
    public float MaxAngularVel = 1f;
    public AnimationCurve DotToDrag;

    protected Rigidbody Rigidbody;
    protected Quaternion StartRotation;

    public void Awake()
    {
        Rigidbody = GetComponent<Rigidbody>();
        StartRotation = Motor.localRotation;
    }

    private void FixedUpdate()
    {
        Vector3 forceDirection = transform.forward;



        if (Input.GetKey(KeyCode.A))
        {
            Rotation = Mathf.Lerp(Rotation, 60, Time.fixedDeltaTime);

        }
        if (Input.GetKey(KeyCode.D))
        {
            Rotation = Mathf.Lerp(Rotation, -60, Time.fixedDeltaTime);
        }
        else
        {
            Rotation = Mathf.Lerp(Rotation, 0, Time.fixedDeltaTime);
        }

        // Rotation = Mathf.Clamp(Rotation, -60, 60);
        Motor.localEulerAngles = new Vector3(0, Rotation, 0);
        Vector3 force = Motor.forward * Power;
        Rigidbody.maxAngularVelocity = MaxAngularVel;
        if (Input.GetKey(KeyCode.W))
        {
            Rigidbody.AddForceAtPosition(force, Motor.position);
        }
        if (Input.GetKey(KeyCode.S))
        {
            Rigidbody.AddForceAtPosition(-force, Motor.position);
        }

        float dot = Vector3.Dot(Rigidbody.velocity.normalized, transform.forward);

        // Rigidbody.velocity = Rigidbody.velocity * (1-(DotToDrag.Evaluate(dot)*Drag));

        if (Rigidbody.velocity.magnitude >= MaxSpeed)
        {
            Rigidbody.velocity = Rigidbody.velocity.normalized * MaxSpeed;
        }
        if(dot > 0)
        {
           
            Rigidbody.velocity = Vector3.Lerp(Rigidbody.velocity, transform.forward * Rigidbody.velocity.magnitude, DotToDrag.Evaluate(Mathf.Abs(dot)));
        }
        else
        {
            Rigidbody.velocity = Vector3.Lerp(Rigidbody.velocity, transform.forward  * -Rigidbody.velocity.magnitude, DotToDrag.Evaluate(Mathf.Abs(dot)));
            
        }

    }



}
