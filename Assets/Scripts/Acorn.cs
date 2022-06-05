using UnityEngine;

public class Acorn : MonoBehaviour
{

    public Vector3 Velocity;
    public float MaxAngularVelocity;

    private void Start()
    {
        GetComponent<Rigidbody>().AddRelativeForce(Velocity, ForceMode.VelocityChange);
        GetComponent<Rigidbody>().angularVelocity = new Vector3(Random.Range(-MaxAngularVelocity, MaxAngularVelocity),
            Random.Range(-MaxAngularVelocity, MaxAngularVelocity),
            Random.Range(-MaxAngularVelocity, MaxAngularVelocity));
    }
}