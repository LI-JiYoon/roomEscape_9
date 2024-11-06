using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance { get; private set; }
    private string saveFilePath;

    private HashSet<string> acquiredItems = new HashSet<string>(); // ȹ���� �����۵��� ID�� �����ϴ� �ؽü�
    private HashSet<string> openedDoors = new HashSet<string>(); // �� ������ �̸��� �����ϴ� �ؽü�
    private HashSet<string> solvedPuzzles = new HashSet<string>(); // �ذ��� ������� �̸��� �����ϴ� �ؽü�

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            saveFilePath = Path.Combine(Application.persistentDataPath, "savegame.json");
            LoadProgress(); // ���� ���� �����͸� �ε��մϴ�
        }
        else
        {
            Destroy(gameObject);
        }
    }

    [System.Serializable]
    public class SaveData
    {
        public List<string> acquiredItems; // ȹ���� ������ ID ���
        public List<string> openedDoors; // �� ������ �̸� ���
        public List<string> solvedPuzzles; // �ذ��� ������� �̸� ���
    }

    // ������ ȹ�� �� ���� ��Ȳ�� �����մϴ�
    public void SaveItemAcquired(string itemName)
    {
        acquiredItems.Add(itemName);
        SaveProgress(); // ���� ��Ȳ�� �����մϴ�
    }

    // ���� ������ �� ���� ��Ȳ�� �����մϴ�
    public void SaveDoorOpened(string doorName)
    {
        openedDoors.Add(doorName);
        SaveProgress(); // ���� ��Ȳ�� �����մϴ�
    }

    // ������ �ذ����� �� ���� ��Ȳ�� �����մϴ�
    public void SavePuzzleSolved(string puzzleName)
    {
        solvedPuzzles.Add(puzzleName);
        SaveProgress(); // ���� ��Ȳ�� �����մϴ�
    }

    // ���� ���� ��Ȳ�� JSON �������� �����մϴ�
    private void SaveProgress()
    {
        SaveData saveData = new SaveData
        {
            acquiredItems = new List<string>(acquiredItems),
            openedDoors = new List<string>(openedDoors),
            solvedPuzzles = new List<string>(solvedPuzzles)
        };

        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText(saveFilePath, json); // ���� ���Ͽ� JSON �����͸� ���ϴ�
    }

    // ����� ���� ��Ȳ�� �ҷ��ɴϴ�
    private void LoadProgress()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            SaveData saveData = JsonUtility.FromJson<SaveData>(json);

            // �ε��� �����͸� �ؽü¿� �����մϴ�
            acquiredItems = new HashSet<string>(saveData.acquiredItems);
            openedDoors = new HashSet<string>(saveData.openedDoors);
            solvedPuzzles = new HashSet<string>(saveData.solvedPuzzles);
        }
    }

    // �������� ȹ��Ǿ����� Ȯ���մϴ�
    public bool IsItemAcquired(string itemName)
    {
        return acquiredItems.Contains(itemName);
    }

    // ���� ���ȴ��� Ȯ���մϴ�
    public bool IsDoorOpened(string doorName)
    {
        return openedDoors.Contains(doorName);
    }

    // ������ �ذ�Ǿ����� Ȯ���մϴ�
    public bool IsPuzzleSolved(string puzzleName)
    {
        return solvedPuzzles.Contains(puzzleName);
    }
}