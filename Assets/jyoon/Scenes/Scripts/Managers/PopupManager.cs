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
        // �ӽ÷� �޽��� �˾��� �����ϴ� �޼��带 �����մϴ�
        GameObject popup = new GameObject("MessagePopup");
        TextMeshProUGUI textComponent = popup.AddComponent<TextMeshProUGUI>();
        textComponent.text = message;
        return popup;
    }
}