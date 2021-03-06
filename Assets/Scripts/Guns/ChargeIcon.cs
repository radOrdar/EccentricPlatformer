using UnityEngine;
using UnityEngine.UI;

public class ChargeIcon : MonoBehaviour
{
    [SerializeField] private Image background;
    [SerializeField] private Image foreground;
    [SerializeField] private Text text;

    public void StartCharge()
    {
        background.color = new Color(1f, 1f, 1f, 0.2f);
        foreground.enabled = true;
        text.enabled = true;
    }

    public void StopCharge()
    {
        background.color = new Color(1f, 1f, 1f, 1f);
        foreground.enabled = false;
        text.enabled = false;
    }

    public void SetChargeValue(float currentCharge, float maxCharge)
    {
        foreground.fillAmount = currentCharge / maxCharge;
        text.text = Mathf.Ceil(maxCharge - currentCharge).ToString();
    }
}