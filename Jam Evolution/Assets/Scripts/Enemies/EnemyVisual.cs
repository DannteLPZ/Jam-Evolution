using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVisual : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _enemyRb;

    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        CheckSpriteFlip();
        transform.rotation = Quaternion.FromToRotation(Vector3.right, _enemyRb.velocity.normalized);
    }

    private void CheckSpriteFlip()
    {
        if(_enemyRb.velocity.x < -0.1f)
            _spriteRenderer.flipX = true;
        if (_enemyRb.velocity.x > 0.1f)
            _spriteRenderer.flipX = false;
    }
}
