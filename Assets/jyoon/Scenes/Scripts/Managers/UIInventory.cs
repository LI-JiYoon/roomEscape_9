using RoomEscape.Managers;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

// UIInventory 클래스: 인벤토리 UI를 관리하는 클래스
public class UIInventory : MonoBehaviour
{
    // 인벤토리 슬롯 배열
    public ItemSlot[] slots;

    // 인벤토리 UI 창 및 슬롯 패널, 아이템 드롭 위치
    public GameObject inventoryWindow;
    public Transform slotPanel;
    public Transform dropPosition;

    [Header("Selected Item")]
    private ItemSlot selectedItem;        // 현재 선택된 아이템 슬롯
    private int selectedItemIndex;        // 현재 선택된 아이템의 인덱스
    public TextMeshProUGUI selectedItemName;        // 선택된 아이템의 이름
    public TextMeshProUGUI selectedItemDescription; // 선택된 아이템의 설명
    public TextMeshProUGUI selectedItemStatName;    // 선택된 아이템의 스탯 이름
    public TextMeshProUGUI selectedItemStatValue;   // 선택된 아이템의 스탯 값
    public GameObject useButton;           // "사용" 버튼
    public GameObject equipButton;         // "장착" 버튼
    public GameObject unEquipButton;       // "장착 해제" 버튼
    public GameObject dropButton;          // "드롭" 버튼

    private int curEquipIndex;             // 현재 장착된 아이템의 인덱스

    private PlayerController controller;   // 플레이어 컨트롤러 참조
   
    // 초기 설정 메서드
    void Start()
    {
        // 플레이어 관련 컴포넌트 참조
        controller = CharacterManager.Instance.Player.controller;
       

        // 인벤토리 열기/닫기 이벤트 연결
        controller.inventory += Toggle;
        CharacterManager.Instance.Player.addItem += AddItem;

        // 인벤토리 UI 비활성화 및 슬롯 초기화
        inventoryWindow.SetActive(false);
        slots = new ItemSlot[slotPanel.childCount];

        // 각 슬롯 초기화 설정
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = slotPanel.GetChild(i).GetComponent<ItemSlot>();
            slots[i].index = i;
            slots[i].inventory = this;
            slots[i].Clear();
        }

        // 선택된 아이템 정보 초기화
        ClearSelectedItemWindow();
    }

    // 인벤토리 창을 열거나 닫는 메서드
    public void Toggle()
    {
        if (inventoryWindow.activeInHierarchy)
        {
            inventoryWindow.SetActive(false);
        }
        else
        {
            inventoryWindow.SetActive(true);
        }
    }

    // 인벤토리 창이 열려 있는지 확인하는 메서드
    public bool IsOpen()
    {
        return inventoryWindow.activeInHierarchy;
    }

    // 아이템 추가 메서드
    public void AddItem()
    {
        ItemData data = CharacterManager.Instance.Player.itemData;

        //// 스택 가능한 아이템일 경우 처리
        //if (data.canStack)
        //{
        //    ItemSlot slot = GetItemStack(data);
        //    if (slot != null)
        //    {
        //        slot.quantity++;
        //        UpdateUI();
        //        CharacterManager.Instance.Player.itemData = null;
        //        return;
        //    }
        //}

        // 빈 슬롯에 아이템 추가
        ItemSlot emptySlot = GetEmptySlot();
        if (emptySlot != null)
        {
            emptySlot.item = data;
            emptySlot.quantity = 1;
            UpdateUI();
            CharacterManager.Instance.Player.itemData = null;
            return;
        }

        //// 빈 슬롯이 없을 경우 아이템을 드롭
        //ThrowItem(data);
        //CharacterManager.Instance.Player.itemData = null;
    }

    //// 아이템을 드롭하는 메서드
    //public void ThrowItem(ItemData data)
    //{
    //    Instantiate(data.dropPrefab, dropPosition.position, Quaternion.Euler(Vector3.one * Random.value * 360));
    //}

    // UI 업데이트 메서드: 모든 슬롯을 갱신
    public void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item != null)
            {
                slots[i].Set();
            }
            else
            {
                slots[i].Clear();
            }
        }
    }

    //// 주어진 아이템의 스택을 찾는 메서드
    //ItemSlot GetItemStack(ItemData data)
    //{
    //    for (int i = 0; i < slots.Length; i++)
    //    {
    //        if (slots[i].item == data && slots[i].quantity < data.maxStackAmount)
    //        {
    //            return slots[i];
    //        }
    //    }
    //    return null;
    //}

    // 빈 슬롯을 찾는 메서드
    ItemSlot GetEmptySlot()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].item == null)
            {
                return slots[i];
            }
        }
        return null;
    }

    // 아이템을 선택하는 메서드
    public void SelectItem(int index)
    {
        if (slots[index].item == null) return;

        selectedItem = slots[index];
        selectedItemIndex = index;

        // 선택된 아이템 정보 갱신
        selectedItemName.text = selectedItem.item.displayName;
        selectedItemDescription.text = selectedItem.item.description;

        //selectedItemStatName.text = string.Empty;
        //selectedItemStatValue.text = string.Empty;

        //// 소비 아이템 속성 업데이트
        //for (int i = 0; i < selectedItem.item.consumables.Length; i++)
        //{
        //    selectedItemStatName.text += selectedItem.item.consumables[i].type.ToString() + "\n";
        //    selectedItemStatValue.text += selectedItem.item.consumables[i].value.ToString() + "\n";
        //}

        // 버튼 상태 업데이트
        useButton.SetActive(selectedItem.item.type == ItemType.Consumable);
        equipButton.SetActive(selectedItem.item.type == ItemType.Equipable && !slots[index].equipped);
        unEquipButton.SetActive(selectedItem.item.type == ItemType.Equipable && slots[index].equipped);
        dropButton.SetActive(true);
    }

    // 선택된 아이템 정보를 초기화하는 메서드
    void ClearSelectedItemWindow()
    {
        selectedItem = null;

        selectedItemName.text = string.Empty;
        selectedItemDescription.text = string.Empty;
        selectedItemStatName.text = string.Empty;
        selectedItemStatValue.text = string.Empty;

        useButton.SetActive(false);
        equipButton.SetActive(false);
        unEquipButton.SetActive(false);
        dropButton.SetActive(false);
    }

    // "사용" 버튼 클릭 시 호출되는 메서드
    public void OnUseButton()
    {
        //if (selectedItem.item.type == ItemType.Consumable)
        //{
        //    for (int i = 0; i < selectedItem.item.consumables.Length; i++)
        //    {
        //        switch (selectedItem.item.consumables[i].type)
        //        {
        //            case ConsumableType.Health:
        //                condition.Heal(selectedItem.item.consumables[i].value); break;
        //            case ConsumableType.Hunger:
        //                condition.Eat(selectedItem.item.consumables[i].value); break;
        //        }
        //    }
        //    RemoveSelctedItem();
        //}
    }

    //// "드롭" 버튼 클릭 시 호출되는 메서드
    //public void OnDropButton()
    //{
    //    ThrowItem(selectedItem.item);
    //    RemoveSelctedItem();
    //}

    // 선택된 아이템을 인벤토리에서 제거하는 메서드
    void RemoveSelctedItem()
    {
        selectedItem.quantity--;

        if (selectedItem.quantity <= 0)
        {
            if (slots[selectedItemIndex].equipped)
            {
                //UnEquip(selectedItemIndex);
            }

            selectedItem.item = null;
            ClearSelectedItemWindow();
        }

        UpdateUI();
    }

    // 특정 아이템이 인벤토리에 있는지 확인하는 메서드 (미구현)
    public bool HasItem(ItemData item, int quantity)
    {
        return false;
    }
}
