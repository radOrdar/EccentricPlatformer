using System;
using UnityEngine;

public class Follow : MonoBehaviour
{

    [SerializeField] private Transform Target;
    [SerializeField] private float SmoothFactor;

    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, Target.position, Time.deltaTime * SmoothFactor);
    }
}