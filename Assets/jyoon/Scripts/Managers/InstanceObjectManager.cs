using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class InstanceObjectManager : MonoBehaviour
//{
//    public static InstanceObjectManager Instance;

//    public List<Transform> 의자위치;
//    public List<Transform> 소파위치;
//    public List<Transform> 책상위치;
//    public List<Key> 열쇠위치;
//    public Transform 고정된열쇠위치;

//    public List<GameObject> 열쇠_prefab;
//    public List<GameObject> 의자_prefab;
//    public List<GameObject> 소파_prefab;


//    public List<GameObject> 생성된책상;

//    public void StartInstace() 
//    {
//        // 책상소환
//        int 열쇠위치_idx = UnityEngine.Random.Range(0, 열쇠위치.Count);

//        int 열쇠Prefab_idx = UnityEngine.Random.Range(0, 열쇠_prefab.Count);
//        GameObject go = Instantiate(열쇠_prefab[열쇠Prefab_idx]);
//        go.transform.position = 열쇠위치[열쇠위치_idx].transform.position;

//        // 소환된 책상안에 열쇠위치정보 가져와서 
//        Key kkk = GetComponentInChildren<Key>();
//        열쇠위치.Add(kkk);
//        // 열쇠 생성
//    }
//}
