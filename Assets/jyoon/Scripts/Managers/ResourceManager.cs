//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using Unity.VisualScripting;
//using UnityEngine;

//public class ResourceManager : Singleton<ResourceManager>
//{
//    private Dictionary<string, GameObject> itemPrefabs;
//    public int ItemCount => itemPrefabs?.Count ?? 0;

//    public override void Init()
//    {
//        base.Init();
//        if (itemPrefabs == null)
//        {
//            itemPrefabs = new Dictionary<string, GameObject>();
//            GameObject[] prefabs = Resources.LoadAll<GameObject>("Prefabs/Items");
//            foreach (GameObject prefab in prefabs)
//            {
//                itemPrefabs.Add(prefab.name, prefab);
//            }
//        }
//    }

//    public GameObject LoadUI(string name, Transform parent = null)
//    {
//        return Load($"UIs/{name}", parent);
//    }

//    public GameObject LoadItem(string name, Transform parent = null)
//    {
//        if (itemPrefabs.TryGetValue(name, out GameObject prefab) == false)
//        {
//            Debug.LogError($"Failed to load item: {name}");
//            return null;
//        }

//        GameObject go = Instantiate(prefab, parent);
//        go.name = name;
//        return go;
//    }

//    public GameObject LoadItem(int itemIndex)
//    {
//        string key = itemPrefabs.Keys.ToArray()[itemIndex];
//        return LoadItem(key);
//    }

//    public AudioClip LoadSound(SoundType soundType, AudioClipType clipType)
//    {
//        return Resources.Load<AudioClip>($"Sounds/{soundType.ToString().ToLower()}/{clipType}");
//    }

//    public GameObject Load(string name, Transform parent = null)
//    {
//        GameObject prefab = Resources.Load<GameObject>($"Prefabs/{name}");
//        if (prefab == null)
//        {
//            Debug.LogError($"Failed to load prefab: {name}");
//            return null;
//        }

//        GameObject go = Instantiate(prefab, parent);
//        go.name = name;
//        return go;
//    }
//}