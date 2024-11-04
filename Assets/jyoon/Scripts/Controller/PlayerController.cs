using UnityEngine;
using RoomEscape.Managers;
using UnityEngine.InputSystem;
using System;
public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    public bool isHiding;
    public FootStep footStep;
    private float originalFootstepRate;


    [Header("Movement")]
    public float moveSpeed;
    private Vector2 curMovementInput;
    public float jumptForce;
    public LayerMask groundLayerMask;

    [Header("Look")]
    public Transform cameraContainer;
    public float minXLook;
    public float maxXLook;
    private float camCurXRot;
    public float lookSensitivity;

    private Vector2 mouseDelta;

    [HideInInspector]
    public bool canLook = true;

    public Action inventory;

    private Rigidbody rigidbody;
    public GameObject poster;
    private bool isOptionPanelActive = false;
    public OptionUI option;


    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        footStep = GetComponent<FootStep>();


    }

    void Start()
    {

    }

    private void Update()
    {
        //if (poster.activeSelf || option.optionPanel.activeSelf)
        //{
        //    canLook = false;
        //    Time.timeScale = 0;
        //}
        //else
        //{
        //    canLook = true;
        //    Time.timeScale = 1;
        //}
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        if (canLook)
        {
            CameraLook();
        }
    }

    public void OnLookInput(InputAction.CallbackContext context)
    {
        mouseDelta = context.ReadValue<Vector2>();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            curMovementInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            curMovementInput = Vector2.zero;
        }
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && IsGrounded())
        {
            rigidbody.AddForce(Vector2.up * jumptForce, ForceMode.Impulse);
        }
    }

    public void OnRunInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            moveSpeed *= 2;
            footStep.SetFootstepRateMultiplier(2);  // 발소리 2배 빠르게
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            moveSpeed /= 2;
            footStep.ResetFootstepRate(originalFootstepRate);  // 발소리 속도 원래대로
        }
    }

    public void OnSitInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            moveSpeed /= 2;
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 0.5f, transform.localScale.z);
            footStep.SetFootstepRateMultiplier(0.5f);  // 발소리 2배 느리게
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            moveSpeed *= 2;
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y * 2f, transform.localScale.z);
            footStep.ResetFootstepRate(originalFootstepRate);  // 발소리 속도 원래대로
        }
    }

    public void OnOptionInput(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            isOptionPanelActive = !isOptionPanelActive;

            if (isOptionPanelActive)
            {
                option.OpenOptionUI();
            }
            else
            {
                option.CloseOptionUI();
            }
        }
    }


    private void Move()
    {
        Vector3 dir = transform.forward * curMovementInput.y + transform.right * curMovementInput.x;
        dir *= moveSpeed;
        dir.y = rigidbody.velocity.y;

        rigidbody.velocity = dir;
    }

    void CameraLook()
    {
        camCurXRot += mouseDelta.y * lookSensitivity;
        camCurXRot = Mathf.Clamp(camCurXRot, minXLook, maxXLook);
        cameraContainer.localEulerAngles = new Vector3(-camCurXRot, 0, 0);

        transform.Rotate(Vector3.up * mouseDelta.x * lookSensitivity);
    }

    bool IsGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.3f) + (transform.up * 0.05f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.3f) + (transform.up * 0.05f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.3f) + (transform.up * 0.05f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.3f) +(transform.up * 0.05f), Vector3.down)
        };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], 0.55f, groundLayerMask))
            {
                return true;
            }
        }

        return false;
    }

    public void OnInventoryButton(InputAction.CallbackContext callbackContext)
    {
        if (callbackContext.phase == InputActionPhase.Started)
        {
            inventory?.Invoke();
        }
    }
  
    void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Implement Interaction Logic with Objects
            CheckForHidingSpot();
        }
    }

    void CheckForHidingSpot()
    {
        // Implement logic to check if the player can hide
        // For example, using a trigger collider to detect nearby hiding spots
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 2.0f))
        {
            if (hit.collider.CompareTag("HidingSpot"))
            {
                isHiding = true;
                // Additional logic to visually hide the player, e.g., disabling renderer
            }
        }
    }

    void Hide()
    {
        // Implement Hide Logic
    }
}