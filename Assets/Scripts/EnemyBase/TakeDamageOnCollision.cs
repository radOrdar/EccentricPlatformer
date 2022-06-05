using UnityEngine;

public class TakeDamageOnCollision : MonoBehaviour
{
    [SerializeField] private EnemyHealth enemyHealth;
    [SerializeField] private bool dieOnAnyCollision;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.TryGetComponent(out Bullet bullet))
        {
            enemyHealth.TakeDamage(1);
        }
        
        if (dieOnAnyCollision == true) enemyHealth.TakeDamage(1000);
    }
}