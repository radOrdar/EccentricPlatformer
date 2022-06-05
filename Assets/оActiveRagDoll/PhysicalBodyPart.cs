using System;
using UnityEngine;

[RequireComponent(typeof(ConfigurableJoint))]
public class PhysicalBodyPart : MonoBehaviour
{
    [SerializeField] private Transform targetRotation;
    private ConfigurableJoint joint;
    private Quaternion startRotation;

    private void Start()
    {
        joint = GetComponent<ConfigurableJoint>();
        startRotation = transform.rotation;
    }

    private void Update()
    {
        joint.targetRotation = Quaternion.Inverse(targetRotation.localRotation) * startRotation;
    }
}