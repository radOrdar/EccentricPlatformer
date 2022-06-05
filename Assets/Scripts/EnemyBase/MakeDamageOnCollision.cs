using System;
using UnityEngine;

public class MakeDamageOnCollision : MonoBehaviour
{
    [SerializeField] private int DamageVal = 1;

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody attachedRb = collision.rigidbody;
        if (attachedRb != null && attachedRb.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.TakeDamage(DamageVal);
        }
    }
}