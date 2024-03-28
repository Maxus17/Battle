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
    private PlayerHealth _playerHealth;
    public float attackDistance = 1;

    public float viewAngle;
    public float damage = 30;
    
    public Animator animator;

    void Start()
    {
        InintComponentLink();
    }

    private void InintComponentLink()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
        _playerHealth = player.GetComponent<PlayerHealth>();
    }

    void Update()
    {
        PotrolUpdate();
        NoticePlayerUpdate();
        ChaseUpdate();
        AttackUpdate();
    }
    private void AttackUpdate()
    {
        if (_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                animator.SetTrigger("attack");
            }
        }
    }

    public void AttackDamage()
    {
        if (_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= (_navMeshAgent.stoppingDistance + attackDistance))
            {
                _playerHealth.DealDamage(damage);
            }
        }

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

    private void PotrolUpdate()
    {
        
        if (!_isPlayerNoticed)
        {
            if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance)
            {
                PickPotrolPoint();
            }
        }
    }
   
    private void PickPotrolPoint()
    {
        _navMeshAgent.destination = potrolPoints[Random.Range(0, potrolPoints.Count)].position;
    }
}
