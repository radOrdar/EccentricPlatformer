using System;
using UnityEngine;

public class RotateToPlayer : MonoBehaviour
{

    [SerializeField] private Vector3 leftEuler;
    [SerializeField] private Vector3 rightEuler;

    [SerializeField] private float rotationSpeed;
    
    private Transform playerTransform;
    private Vector3 targetEuler;

    private void Start()
    {
        playerTransform = FindObjectOfType<PlayerMove>().transform;
    }

    private void Update()
    {
        if (transform.position.x < playerTransform.position.x)
        {
            targetEuler = rightEuler;
        } else
        {
            targetEuler = leftEuler;
        }
        
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(targetEuler), Time.deltaTime * rotationSpeed);
    }
}