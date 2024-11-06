using TMPro;
using UnityEngine;


public class Interaction : MonoBehaviour
{
    public static Interaction Instance;

    public float checkRate = 0.05f; // 상호작용 가능한 오브젝트를 얼마나 자주 체크할지 설정합니다
    private float lastCheckTime;
    public float maxCheckDistance; // 상호작용 체크 최대 거리
    public LayerMask layerMask; // 상호작용 가능한 오브젝트의 레이어를 설정합니다

    public GameObject curInteractGameObject; // 현재 화면에 있는 상호작용 가능한 오브젝트
    public IInteractable curInteractable; // 현재 화면에 있는 상호작용 가능한 컴포넌트

    public TextMeshProUGUI promptText; // 상호작용 프롬프트 UI 텍스트
    private Camera camera; // 메인 카메라 참조

    private void Awake()
    {
        // 다른 스크립트에서 쉽게 접근할 수 있도록 이 인스턴스를 설정합니다
        Instance = this;
    }

    void Start()
    {
        // 메인 카메라 참조를 가져옵니다
        camera = Camera.main;
    }
    void Update()
    {
        // 정기적으로 상호작용 가능한 오브젝트를 체크합니다
        if (Time.time - lastCheckTime > checkRate)
        {
            lastCheckTime = Time.time;

            // 화면의 중앙에서 레이를 쏴서 상호작용 가능한 오브젝트를 체크합니다
            Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxCheckDistance, layerMask))
            {
                // 히트한 오브젝트가 현재 상호작용 오브젝트와 다르면 업데이트합니다
                if (hit.collider.gameObject != curInteractGameObject)
                {
                    curInteractGameObject = hit.collider.gameObject;
                    curInteractable = hit.collider.GetComponent<IInteractable>();
                    SetPromptText();
                }
            }
            else
            {
                // 상호작용 가능한 오브젝트를 찾지 못한 경우 현재 상호작용 오브젝트를 지웁니다
                curInteractGameObject = null;
                curInteractable = null;
                promptText.gameObject.SetActive(false);
            }
        }
    }

    // 현재 상호작용 가능한 오브젝트에 따라 프롬프트 텍스트를 설정합니다
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