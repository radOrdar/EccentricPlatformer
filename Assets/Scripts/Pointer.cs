using UnityEngine;

public class Pointer : MonoBehaviour
{
    public Transform AimTransform;
    
    private Camera MainCamera;

    private void Start()
    {
        MainCamera = Camera.main;
    }

    private void LateUpdate()
    {
        Plane plane = new Plane(Vector3.forward, Vector3.zero);
        Ray ray = MainCamera.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out float distance))
        {
            AimTransform.position = ray.GetPoint(distance);
        }
        
        transform.LookAt(AimTransform);
    }
}