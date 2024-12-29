using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;

    [SerializeField] private Transform _playerPoint;

    private void Update()
    {
        _agent.SetDestination(_playerPoint.position);
    }
}
