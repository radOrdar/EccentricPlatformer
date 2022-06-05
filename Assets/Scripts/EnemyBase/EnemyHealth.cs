using UnityEngine;
using UnityEngine.Events;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] private int Health = 1;
    [SerializeField] private UnityEvent OnTakeDamage;
    [SerializeField] private UnityEvent OnDie;

    public void TakeDamage(int damageValue)
    {
        Health -= damageValue;
        OnTakeDamage?.Invoke();
        if (Health <= 0)
        {
            Die();  
        }
    }

    private void Die()
    {
        Destroy(gameObject);
        OnDie?.Invoke();
    }
}