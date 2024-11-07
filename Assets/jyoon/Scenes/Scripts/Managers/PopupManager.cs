using TMPro;
using UnityEngine;

public class PopupManager : MonoBehaviour
{
    public static PopupManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void ShowPopup(GameObject popup)
    {
        popup.SetActive(true);
    }

    public void HidePopup(GameObject popup)
    {
        popup.SetActive(false);
    }
    public GameObject CreateMessagePopup(string message)
    {
        // 임시로 메시지 팝업을 생성하는 메서드를 구현합니다
        GameObject popup = new GameObject("MessagePopup");
        TextMeshProUGUI textComponent = popup.AddComponent<TextMeshProUGUI>();
        textComponent.text = message;
        return popup;
    }
}
