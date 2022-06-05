using System;
using UnityEngine;

public class Hook : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] private Collider collider;
    [SerializeField] private Collider playerCollider;
    [SerializeField] private RopeGun ropeGun;

    private FixedJoint fixedJoint;

    private void Start()
    {
        Physics.IgnoreCollision(collider, playerCollider);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (fixedJoint != null) return;
        fixedJoint = gameObject.AddComponent<FixedJoint>();
        fixedJoint.connectedBody = collision.rigidbody;
        ropeGun.CreateSpring();
    }

    public void StopFix()
    {
        if (fixedJoint)
        {
            Destroy(fixedJoint);
        }
    }
}