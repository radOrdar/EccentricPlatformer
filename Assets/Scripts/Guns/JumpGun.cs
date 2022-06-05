using System;
using UnityEngine;

public class JumpGun : MonoBehaviour
{

    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private float speed = 10;
    [SerializeField] private float maxCharge = 3;
    [SerializeField] private Transform spawn;
    [SerializeField] private Pistol pistol;
    [SerializeField] private ChargeIcon chargeIcon;

    private float currentCharge;
    private bool isCharged;

    private void Update()
    {
        if (isCharged)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                playerRigidbody.AddForce(-spawn.forward * speed, ForceMode.VelocityChange);
                pistol.Shot();
                currentCharge = 0;
                isCharged = false;
                chargeIcon.StartCharge();
            }
        } else
        {
            currentCharge += Time.unscaledDeltaTime;
            chargeIcon.SetChargeValue(currentCharge, maxCharge);
            if (currentCharge >= maxCharge)
            {
                isCharged = true;
                chargeIcon.StopCharge();
            }
        }
    }
}