using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerController controller;
    public Equipment equipment;

    public ItemData itemData;
    public Action addItem;

    private void Awake()
    {
        // CharacterManager���� Player �ν��Ͻ��� �� ��ũ��Ʈ�� �����մϴ�
        CharacterManager.Instance.Player = this;

        // �� GameObject�� ������ PlayerController�� PlayerCondition, Equipment ������Ʈ�� �����ɴϴ�
        controller = GetComponent<PlayerController>();
        condition = GetComponent<PlayerCondition>();
        equipment = GetComponent<Equipment>();

        // ��ȣ�ۿ� �ݹ��� ����մϴ�
        controller.interactAction += HandleInteraction;

    }

    private void HandleInteraction()
    {
        // ���� ȭ�鿡 ��ȣ�ۿ� ������ ������Ʈ�� ������ ��ȣ�ۿ��� �����մϴ�
        if (Interaction.Instance.curInteractable != null)
        {
            Interaction.Instance.curInteractable.OnInteract();
        }
    }

}