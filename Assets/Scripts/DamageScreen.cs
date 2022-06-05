using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DamageScreen : MonoBehaviour
{
    [SerializeField] private Image DamageImage;

    public void StartEffect()
    {
        StartCoroutine(ShowEffect());
    }
    
    private IEnumerator ShowEffect()
    {
        DamageImage.enabled = true;
        Color color = DamageImage.color;
        DamageImage.gameObject.SetActive(true);
        for (float t = 1; t > 0; t -= Time.deltaTime)
        {
            color.a = t;
            DamageImage.color = color;
            yield return null;
        }

        DamageImage.enabled = false;
    }
}