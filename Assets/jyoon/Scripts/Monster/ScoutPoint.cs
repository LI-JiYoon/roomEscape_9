using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoutPoint : MonoBehaviour
{
    public bool isStartPosition;


    private void Awake()
    {

    }

    private void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //if(other.TryGetComponent(out Monster monster))
        //{
        //    if (monster.targetTransform == transform)
        //    {
        //        Debug.Log("Toggle");
        //        monster.ToggleDestination();
        //    }
        //}
    }
}
