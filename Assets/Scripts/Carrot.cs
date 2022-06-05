using System;
using UnityEngine;

public class Carrot : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rb;

    private void Start()
    {
        transform.rotation = Quaternion.identity;
        Transform playerTransform = FindObjectOfType<PlayerMove>().transform;
        Vector3 toPlayer = (playerTransform.position - transform.position).normalized;
        rb.velocity = toPlayer * speed;
    }
}