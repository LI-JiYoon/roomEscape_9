using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


namespace RoomEscape.Managers
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        // ç���� 2���� ������ ���� ���� ����
        // MonoBehaviour �� ��ӹ��� T Ŭ������ �ν��Ͻ�
        private static T _instance;
        // get ���� Init �Լ��� �����ϰ� _instance �� ��ȯ
        public static T Instance { get { Initialize(); return _instance; } }
        // Init �Լ����� _instance �� null �� �� ����
        // �ʱ�ȭ
        private static void Initialize()
        {
            if (_instance == null)
            {
                // typeof(T) �� T Ŭ������ Type �� ��ȯ
                string name = typeof(T).Name;
                // GameObject �� �����ϰ� T Ŭ������ �߰�
                GameObject go = new GameObject { name = name };
                // T Ŭ������ �߰��ϰ� _instance �� �Ҵ�
                _instance = go.AddComponent<T>();
                // ���� ����Ǿ �������� �ʵ��� ����
                DontDestroyOnLoad(go);
            }
        }

        public virtual void Init()
        {
            Debug.Log($"{typeof(T).Name} Init");
        }
    }
}