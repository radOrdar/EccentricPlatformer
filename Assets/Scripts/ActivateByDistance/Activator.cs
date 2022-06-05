using System.Collections.Generic;
using UnityEngine;

public class Activator : MonoBehaviour
{
    [SerializeField] private List<ActivateByDistance> objectsToActivate = new();
    private Transform playerTransform;

    private void Start()
    {
        playerTransform = FindObjectOfType<PlayerMove>().transform;
    }

    private void Update()
    {
        foreach (var obj in objectsToActivate)
        {
            obj.CheckDistance(playerTransform.position);
        }
    }

    public void Register(ActivateByDistance candidate)
    {
        objectsToActivate.Add(candidate);
    }

    public void Deregister(ActivateByDistance candidate)
    {
        objectsToActivate.Remove(candidate);
    }
}