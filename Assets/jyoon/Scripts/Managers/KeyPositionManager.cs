using System.Collections.Generic;
using UnityEngine;

public class KeyPositionManager : MonoBehaviour
{
    public Transform trashParent; // Trash 오브젝트의 Transform을 할당합니다.
    private List<Vector3> keyPositions = new List<Vector3>();

    void Start()
    {
        PopulateKeyPositions();
        // 테스트용으로 위치 값을 출력합니다.
        foreach (var position in keyPositions)
        {
            Debug.Log("Key Position: " + position);
        }
    }

    // Trash 오브젝트의 자식들의 위치를 keyPositions 리스트에 저장하는 함수
   public void PopulateKeyPositions()
    {
        keyPositions.Clear(); // 리스트 초기화
        foreach (Transform child in trashParent)
        {
            keyPositions.Add(child.position);
        }
    }

    // 랜덤 위치를 반환하는 함수
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
