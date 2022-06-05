using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject buttonMenu;
    [SerializeField] private GameObject windowMenu;

    [SerializeField] private MonoBehaviour[] componentsToDisable;

    public void OpenMenuWindow()
    {
        buttonMenu.SetActive(false);
        windowMenu.SetActive(true);
        foreach (var behaviour in componentsToDisable)
        {
            behaviour.enabled = false;
        }

        Time.timeScale = 0.01f;
    }
    
    public void CloseMenuWindow()
    {
        buttonMenu.SetActive(true);
        windowMenu.SetActive(false);
        foreach (var behaviour in componentsToDisable)
        {
            behaviour.enabled = true;
        }
        
        Time.timeScale = 1f;
    }
    
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}