using System.Collections.Generic;
using UnityEngine;

public class HealthUI : MonoBehaviour
{
    [SerializeField] private GameObject HealthIconPf;

    private List<GameObject> healthIcons = new List<GameObject>();
    
    public void Init(int maxHealth, int currentHealth)
    {
        for (int i = 0; i < maxHealth; i++)
        {
            healthIcons.Add(Instantiate(HealthIconPf, transform));
        }
        SetHealth(currentHealth);
    }

    public void SetHealth(int health)
    {
        for (int i = 0; i < health; i++)
        {
            healthIcons[i].SetActive(true);
        }

        for (int i = health; i < healthIcons.Count; i++)
        {
            healthIcons[i].SetActive(false);
        }
    }
}
