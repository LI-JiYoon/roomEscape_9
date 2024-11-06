using UnityEngine;

public interface IInteractable
{
    // 상호작용 프롬프트 텍스트를 가져오는 메소드
    string GetInteractPrompt();

    // 상호작용 로직을 처리하는 메소드
    void OnInteract();
}

public abstract class InteractableObject : MonoBehaviour, IInteractable
{
    public abstract string GetInteractPrompt();
    public abstract void OnInteract();

    

}
