using System;
using UnityEngine;


public class MakeDamageOnTrigger : MonoBehaviour
{
    [SerializeField] private int DamageVal = 1;

    private void OnTriggerEnter(Collider collider)
    {
        Rigidbody attachedRb = collider.attachedRigidbody;
        if (attachedRb != null && attachedRb.TryGetComponent(out PlayerHealth playerHealth))
        {
            playerHealth.TakeDamage(DamageVal);
        }
    }
}