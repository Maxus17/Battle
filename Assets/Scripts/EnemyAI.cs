using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public List<Transform> potrolPoints;
    private NavMeshAgent _navMeshAgent;
    public PlayerContoller player;
    private bool _isPlayerNoticed;
    public float viewAngle;

    void Start()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();        
    }

    void Update()
    {
        PickPotrolPoint();
        NoticePlayerUpdate();
        ChaseUpdate();
    }
    private void ChaseUpdate()
    {
        if (_isPlayerNoticed)
        {
            _navMeshAgent.destination = player.transform.position;
        }
    }
    private void NoticePlayerUpdate()
    {
        var direction = player.transform.position - transform.position;
        _isPlayerNoticed = false;

        if (Vector3.Angle(transform.forward, direction) < viewAngle)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }
    }
    private void PickPotrolPoint()
    {
        if (_navMeshAgent.remainingDistance == 0)
        {
            _navMeshAgent.destination = potrolPoints[Random.Range(0, potrolPoints.Count)].position;
        }
        if(!_isPlayerNoticed)
        {
            _navMeshAgent.destination = potrolPoints[Random.Range(0, potrolPoints.Count)].position;
        }
    }
}
