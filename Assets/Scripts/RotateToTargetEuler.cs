using System;
using UnityEngine;

public class RotateToTargetEuler : MonoBehaviour
{
    public Vector3 LeftEuler;
    public Vector3 RightEuler;
    
    public float RotationSpeed;

    private Vector3 targetEuler;

    private void Update()
    {
        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(targetEuler), Time.deltaTime * RotationSpeed);
    }

    public void RotateLeft()
    {
        targetEuler = LeftEuler;
    }
    public void RotateRight()
    {
        targetEuler = RightEuler;
    }
}