using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementEvolution : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _jumpBufferTime;
    [SerializeField] private Collider2D _groundCheck;
    [SerializeField] private LayerMask _whatIsGround; 

    private Rigidbody2D _playerRb;
    private float _moveHorizontal;
    private float _jumpBufferTimer;
    private bool _hasInputJump;

    void Start()
    {
        _playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _moveHorizontal = Input.GetAxis("Horizontal");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _hasInputJump = true;
            _jumpBufferTimer = _jumpBufferTime;
        }
        if(_hasInputJump == true)
        {
            _jumpBufferTimer -= Time.deltaTime;
            if (_jumpBufferTimer < 0) _hasInputJump = false;
        }
    }
    private void FixedUpdate()
    {
        MovementEvolution();        
    }
  
    private void MovementEvolution()
    {
        _playerRb.velocity = new Vector2(_moveHorizontal * _speed, _playerRb.velocity.y);

        if(_hasInputJump && IsGrounded())
        {
            _playerRb.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        // Lanza un Raycast hacia abajo para detectar si hay suelo debajo del jugador
        bool isGrounded = Physics2D.OverlapAreaAll(_groundCheck.bounds.min, _groundCheck.bounds.max, _whatIsGround).Length > 0;

        // Si el Raycast golpea algo, significa que el jugador está en el suelo
        return isGrounded;
    }
}
