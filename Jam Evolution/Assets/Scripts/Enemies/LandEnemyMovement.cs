using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class LandEnemyMovement : EnemyController
{
    [SerializeField] private Transform _sensor;
    [SerializeField] private float _sensorDistance;
    [SerializeField] private LayerMask _whatIsGround;

    private float _direction;
    private bool hitWall;
    private bool hitGround;
    private void Start()
    {
        _enemyRb = GetComponent<Rigidbody2D>();
        _direction = 1.0f;
    }

    private void FixedUpdate()
    {
        hitWall = Physics2D.Raycast(_sensor.position, transform.right, _sensorDistance, _whatIsGround);
        hitGround = Physics2D.Raycast(_sensor.position, Vector3.down, _sensorDistance, _whatIsGround);

        float forceValue;

        if (_playerInRange == false)
        {
            if (hitWall == true || hitGround == false)
            {
                _direction *= -1.0f;
            }
            forceValue = (_direction * _patrolSpeed - _enemyRb.velocity.x) / Time.fixedDeltaTime;
        }
        else
        {
            float distanceToTarget = Mathf.Abs((_target.position - transform.position).x);
            _direction = Mathf.Sign((_target.position - transform.position).x);

            forceValue = (_direction * _chaseSpeed - _enemyRb.velocity.x) / Time.fixedDeltaTime;
            if (hitWall == true || hitGround == false || distanceToTarget <= 0.01f)
            {
                forceValue = -_enemyRb.velocity.x / Time.fixedDeltaTime;
            }
        }
        transform.rotation = Quaternion.Euler((_direction == 1.0f ? 0.0f : 180.0f) * Vector3.up);
        _enemyRb.AddForce(forceValue * Vector2.right);
    }

    public override void PlayerHit()
    {
        _target.TryGetComponent(out Rigidbody2D playerRb);
        if (playerRb != null)
        {
            Vector2 pushDirection = (_target.position - transform.position).normalized;
            playerRb.AddForce(3.0f * pushDirection);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(_sensor.position, (Vector2)_sensor.position + (_sensorDistance * Vector2.down));
        Gizmos.DrawLine(_sensor.position, (Vector2)_sensor.position + (_sensorDistance * (Vector2)transform.right));
    }

}
