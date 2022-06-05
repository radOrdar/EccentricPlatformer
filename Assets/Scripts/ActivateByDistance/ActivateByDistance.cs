#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class ActivateByDistance : MonoBehaviour
{
    [SerializeField] private float DistanceToActivate = 20f;
    private bool isActive = true;
    private Activator activator;

    private void Start()
    {
        activator = GetComponentInParent<Activator>();
        activator.Register(this);
    }

    public void CheckDistance(Vector3 playerPosition)
    {
        float distance = Vector3.Distance(transform.position, playerPosition);

        if (isActive)
        {
            if (distance > DistanceToActivate + 2f)
            {
                Deactivate();
            }
        } else
        {
            if (distance < DistanceToActivate)
            {
                Activate();
            }
        }
    }

    private void Activate()
    {
        isActive = true;
        gameObject.SetActive(true);
    }

    private void Deactivate()
    {
        isActive = false;
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        activator.Deregister(this);
    }

#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.red;
        Handles.DrawWireDisc(transform.position, Vector3.forward, DistanceToActivate);
    }
#endif
}