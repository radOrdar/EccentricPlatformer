using System;
using UnityEngine;

public class SetTriggerEveryNSeconds : MonoBehaviour
{

    public float Period = 7f;
    public Animator Animator;
    public string TriggerName = "Attack";
    private float timer;

    private void Start()
    {
        timer = Period;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > Period)
        {
            timer = 0;
            Animator.SetTrigger(TriggerName);
        }
    }
}