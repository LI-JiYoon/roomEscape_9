
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public GameObject itemPrefab;
    public Transform[] spawnPoints;
    private List<GameObject> activeItems = new List<GameObject>();

    void Start()
    {
        GenerateItems();
    }

    void GenerateItems()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            GameObject item = Instantiate(itemPrefab, spawnPoint.position, Quaternion.identity);
            activeItems.Add(item);
        }
    }

    void ManageItems()
    {
        // Implement Item Management Logic
    }

    void ManageInteractableObjects()
    {
        // Implement Interactable Object Management Logic
    }
}
