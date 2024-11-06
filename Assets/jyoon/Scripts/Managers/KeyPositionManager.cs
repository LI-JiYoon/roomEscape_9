using System.Collections.Generic;
using UnityEngine;

public class KeyPositionManager : MonoBehaviour
{
    public Transform trashParent; // Trash ������Ʈ�� Transform�� �Ҵ��մϴ�.
    private List<Vector3> keyPositions = new List<Vector3>();

    void Start()
    {
        PopulateKeyPositions();
        // �׽�Ʈ������ ��ġ ���� ����մϴ�.
        foreach (var position in keyPositions)
        {
            Debug.Log("Key Position: " + position);
        }
    }

    // Trash ������Ʈ�� �ڽĵ��� ��ġ�� keyPositions ����Ʈ�� �����ϴ� �Լ�
   public void PopulateKeyPositions()
    {
        keyPositions.Clear(); // ����Ʈ �ʱ�ȭ
        foreach (Transform child in trashParent)
        {
            keyPositions.Add(child.position);
        }
    }

    // ���� ��ġ�� ��ȯ�ϴ� �Լ�
    public Vector3 GetRandomKeyPosition()
    {
        if (keyPositions.Count == 0)
        {
            Debug.LogWarning("Key positions list is empty.");
            return Vector3.zero;
        }

        int randomIndex = Random.Range(0, keyPositions.Count);
        return keyPositions[randomIndex];
    }
}
