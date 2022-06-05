using UnityEngine;

public class Animated : MonoBehaviour
{

    [SerializeField] private PhysicMaterial defaultFriction;
    [SerializeField] private PhysicMaterial zeroFriction;

    [SerializeField] private Collider leftCollider;
    [SerializeField] private Collider rightCollider;

    public void SetLeftFriction()
    {
        leftCollider.material = defaultFriction;
        rightCollider.material = zeroFriction;
    }

    public void SetRightFriction()
    {
        rightCollider.material = defaultFriction;
        leftCollider.material = zeroFriction;
    }
}