using System;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody rb;
    public float TurnSpeed;
    public float MoveSpeed;
    public float JumpSpeed;
    public float Friction;
    public bool Grounded;
    public float MaxSpeed;
    public Transform ColliderTransform;
    public Transform BodyTransform;
    public Transform AimTransform;

    private Quaternion targetBodyRotation;
    private int jumpFrameCounter;

    private void Update()
    {
        if (Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.S) || Grounded == false)
        {
            ColliderTransform.localScale = Vector3.Lerp(ColliderTransform.localScale, new Vector3(1, 0.5f, 1), Time.deltaTime * 15f);
        } else
        {
            ColliderTransform.localScale = Vector3.Lerp(ColliderTransform.localScale, Vector3.one, Time.deltaTime * 15f);
        }

        if (Input.GetKeyDown(KeyCode.Space) && Grounded)
        {
            Jump();
        }

        if (AimTransform.position.x > transform.position.x)
        {
            targetBodyRotation = Quaternion.Euler(0, -45, 0);
        } else
        {
            targetBodyRotation = Quaternion.Euler(0, 45, 0);
        }

        BodyTransform.localRotation = Quaternion.Lerp(BodyTransform.localRotation, targetBodyRotation, TurnSpeed * Time.deltaTime);
    }

    public void Jump()
    {
        rb.AddForce(0, JumpSpeed, 0, ForceMode.VelocityChange);
        jumpFrameCounter = 0;
    }

    private void FixedUpdate()
    {
        float speedMultiplier = 1;
        
        if (Grounded == false)
        {
            speedMultiplier = 0.2f;
            if (rb.velocity.x > MaxSpeed && Input.GetAxis("Horizontal") > 0) speedMultiplier = 0;
            if (rb.velocity.x < -MaxSpeed && Input.GetAxis("Horizontal") < 0) speedMultiplier = 0;

            if (jumpFrameCounter++ == 3)
            {
                rb.freezeRotation = false;
                rb.AddRelativeTorque(0, 0, 5 * -Mathf.Sign(rb.velocity.x), ForceMode.VelocityChange);
            }
        } else
        {
            rb.AddForce(-rb.velocity.x * Friction, 0, 0, ForceMode.VelocityChange);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.identity, 15 * Time.deltaTime);
        }
        
        rb.AddForce(Input.GetAxis("Horizontal") * MoveSpeed * speedMultiplier, 0, 0, ForceMode.VelocityChange);
    }

    private void OnCollisionStay(Collision collision)
    {
        if (Vector3.Dot(collision.GetContact(0).normal, transform.up) > 0.52)
        {
            Grounded = true;
            rb.freezeRotation = true;
        }
    }

    private void OnCollisionExit() => Grounded = false;
}