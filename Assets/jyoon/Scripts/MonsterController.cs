using UnityEngine.AI;
using UnityEngine;
using RoomEscape.Managers;

public class MonsterController : MonoBehaviour
{
    public Transform player;
    public float detectionRadius = 10.0f;
    public float lostSightRadius = 15.0f;
    public Transform[] patrolPoints;
    private NavMeshAgent agent;
    private int currentPatrolIndex;
    private Vector3 lastKnownPlayerPosition;
    private bool isChasingPlayer;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentPatrolIndex = 0;
        PatrolToNextPoint();
    }

    void Update()
    {
        if (GameManager.instance.isGamePaused)
        {
            agent.isStopped = true;
            return;
        }
        else
        {
            agent.isStopped = false;
        }

        if (isChasingPlayer)
        {
            if (PlayerDetected())
            {
                lastKnownPlayerPosition = player.position;
                agent.SetDestination(lastKnownPlayerPosition);
            }
            else if (Vector3.Distance(transform.position, lastKnownPlayerPosition) < 1.0f)
            {
                isChasingPlayer = false;
                PatrolToNextPoint();
            }
            else
            {
                agent.SetDestination(lastKnownPlayerPosition);
            }
        }
        else
        {
            if (PlayerDetected())
            {
                isChasingPlayer = true;
                lastKnownPlayerPosition = player.position;
                agent.SetDestination(lastKnownPlayerPosition);
            }
            else if (!agent.pathPending && agent.remainingDistance < 0.5f)
            {
                PatrolToNextPoint();
            }
        }
    }

    bool PlayerDetected()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        return distanceToPlayer < detectionRadius && !PlayerHidden();
    }

    bool PlayerHidden()
    {
        // Implement logic to determine if player is hiding
        // This could be based on collision checks, trigger zones, etc.
        return player.GetComponent<PlayerController>().isHiding;
    }

    void PatrolToNextPoint()
    {
        if (patrolPoints.Length == 0)
            return;

        agent.SetDestination(patrolPoints[currentPatrolIndex].position);
        currentPatrolIndex = (currentPatrolIndex + 1) % patrolPoints.Length;
    }
}