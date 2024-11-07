using UnityEngine;
public abstract class InteractableObject : MonoBehaviour, IInteractable
{
    public abstract string GetInteractPrompt();
    public abstract void OnInteract();



}

public interface IInteractable
{
    // ��ȣ�ۿ� ������Ʈ �ؽ�Ʈ�� �������� �޼ҵ�
    string GetInteractPrompt();

    // ��ȣ�ۿ� ������ ó���ϴ� �޼ҵ�
    void OnInteract();
}

