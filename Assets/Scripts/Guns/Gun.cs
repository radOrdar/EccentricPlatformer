using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField] private float BulletSpeed = 10f;
    [SerializeField] private float ShotPeriod = 0.2f;

    [SerializeField] private GameObject BulletPf;
    [SerializeField] private Transform Spawn;
    [SerializeField] private AudioSource shotAudio;
    [SerializeField] private GameObject MuzzleFlash;
    [SerializeField] private ParticleSystem shotEffect;

    private float lastShotTime;

    private void Update()
    {
        if (Input.GetMouseButton(0) && (Time.time - lastShotTime) / Time.timeScale  > ShotPeriod)
        {
            Shot();
        }
    }

    public virtual void Activate()
    {
        gameObject.SetActive(true);
    }

    public virtual void DeActivate()
    {
        gameObject.SetActive(false);
    }
    
    public virtual void AddBullets(int amount) {}
    
    public virtual void Shot()
    {
        GameObject newBullet = Instantiate(BulletPf, Spawn.position, Spawn.rotation);
        newBullet.GetComponent<Rigidbody>().velocity = Spawn.forward * BulletSpeed;
        lastShotTime = Time.time;
        shotAudio.Play();
        MuzzleFlash.SetActive(true);
        shotEffect.Play();
        Invoke(nameof(HideMuzzleFlash), 0.12f);
    }


    private void HideMuzzleFlash()
    {
        MuzzleFlash.SetActive(false);
    }
}