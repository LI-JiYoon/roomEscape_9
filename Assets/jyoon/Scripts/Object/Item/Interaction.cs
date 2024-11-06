using TMPro;
using UnityEngine;


public class Interaction : MonoBehaviour
{
    public static Interaction Instance;

    public float checkRate = 0.05f; // ��ȣ�ۿ� ������ ������Ʈ�� �󸶳� ���� üũ���� �����մϴ�
    private float lastCheckTime;
    public float maxCheckDistance; // ��ȣ�ۿ� üũ �ִ� �Ÿ�
    public LayerMask layerMask; // ��ȣ�ۿ� ������ ������Ʈ�� ���̾ �����մϴ�

    public GameObject curInteractGameObject; // ���� ȭ�鿡 �ִ� ��ȣ�ۿ� ������ ������Ʈ
    public IInteractable curInteractable; // ���� ȭ�鿡 �ִ� ��ȣ�ۿ� ������ ������Ʈ

    public TextMeshProUGUI promptText; // ��ȣ�ۿ� ������Ʈ UI �ؽ�Ʈ
    private Camera camera; // ���� ī�޶� ����

    private void Awake()
    {
        // �ٸ� ��ũ��Ʈ���� ���� ������ �� �ֵ��� �� �ν��Ͻ��� �����մϴ�
        Instance = this;
    }

    void Start()
    {
        // ���� ī�޶� ������ �����ɴϴ�
        camera = Camera.main;
    }
    void Update()
    {
        // ���������� ��ȣ�ۿ� ������ ������Ʈ�� üũ�մϴ�
        if (Time.time - lastCheckTime > checkRate)
        {
            lastCheckTime = Time.time;

            // ȭ���� �߾ӿ��� ���̸� ���� ��ȣ�ۿ� ������ ������Ʈ�� üũ�մϴ�
            Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxCheckDistance, layerMask))
            {
                // ��Ʈ�� ������Ʈ�� ���� ��ȣ�ۿ� ������Ʈ�� �ٸ��� ������Ʈ�մϴ�
                if (hit.collider.gameObject != curInteractGameObject)
                {
                    curInteractGameObject = hit.collider.gameObject;
                    curInteractable = hit.collider.GetComponent<IInteractable>();
                    SetPromptText();
                }
            }
            else
            {
                // ��ȣ�ۿ� ������ ������Ʈ�� ã�� ���� ��� ���� ��ȣ�ۿ� ������Ʈ�� ����ϴ�
                curInteractGameObject = null;
                curInteractable = null;
                promptText.gameObject.SetActive(false);
            }
        }
    }

    // ���� ��ȣ�ۿ� ������ ������Ʈ�� ���� ������Ʈ �ؽ�Ʈ�� �����մϴ�
    private void SetPromptText()
    {
        if (curInteractable != null)
        {
            promptText.gameObject.SetActive(true);
            promptText.text = curInteractable.GetInteractPrompt();
        }
        else
        {
            promptText.gameObject.SetActive(false);
        }
    }
}