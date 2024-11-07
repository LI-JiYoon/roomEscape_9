using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RoomEscape.Managers;

public enum AIState
{
    Idle,
    Patrol,
    Attacking,
    Searching
}

public class Monster : MonoBehaviour
{
    [Header("Stats")]
    public int health;  // ������ ü��
    public float walkSpeed;  // �ȴ� �ӵ�
    public float runSpeed;  // �ٴ� �ӵ�

    [Header("AI")]
    private NavMeshAgent agent;  // NavMeshAgent ������Ʈ
    public float detectDistance;  // �÷��̾ �����ϴ� �Ÿ�
    public float viewAngle;  // �þ߰�
    public float raycastHeightOffset = 1.5f;  // ����ĳ��Ʈ ���� ������
    private AIState aiState;  // ���� AI ����

    private float playerDistance;  // �÷��̾���� �Ÿ�

    public Transform[] patrolPoints;  // ���� ���� �迭
    private int currentPatrolIndex = 0;  // ���� ���� ���� �ε���

    public Transform playerTransform;  // �÷��̾��� Transform
    private Vector3 lastKnownPlayerPosition;  // ���������� ������ �÷��̾� ��ġ
    private bool playerInSight;  // �÷��̾ �þ߿� �ִ��� ����

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();  // NavMeshAgent ������Ʈ�� ������
    }

    // Start is called before the first frame update
    void Start()
    {
        aiState = AIState.Patrol;  // �ʱ� ���¸� ������ ����
        SetNextPatrolPoint();  // ���� ���� ������ ����
    }

    // Update is called once per frame
    void Update()
    {
        playerDistance = Vector3.Distance(transform.position, GameManager.instance.playerController.transform.position);  // �÷��̾���� �Ÿ� ���
        playerInSight = IsPlayerInSight();  // �÷��̾ �þ߿� �ִ��� Ȯ��

        switch (aiState)
        {
            case AIState.Patrol:
                Patrol();  // ���� ���� ó��
                break;
            case AIState.Attacking:
                ChasePlayer();  // ���� ���� ó��
                break;
            case AIState.Searching:
                SearchForPlayer();  // Ž�� ���� ó��
                break;
        }
    }

    private void Patrol()
    {
        if (playerInSight)
        {
            aiState = AIState.Attacking;  // �÷��̾ �þ߿� ������ ���� ���·� ����
            agent.speed = runSpeed;  // ���� �� �ӵ��� �ٴ� �ӵ��� ����
        }
        else if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            SetNextPatrolPoint();  // ���� ������ �����ϸ� ���� ���� ���� ����
        }
    }

    private void ChasePlayer()
    {
        if (playerInSight)
        {
            lastKnownPlayerPosition = playerTransform.position;  // �÷��̾��� ������ ��ġ ����
            agent.SetDestination(lastKnownPlayerPosition);  // �ش� ��ġ�� �̵�
        }
        else
        {
            aiState = AIState.Searching;  // �÷��̾ �þ߿��� ������� Ž�� ���·� ����
        }
    }

    private void SearchForPlayer()
    {
        if (playerInSight)
        {
            aiState = AIState.Attacking;  // �÷��̾ �ٽ� �þ߿� ������ ���� ���·� ����
            agent.speed = runSpeed;  // ���� �� �ӵ��� �ٴ� �ӵ��� ����
        }
        else if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            aiState = AIState.Patrol;  // Ž���� ������ �ٽ� ���� ���·� ����
            agent.speed = walkSpeed;  // ���� �� �ӵ��� �ȴ� �ӵ��� ����
            SetNextPatrolPoint();  // ���� ���� ���� ����
        }
    }

    private void SetNextPatrolPoint()
    {
        if (patrolPoints.Length == 0)
            return;

        agent.speed = walkSpeed;  // ���� �� �ȴ� �ӵ��� ����
        agent.SetDestination(patrolPoints[currentPatrolIndex].position);  // ���� ���� ���� ����
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;  // ���� ���� �ε��� ������Ʈ
    }

    private bool IsPlayerInSight()
    {
        Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;  // �÷��̾� ���� ���
        float angleBetweenMonsterAndPlayer = Vector3.Angle(transform.forward, directionToPlayer);  // ���Ϳ� �÷��̾� ������ ���� ���

        if (playerDistance <= detectDistance && angleBetweenMonsterAndPlayer <= viewAngle / 2)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up * raycastHeightOffset, directionToPlayer, out hit, detectDistance))  // ����ĳ��Ʈ�� ��ֹ� Ȯ��
            {
                if (hit.transform == playerTransform)
                {
                    return true;  // �÷��̾ �����Ǹ� true ��ȯ
                }
            }
        }

        return false;  // �÷��̾ �������� ������ false ��ȯ
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform == playerTransform)
        {
            agent.isStopped = true;  // ������ �̵��� ����
            GameManager.instance.GameOver();  // ���� ���� �Լ� ȣ��
        }
    }

    private void OnDrawGizmos()
    {
        // ���� ������ �׸�
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectDistance);

        // �þ߰��� �׸�
        Vector3 leftBoundary = Quaternion.Euler(0, -viewAngle / 2, 0) * transform.forward * detectDistance;
        Vector3 rightBoundary = Quaternion.Euler(0, viewAngle / 2, 0) * transform.forward * detectDistance;
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + leftBoundary);
        Gizmos.DrawLine(transform.position, transform.position + rightBoundary);

        // �÷��̾ �þ߿� ���� ��� �÷��̾���� ���� �׸�
        if (playerInSight)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position + Vector3.up * raycastHeightOffset, playerTransform.position);
        }
    }
}
