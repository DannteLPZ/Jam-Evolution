using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class AquaticEnemyMovement : EnemyController
{
    [SerializeField] private float _patrolRadius;
    private Vector2 _startPosition;
    private Vector2 _patrolTarget;
    private float _moveSign;

    private bool _hitPlayer;
    private bool _bouncedBack;
    private Vector2 _currentTarget;

    private void Start()
    {
        _moveSign = 1.0f;
        _enemyRb = GetComponent<Rigidbody2D>();
        _startPosition = transform.position;
        GetPatrolTarget();
    }

    private void Update()
    {
        Vector2 direction = (_currentTarget - (Vector2)transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90.0f;
        transform.rotation = Quaternion.Euler(angle * Vector3.forward);
    }

    private void FixedUpdate()
    {
        if (_hitPlayer == true)
        {
            if (_bouncedBack == false) BounceBack();
            else _enemyRb.velocity *= 0.9f;
            return;
        }
        if (_playerInRange == false)
        {
            if (Vector2.Distance(transform.position, _patrolTarget) <= 0.01f)
                GetPatrolTarget();
            _currentTarget = _patrolTarget;
            MoveToTarget(_patrolTarget, _patrolSpeed);
        }
        else
        {
            _currentTarget = _target.position;
            MoveToTarget(_target.position, _chaseSpeed);
        }
    }

    private void BounceBack()
    {
        _enemyRb.velocity = Vector3.zero;
        Vector2 direction = (transform.position - _target.position).normalized;
        _enemyRb.AddForce(1.0f * direction, ForceMode2D.Impulse);
        _bouncedBack = true;
        Invoke(nameof(ResetPlayerHit), 0.5f);
    }

    
    private void GetPatrolTarget()
    {
        float index = Random.Range(-_patrolRadius, _patrolRadius);
        float circularValue = _moveSign * Mathf.Sqrt(Mathf.Pow(_patrolRadius, 2) - Mathf.Pow(index, 2));
        _patrolTarget = _startPosition + new Vector2(index, circularValue);
        _moveSign *= -1.0f;
    }

    private void MoveToTarget(Vector2 target, float speed)
    {
        Vector2 direction = (target - (Vector2)transform.position).normalized;
        Vector2 desiredVelocity = speed * direction;
        Vector2 currentVelocity = _enemyRb.velocity;
        Vector2 newVelocity = (desiredVelocity - currentVelocity) / Time.fixedDeltaTime;
        _enemyRb.AddForce(newVelocity, ForceMode2D.Force);
    }

    public override void PlayerHit() => _hitPlayer = true;
    private void ResetPlayerHit()
    {
        _hitPlayer = false;
        _bouncedBack = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _patrolRadius);

        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(_patrolTarget, 0.1f);
    }
}
