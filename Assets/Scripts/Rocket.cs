using System;
using UnityEngine;

public class Rocket : MonoBehaviour
{
   public float Speed;
   public float RotationSpeed;

   private Transform playerTransform;

   private void Start()
   {
      playerTransform = FindObjectOfType<PlayerMove>().transform;
      transform.position = new Vector3(transform.position.x, transform.position.y, 0);
      Vector3 toPlayer = playerTransform.position - transform.position;
      transform.rotation = Quaternion.LookRotation(toPlayer, Vector3.forward);
   }

   private void Update()
   {
      transform.position += Time.deltaTime * transform.forward * Speed;
      Vector3 toPlayer = playerTransform.position - transform.position;
      Quaternion targetRotation = Quaternion.LookRotation(toPlayer, Vector3.forward);

      transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * RotationSpeed);
   }
}
