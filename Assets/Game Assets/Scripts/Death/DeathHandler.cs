using System;
using System.Collections;
using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    [SerializeField] private PlayerCanMoveStateController _playerMoveState;
    [SerializeField] private DeathScreamer _deathScreamer;

    private GameObject _enemy;

    public Action PlayersDied;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out EnemyAI enemy))
        {   
            StopGame();
            _enemy = enemy.gameObject;
            _deathScreamer.ShowScreamerCamera();
            StartCoroutine(InvokeEventByDelay());
        }     
    }

    private void StopGame()
    {
        _playerMoveState.FreezePlayer();
    }

    IEnumerator InvokeEventByDelay()
    {
        yield return new WaitForSecondsRealtime(1.5f);
        Destroy(_enemy.gameObject);
        PlayersDied?.Invoke();
    }
}
 