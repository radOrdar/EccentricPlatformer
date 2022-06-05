using System;
using UnityEngine;

public class Unit : MonoBehaviour
{

    [SerializeField] private Transform target;
    [SerializeField] private Transform pelvis;
    [SerializeField] private ConfigurableJoint joint;

    private void Update()
    {
        Vector3 toTarget = target.position - pelvis.position;
        toTarget.y = 0;
        joint.targetRotation = Quaternion.Inverse( Quaternion.LookRotation(toTarget));
    }
}
