using UnityEngine;

public class PlayerArmory : MonoBehaviour
{

    [SerializeField] private Gun[] guns;

    public int currentGun;
    
    private void Start()
    {
        TakeGunByIndex(currentGun);     
    }

    public void TakeGunByIndex(int gunIndex)
    {
        currentGun = gunIndex;
        foreach (var gun in guns)
        {
            gun.DeActivate();
        }    
        
        guns[currentGun].Activate();
    }

    public void AddBullets(int gunIndex, int numberOfBullets)
    {
        guns[gunIndex].AddBullets(numberOfBullets);
    }
}