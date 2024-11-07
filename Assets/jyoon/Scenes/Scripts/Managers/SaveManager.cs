using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; private set; }
    private string saveFilePath;

    private HashSet<string> acquiredItems = new HashSet<string>(); // 획득한 아이템들의 ID를 저장하는 해시셋
    private HashSet<string> openedDoors = new HashSet<string>(); // 연 문들의 이름을 저장하는 해시셋
    private HashSet<string> solvedPuzzles = new HashSet<string>(); // 해결한 퍼즐들의 이름을 저장하는 해시셋

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            saveFilePath = Path.Combine(Application.persistentDataPath, "savegame.json");
            LoadProgress(); // 게임 진행 데이터를 로드합니다
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [System.Serializable]
    public class SaveData
    {
        public List<string> acquiredItems; // 획득한 아이템 ID 목록
        public List<string> openedDoors; // 연 문들의 이름 목록
        public List<string> solvedPuzzles; // 해결한 퍼즐들의 이름 목록
    }

    // 아이템 획득 시 진행 상황을 저장합니다
    public void SaveItemAcquired(string itemName)
    {
        acquiredItems.Add(itemName);
        SaveProgress(); // 진행 상황을 저장합니다
    }

    // 문을 열었을 때 진행 상황을 저장합니다
    public void SaveDoorOpened(string doorName)
    {
        openedDoors.Add(doorName);
        SaveProgress(); // 진행 상황을 저장합니다
    }

    // 퍼즐을 해결했을 때 진행 상황을 저장합니다
    public void SavePuzzleSolved(string puzzleName)
    {
        solvedPuzzles.Add(puzzleName);
        SaveProgress(); // 진행 상황을 저장합니다
    }

    // 현재 진행 상황을 JSON 형식으로 저장합니다
    private void SaveProgress()
    {
        SaveData saveData = new SaveData
        {
            acquiredItems = new List<string>(acquiredItems),
            openedDoors = new List<string>(openedDoors),
            solvedPuzzles = new List<string>(solvedPuzzles)
        };

        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(saveFilePath, json); // 저장 파일에 JSON 데이터를 씁니다
    }

    // 저장된 진행 상황을 불러옵니다
    private void LoadProgress()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            // 로드한 데이터를 해시셋에 저장합니다
            acquiredItems = new HashSet<string>(saveData.acquiredItems);
            openedDoors = new HashSet<string>(saveData.openedDoors);
            solvedPuzzles = new HashSet<string>(saveData.solvedPuzzles);
        }
    }

    // 아이템이 획득되었는지 확인합니다
    public bool IsItemAcquired(string itemName)
    {
        return acquiredItems.Contains(itemName);
    }

    // 문이 열렸는지 확인합니다
    public bool IsDoorOpened(string doorName)
    {
        return openedDoors.Contains(doorName);
    }

    // 퍼즐이 해결되었는지 확인합니다
    public bool IsPuzzleSolved(string puzzleName)
    {
        return solvedPuzzles.Contains(puzzleName);
    }
}