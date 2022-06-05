using System;
using UnityEngine;

public class IgnoreCollisions : MonoBehaviour
{

    [SerializeField] private Collider[] allColliders;

    private void Awake()
    {
        for (int i = 0; i < allColliders.Length; i++)
        {
            for (int j = i + 1; j < allColliders.Length; j++)
            {
                Physics.IgnoreCollision(allColliders[i], allColliders[j]);
            }
        }
    }
}