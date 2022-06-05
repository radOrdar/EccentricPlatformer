using System;
using UnityEngine;
using UnityEngine.UI;

public class Automat : Gun
{
    [SerializeField] private int numberOfBullets;
    [SerializeField] private Text bulletText;
    [SerializeField] private PlayerArmory playerArmory;

    public override void DeActivate()
    {
        bulletText.enabled = false;
        base.DeActivate();
    }

    public override void Activate()
    {
        bulletText.enabled = true;
        UpdateText();
        base.Activate();
    }

    public override void AddBullets(int amount)
    {
        base.AddBullets(amount);
        numberOfBullets += amount;
        playerArmory.TakeGunByIndex(1);
        UpdateText();
    }

    public override void Shot()
    {
        if (numberOfBullets <= 0)
        {
            playerArmory.TakeGunByIndex(0);
            return;
        }
        numberOfBullets--;
        UpdateText();
        base.Shot();
    }

    private void UpdateText()
    {
        bulletText.text = numberOfBullets.ToString();
    }
}