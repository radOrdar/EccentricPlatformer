using System.Collections;
using UnityEngine;

public class Blink : MonoBehaviour
{
    [SerializeField] private Renderer[] renderers;

    public void StartEffect()
    {
        StartCoroutine(nameof(BlinkRoutine));
    }

    private IEnumerator BlinkRoutine()
    {
        for (float t = 0; t < 1; t += Time.deltaTime)
        {
            foreach (var renderer in renderers)
            {
                foreach (var material in renderer.materials)
                {
                    material.SetColor("_EmissionColor", new Color(Mathf.Sin(t * 30) * 0.5f + 0.5f, 0, 0, 0));
                }
            }

            yield return null;
        }
    }
}