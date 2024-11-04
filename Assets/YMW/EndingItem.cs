using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum ItemType
{
    EscapeKey,
    ForTrueEnddingItem
}

public class EndingItem : MonoBehaviour
{
    Ending ending;
    public ItemType type;

    private void Start()
    {
        ending = FindObjectOfType<Ending>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (TryGetComponent(out PlayerInput playerInput))
        {
            switch (type)
            {
                case ItemType.EscapeKey:
                    ending.excapeKey = true;
                    break;

                case ItemType.ForTrueEnddingItem:
                    ending.trueEndingItem = true;
                    break;
            }
        }
    }
}
