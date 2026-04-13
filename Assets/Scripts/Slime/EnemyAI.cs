using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using KA.Utils;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private State startingState;

    [SerializeField] private float RoamingDistanceMin = 4f;
    [SerializeField] private float RoamingDistanceMax = 10f;
    [SerializeField] private float RoamingTimerMax = 1f;

    private NavMeshAgent navMeshAgent;
    private State state;
    private float roamingTime;
    private Vector3 roamPos;
    private Vector3 startingPos;

    private enum State
    {
        Idle,
        Roaming
    }

    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.updateRotation = false;
        navMeshAgent.updateUpAxis = false;
        state = startingState;
    }

    private void Update()
    {
        switch (state)
        {
            default:
            case State.Idle:
                break;
            case State.Roaming:
                roamingTime -= Time.deltaTime;
                if (roamingTime < 0)
                {
                    Roaming();
                    roamingTime = RoamingTimerMax;
                }
                break;
        }
    }

    private void Roaming()
    {
        startingPos = transform.position;
        roamPos = GetRoamingPosition();
        ChangeFacingDirection(startingPos, roamPos);
        navMeshAgent.SetDestination(roamPos);
    }

    private Vector3 GetRoamingPosition()
    {
        return startingPos + Utils.GetRandomDir() * UnityEngine.Random.Range(RoamingDistanceMin, RoamingDistanceMax);
    } 

    private void ChangeFacingDirection(Vector3 sourcePos, Vector3 targetPos)
    {
        if (sourcePos.x > targetPos.x)
        {
            transform.rotation = Quaternion.Euler(0, -180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}
