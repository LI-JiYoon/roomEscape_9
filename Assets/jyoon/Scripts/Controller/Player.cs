using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;


    public ItemData itemData;
    public Action addItem;

    private void Awake()
    {
        CharacterManager.Instance.Player = this;
        controller = GetComponent<PlayerController>();
      
    }
}