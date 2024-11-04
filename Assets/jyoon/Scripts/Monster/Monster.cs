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
    public int health;  // 몬스터의 체력
    public float walkSpeed;  // 걷는 속도
    public float runSpeed;  // 뛰는 속도

    [Header("AI")]
    private NavMeshAgent agent;  // NavMeshAgent 컴포넌트
    public float detectDistance;  // 플레이어를 감지하는 거리
    public float viewAngle;  // 시야각
    public float raycastHeightOffset = 1.5f;  // 레이캐스트 높이 오프셋
    private AIState aiState;  // 현재 AI 상태

    private float playerDistance;  // 플레이어와의 거리

    public Transform[] patrolPoints;  // 순찰 지점 배열
    private int currentPatrolIndex = 0;  // 현재 순찰 지점 인덱스

    public Transform playerTransform;  // 플레이어의 Transform
    private Vector3 lastKnownPlayerPosition;  // 마지막으로 감지된 플레이어 위치
    private bool playerInSight;  // 플레이어가 시야에 있는지 여부

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();  // NavMeshAgent 컴포넌트를 가져옴
    }

    // Start is called before the first frame update
    void Start()
    {
        aiState = AIState.Patrol;  // 초기 상태를 순찰로 설정
        SetNextPatrolPoint();  // 다음 순찰 지점을 설정
    }

    // Update is called once per frame
    void Update()
    {
        playerDistance = Vector3.Distance(transform.position, GameManager.instance.playerController.transform.position);  // 플레이어와의 거리 계산
        playerInSight = IsPlayerInSight();  // 플레이어가 시야에 있는지 확인

        switch (aiState)
        {
            case AIState.Patrol:
                Patrol();  // 순찰 상태 처리
                break;
            case AIState.Attacking:
                ChasePlayer();  // 추적 상태 처리
                break;
            case AIState.Searching:
                SearchForPlayer();  // 탐색 상태 처리
                break;
        }
    }

    private void Patrol()
    {
        if (playerInSight)
        {
            aiState = AIState.Attacking;  // 플레이어가 시야에 있으면 추적 상태로 변경
            agent.speed = runSpeed;  // 추적 시 속도를 뛰는 속도로 설정
        }
        else if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            SetNextPatrolPoint();  // 순찰 지점에 도착하면 다음 순찰 지점 설정
        }
    }

    private void ChasePlayer()
    {
        if (playerInSight)
        {
            lastKnownPlayerPosition = playerTransform.position;  // 플레이어의 마지막 위치 저장
            agent.SetDestination(lastKnownPlayerPosition);  // 해당 위치로 이동
        }
        else
        {
            aiState = AIState.Searching;  // 플레이어가 시야에서 사라지면 탐색 상태로 변경
        }
    }

    private void SearchForPlayer()
    {
        if (playerInSight)
        {
            aiState = AIState.Attacking;  // 플레이어가 다시 시야에 들어오면 추적 상태로 변경
            agent.speed = runSpeed;  // 추적 시 속도를 뛰는 속도로 설정
        }
        else if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            aiState = AIState.Patrol;  // 탐색이 끝나면 다시 순찰 상태로 변경
            agent.speed = walkSpeed;  // 순찰 시 속도를 걷는 속도로 설정
            SetNextPatrolPoint();  // 다음 순찰 지점 설정
        }
    }

    private void SetNextPatrolPoint()
    {
        if (patrolPoints.Length == 0)
            return;

        agent.speed = walkSpeed;  // 순찰 시 걷는 속도로 설정
        agent.SetDestination(patrolPoints[currentPatrolIndex].position);  // 다음 순찰 지점 설정
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;  // 순찰 지점 인덱스 업데이트
    }

    private bool IsPlayerInSight()
    {
        Vector3 directionToPlayer = (playerTransform.position - transform.position).normalized;  // 플레이어 방향 계산
        float angleBetweenMonsterAndPlayer = Vector3.Angle(transform.forward, directionToPlayer);  // 몬스터와 플레이어 사이의 각도 계산

        if (playerDistance <= detectDistance && angleBetweenMonsterAndPlayer <= viewAngle / 2)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up * raycastHeightOffset, directionToPlayer, out hit, detectDistance))  // 레이캐스트로 장애물 확인
            {
                if (hit.transform == playerTransform)
                {
                    return true;  // 플레이어가 감지되면 true 반환
                }
            }
        }

        return false;  // 플레이어가 감지되지 않으면 false 반환
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform == playerTransform)
        {
            agent.isStopped = true;  // 몬스터의 이동을 멈춤
            GameManager.instance.GameOver();  // 게임 오버 함수 호출
        }
    }

    private void OnDrawGizmos()
    {
        // 감지 범위를 그림
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectDistance);

        // 시야각을 그림
        Vector3 leftBoundary = Quaternion.Euler(0, -viewAngle / 2, 0) * transform.forward * detectDistance;
        Vector3 rightBoundary = Quaternion.Euler(0, viewAngle / 2, 0) * transform.forward * detectDistance;
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + leftBoundary);
        Gizmos.DrawLine(transform.position, transform.position + rightBoundary);

        // 플레이어가 시야에 있을 경우 플레이어까지 선을 그림
        if (playerInSight)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position + Vector3.up * raycastHeightOffset, playerTransform.position);
        }
    }
}
