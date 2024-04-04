using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class EnemyFollower : MonoBehaviour
{
    [SerializeField] private float _patrolRadius;
    [SerializeField] private float _patrolSpeed;

    /*private Transform _target;
    private State _currentState;

    private bool _playerInRange;

    private void Update()
    {
        SelectState();
        _currentState.Do();
    }

    /*private void SelectState()
    {
        State oldState = _currentState;

        if (_playerInRange == true)
        {
            _currentState = _chaseState;
        }
        else
            _currentState = _jumpState;

        if (oldState != _currentState || oldState.IsComplete == true)
        {
            oldState.Exit();
            _currentState.Initialize();
            _currentState.Enter();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player") == true)
        {

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") == true) _playerInRange = false;
    }*/
}
