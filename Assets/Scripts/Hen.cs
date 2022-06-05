using System;
using UnityEngine;

public class Hen : MonoBehaviour
{
   [SerializeField] private Rigidbody rb;
   [SerializeField] private float speed;
   [SerializeField] private float timeToReachSpeed;

   private Transform playerTransform;

   private void Start()
   {
      playerTransform = FindObjectOfType<PlayerMove>().transform;
   }

   private void FixedUpdate()
   {
      Vector3 toPlayer = (playerTransform.position - transform.position).normalized;
      Vector3 force = rb.mass * (toPlayer * speed - rb.velocity) / timeToReachSpeed;
      
      rb.AddForce(force);
   }
}