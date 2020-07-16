using UnityEngine;

public class WaterBob : MonoBehaviour
{
    [SerializeField]
    float height = 0.1f;
    float distanceModifier = 1f;
    float speedModifier = 0.2f;

    [SerializeField]
    float period = 1;

    private Vector3 initialPosition;
    private float targetZPosition;
    private float targetXPosition;
    private float offset;

    private void Awake()
    {
        initialPosition = transform.position;
        targetZPosition = RandomZPosition();
        targetXPosition = RandomXPosition(); 

        offset = 1 - (Random.value * 2);
    }

    private float RandomZPosition()
    {
        return (transform.position.z - (1 - (Random.value * 2))) * distanceModifier;
    }

    private float RandomXPosition()
    {

        return (transform.position.x - (1 - (Random.value * 2))) * distanceModifier;
    }

    private void FixedUpdate()
 
    {
        Vector3 modifiedPosition = transform.position;
        if (modifiedPosition.x < targetXPosition)
        {
            modifiedPosition.x += Time.deltaTime * speedModifier;
            if (modifiedPosition.x >= targetXPosition)
            {
                targetXPosition = RandomXPosition();
            }
        } 
        else
        {
            modifiedPosition.x -= Time.deltaTime * speedModifier;
            if (modifiedPosition.x <= targetXPosition)
            {
                targetXPosition = RandomXPosition();
            }
        }
        if (modifiedPosition.z < targetZPosition)
        {
            modifiedPosition.z += Time.deltaTime * speedModifier;
            if (modifiedPosition.z >= targetZPosition)
            {
                targetZPosition = RandomZPosition();
            }
        }
        else
        {
            modifiedPosition.z -= Time.deltaTime * speedModifier;
            if (modifiedPosition.z <= targetZPosition)
            {
                targetZPosition = RandomZPosition();
            }
        }
        modifiedPosition.y = initialPosition.y - Mathf.Sin((Time.time + offset) * period) * height;
        ///Debug.Log("x: " + transform.position.x + ", (" + targetXPosition + ")");
        transform.position = modifiedPosition;
    }
}
