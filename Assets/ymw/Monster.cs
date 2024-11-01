using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public enum AIState
{
    Idle,
    Patrol,
    Attacking
}

public class Monster : MonoBehaviour
{
    [Header("Stats")]
    public int health;
    public float walkSpeed;
    public float runSpeed;

    [Header("AI")]
    private NavMeshAgent agent;
    public float detectDistance;
    private AIState aiState;

    private float playerDistance;

    public Transform patrolTransform1;
    public Transform patrolTransform2;

    public Transform targetTransform;

    bool isToPatrol1;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Start is called before the first frame update
    void Start()
    {
        aiState = AIState.Idle;

        isToPatrol1 = true;
        targetTransform = patrolTransform1;

        SetTargetPosition();
    }

    // Update is called once per frame
    void Update()
    {
        playerDistance = Vector3.Distance(transform.position, GameManager.Instance.playerController.transform.position);
    }

    public void ToggleDestination()
    {
        if (isToPatrol1)
        {
            isToPatrol1 = false;
            targetTransform = patrolTransform2;
            SetTargetPosition();
        }
        else
        {
            isToPatrol1 = true;
            targetTransform = patrolTransform1;
            SetTargetPosition();
        }
    }

    public void SetTargetPosition()
    {
        agent.SetDestination(targetTransform.position);
    }
}
