using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoutPoint : MonoBehaviour
{
    public bool isStartPosition;

    MeshRenderer meshRenderer;


    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    private void Start()
    {
        meshRenderer.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Monster monster))
        {
            if (monster.targetTransform == transform)
            {
                Debug.Log("Toggle");
                monster.ToggleDestination();
            }
        }
    }
}
