using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

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

    public void ShowErrorMessage(string message)
    {
        PopupManager.Instance.ShowPopup(PopupManager.Instance.CreateMessagePopup(message));
    }
}
