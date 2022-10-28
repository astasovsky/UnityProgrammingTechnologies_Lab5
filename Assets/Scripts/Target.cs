using UnityEngine;

public class Target : MonoBehaviour
{
    private const float MinSpeed = 14;
    private const float MaxSpeed = 17;
    private const float MaxTorque = 4;
    private const float XRange = 4;
    private const float YSpawnPosition = -6;

    private Rigidbody _targetRigidbody;

    private void Awake()
    {
        _targetRigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        transform.position = RandomSpawnPos();
        _targetRigidbody.AddForce(RandomForce(), ForceMode.Impulse);
        _targetRigidbody.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    private static Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(MinSpeed, MaxSpeed);
    }

    private static float RandomTorque()
    {
        return Random.Range(-MaxTorque, MaxTorque);
    }

    private static Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-XRange, XRange), YSpawnPosition);
    }
}