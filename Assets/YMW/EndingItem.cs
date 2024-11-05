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
    public Ending ending;
    public ItemType type;

    private void Start()
    {
        ending = FindObjectOfType<Ending>();

        if (ending == null)
        {
            Debug.Log("null");
        }
        else
        {
            Debug.Log("ff");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerInput playerInput))
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

            Destroy(gameObject, 0.1f);
        }
    }
}
