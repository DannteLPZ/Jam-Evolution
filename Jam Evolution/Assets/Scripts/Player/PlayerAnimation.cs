using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private Animator _playerAnimator;
    [SerializeField] private Rigidbody2D _playerRb;

    private void Update()
    {
        float speedX = _playerRb.velocity.x;
        _playerAnimator.SetFloat("Speed", Mathf.Abs(speedX));
        if(speedX < -0.1f) _spriteRenderer.flipX = true;
        else if (speedX > 0.1f) _spriteRenderer.flipX = false;
    }
}
