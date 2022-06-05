using System;
using UnityEngine;

public class LootHeal : MonoBehaviour
{
    public int HealthValue = 1;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.TryGetComponent(out PlayerHealth playerHealth))
            {
                playerHealth.AddHealth(HealthValue);
                gameObject.SetActive(false);
                Destroy(gameObject);
                
            }
        }
    }
}