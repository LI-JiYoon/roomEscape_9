using System.IO; 
using UnityEngine;

public class SaveLoadManager : MonoBehaviour
{
    public static SaveLoadManager Instance { get; private set; }
    public GameObject player;
    private string saveFilePath;
    //public Inventory inventory

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            saveFilePath = Application.persistentDataPath + "/savedata.json";
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SaveGame()
    {
        GameData data = new GameData();
        data.playerPosition = player.transform.position;  // 현재 플레이어 위치 저장
        //data.collectedItems = inventory.items();  //인벤토리 

        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(saveFilePath, json);
        Debug.Log("저장 완료");
    }

    public void LoadGame()
    {
        if (File.Exists(saveFilePath))
        {
            string json = File.ReadAllText(saveFilePath);
            GameData data = JsonUtility.FromJson<GameData>(json);

            player.transform.position = data.playerPosition;  // 플레이어 위치 로드
          //inventory.LoadCollectedItems(data.collectedItems);  // 아이템
            Debug.Log("불러오기 완료");

        }
    }
}
