using RoomEscape.Managers;
using System.Collections.Generic;
using UnityEngine;
using RoomEscape;

/// <summary>
/// 지정된 장소에서 랜덤한 한 곳에 Key를 생성하고 GameManager에게 Key의 정보를 줌
/// </summary>
public class KeyRandomSpwaner : MonoBehaviour
{
    public GameObject keyPrefab;

    public Transform trashParent; // Trash 오브젝트의 Transform을 할당합니다.
    private List<Vector3> keyPositions = new List<Vector3>();

    

    void Start()
    {
        // Key 위치 받아오기
        PopulateKeyPositions();

        // 키 생성과 위치 지정
        GameObject go = Instantiate(keyPrefab, GetRandomKeyPosition(), Quaternion.identity);

        // GameManager에 Key 정보 전달
        GameManager.instance.key = go.GetComponent<Key>();
    }

    // Trash 오브젝트의 자식들의 위치를 keyPositions 리스트에 저장하는 함수
    void PopulateKeyPositions()
    {
        keyPositions.Clear(); // 리스트 초기화
        foreach (KeyLocation child in trashParent.GetComponentsInChildren<KeyLocation>())
        {
            keyPositions.Add(child.transform.position);
        }

        // 테스트용으로 위치 값을 출력합니다.
        foreach (var position in keyPositions)
        {
            Debug.Log("Key Position: " + position);
        }
    }

    // 랜덤 위치를 반환하는 함수
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
