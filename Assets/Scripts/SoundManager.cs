using UnityEngine;

public class SoundManager : MonoBehaviour
{

    [SerializeField] public AudioSource music;

    public void SetMusicEnabled(bool value)
    {
        music.enabled = value;
    }

    public void SetVolume(float value)
    {
        music.volume = value;
    }
}