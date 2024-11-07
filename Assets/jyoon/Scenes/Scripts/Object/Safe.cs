using TMPro;
using UnityEngine;

public class Safe : InteractableObject
{
    public GameObject safeUI;
    public TMP_InputField inputField;
    public string correctCode = "할로윈";
    public ItemData rewardItem;

    // 금고와 상호작용할 때 표시할 프롬프트 텍스트를 가져옵니다
    public override string GetInteractPrompt()
    {
        return "Press 'E' to enter code.";
    }

    // 금고와의 상호작용을 처리합니다
    public override void OnInteract()
    {
        // 금고 코드를 입력할 수 있는 UI를 PopupManager를 통해 활성화합니다
        PopupManager.Instance.ShowPopup(safeUI);
    }

    // 입력된 코드 확인
    public void OnSubmitCode()
    {
        if (inputField.text == correctCode)
        {
            // 정답이 맞으면 보상 아이템을 인벤토리에 추가합니다
            Player player = CharacterManager.Instance.Player;
            player.itemData = rewardItem;
            player.addItem?.Invoke();

            // Save progress
            SaveManager.Instance.SavePuzzleSolved(gameObject.name);

            // 금고 UI 닫기
            PopupManager.Instance.HidePopup(safeUI);
        }
        else
        {
            // 정답이 틀리면 오류 메시지 팝업
            //UIManager.Instance.ShowErrorMessage("정답과 다릅니다");
        }
    }
}
