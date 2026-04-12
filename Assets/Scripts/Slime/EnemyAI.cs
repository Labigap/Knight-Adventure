using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using KA.Utils;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private State startingState;

    [SerializeField] private float RoamingDistanceMin = 3f;
    [SerializeField] private float RoamingDistanceMax = 7f;
    [SerializeField] private float RoamingTimerMax = 2f;

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

    private void Start()
    {
        startingPos = transform.position;
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
        roamPos = GetRoamingPosition();
        navMeshAgent.SetDestination(roamPos);
    }

    private Vector3 GetRoamingPosition()
    {
        return startingPos + Utils.GetRandomDir() * UnityEngine.Random.Range(RoamingDistanceMin, RoamingDistanceMax);
    } 
}
