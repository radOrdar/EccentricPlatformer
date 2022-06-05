using System;
using UnityEngine;
using UnityEngine.Events;

public enum Direction
{
    Left,
    Right
}

public class Walker : MonoBehaviour
{
    public Transform LeftTarget;
    public Transform RightTarget;
    public Transform RayStart;

    public float Speed;

    public float StopTime;

    public Direction currentDirection;

    private bool isStopped;

    public UnityEvent EventOnLeftTarget;
    public UnityEvent EventOnRightTarget;

    private void Start()
    {
        LeftTarget.parent = null;
        RightTarget.parent = null;
    }

    private void Update()
    {
        if (isStopped) return;

        if (currentDirection == Direction.Left)
        {
            transform.position -= new Vector3(Time.deltaTime * Speed, 0, 0);
            if (transform.position.x < LeftTarget.position.x)
            {
                currentDirection = Direction.Right;
                isStopped = true;
                Invoke("ContinueWalk", StopTime);
                EventOnLeftTarget?.Invoke();
            }
        } else
        {
            transform.position += new Vector3(Time.deltaTime * Speed, 0, 0);
            if (transform.position.x > RightTarget.position.x)
            {
                currentDirection = Direction.Left;
                isStopped = true;
                Invoke("ContinueWalk", StopTime);
                EventOnRightTarget?.Invoke();
            }
        }
        if (Physics.Raycast(RayStart.position, Vector3.down, out RaycastHit hit))
        {
            transform.position = new Vector3(transform.position.x, hit.point.y, transform.position.z);
        }
    }

    private void ContinueWalk()
    {
        isStopped = false;
    }
}