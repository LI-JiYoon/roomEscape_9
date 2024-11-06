using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum ItemsType
{
    EscapeKey,
    ForTrueEnddingItem
}

public class EndingItem : MonoBehaviour
{
    public Ending ending;
    public ItemsType type;

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
                case ItemsType.EscapeKey:
                    ending.excapeKey = true;
                    break;

                case ItemsType.ForTrueEnddingItem:
                    ending.trueEndingItem = true;
                    break;
            }

            Destroy(gameObject, 0.1f);
        }
    }
}
