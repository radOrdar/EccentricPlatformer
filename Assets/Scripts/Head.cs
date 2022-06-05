using System;
using UnityEngine;

public class Head : MonoBehaviour
{
    [SerializeField] private Transform Target;

    private void Update()
    {
        transform.position = Target.position;
    }
}