using UnityEngine;

public class TakeDamageOnTrigger : MonoBehaviour
{
    [SerializeField] private EnemyHealth enemyHealth;
    [SerializeField] private bool dieOnAnyCollision;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Bullet bullet))
        {
            enemyHealth.TakeDamage(1);
        }

        if (dieOnAnyCollision == true)
        {
            if (collider.isTrigger) return;
            enemyHealth.TakeDamage(1000);
        }
    }
}