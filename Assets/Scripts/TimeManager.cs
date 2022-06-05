using UnityEngine;

public class TimeManager : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Time.timeScale = 0.2f;
        } else
        {
            Time.timeScale = 1f;
        }
    }
}