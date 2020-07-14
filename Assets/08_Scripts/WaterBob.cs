using UnityEngine;

public class WaterBob : MonoBehaviour
{
    [SerializeField]
    float height = 0.1f;
    float distanceModifier = 0.1f;
    float speedModifier = 2f;

    [SerializeField]
    float periodY = 1;
    float periodX = 5;
    float periodZ = 2;

    private Vector3 initialPosition;
    private float offset;

    private void Awake()
    {
        initialPosition = transform.position;

        offset = 1 - (Random.value * 2);
    }

    private void Update()
    {
        Vector3 modifiedPosition = transform.position;
        modifiedPosition.x = modifiedPosition.x - Mathf.Sin((Time.time * speedModifier + (1 - (Random.value * 2))) * periodX) * distanceModifier;
        modifiedPosition.z = modifiedPosition.z - Mathf.Sin((Time.time * speedModifier + (1 - (Random.value * 2))) * periodZ) * distanceModifier;
        modifiedPosition.y = initialPosition.y - Mathf.Sin((Time.time + offset) * periodY) * height;
        transform.position = modifiedPosition;
    }
}
