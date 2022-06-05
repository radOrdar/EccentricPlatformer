using UnityEngine;

public class LootBullets : MonoBehaviour
{
    
    [SerializeField] private int bulletsToAdd = 1;
    [SerializeField] private int gunIndex = 1;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            if (other.attachedRigidbody.TryGetComponent(out PlayerArmory playerArmory))
            {
                playerArmory.AddBullets(gunIndex, bulletsToAdd);
                gameObject.SetActive(false);
                Destroy(gameObject);
            }
        }
    }
}