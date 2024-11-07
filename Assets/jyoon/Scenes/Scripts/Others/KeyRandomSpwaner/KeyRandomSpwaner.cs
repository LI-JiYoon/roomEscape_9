using RoomEscape.Managers;
using System.Collections.Generic;
using UnityEngine;
using RoomEscape;

/// <summary>
/// ������ ��ҿ��� ������ �� ���� Key�� �����ϰ� GameManager���� Key�� ������ ��
/// </summary>
public class KeyRandomSpwaner : MonoBehaviour
{
    public GameObject keyPrefab;

    public Transform trashParent; // Trash ������Ʈ�� Transform�� �Ҵ��մϴ�.
    private List<Vector3> keyPositions = new List<Vector3>();

    

    void Start()
    {
        // Key ��ġ �޾ƿ���
        PopulateKeyPositions();

        // Ű ������ ��ġ ����
        GameObject go = Instantiate(keyPrefab, GetRandomKeyPosition(), Quaternion.identity);

        // GameManager�� Key ���� ����
        GameManager.instance.key = go.GetComponent<Key>();
    }

    // Trash ������Ʈ�� �ڽĵ��� ��ġ�� keyPositions ����Ʈ�� �����ϴ� �Լ�
    void PopulateKeyPositions()
    {
        keyPositions.Clear(); // ����Ʈ �ʱ�ȭ
        foreach (KeyLocation child in trashParent.GetComponentsInChildren<KeyLocation>())
        {
            keyPositions.Add(child.transform.position);
        }

        // �׽�Ʈ������ ��ġ ���� ����մϴ�.
        foreach (var position in keyPositions)
        {
            Debug.Log("Key Position: " + position);
        }
    }

    // ���� ��ġ�� ��ȯ�ϴ� �Լ�
    Vector3 GetRandomKeyPosition()
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
