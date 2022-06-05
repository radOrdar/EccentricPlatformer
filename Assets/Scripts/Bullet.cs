using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private GameObject EffectPf;

    private void Start()
    {
        Destroy(gameObject, 4f);
    }

    private void OnCollisionEnter(Collision other)
    {
        Instantiate(EffectPf, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}