using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementEvolution : MonoBehaviour
{
    private Rigidbody2D playerRb;
    [SerializeField] private float radius = 0.51f;
    [SerializeField] private float jumpForce = 9.0f;
    [SerializeField] private float speed = 5.0f; // Velocidad de movimiento del jugador
    public LayerMask groundLayer; // Capa que representa el suelo

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        MovementEvolution();        
    }
  
    private void MovementEvolution()
    {
        // Obtiene entrada de movimiento horizontal
        float moveHorizontal = Input.GetAxis("Horizontal");

        // Calcula el vector de movimiento
        Vector2 movement = new Vector2(moveHorizontal, 0f);

        // Aplica movimiento horizontal al jugador
        playerRb.velocity = new Vector2(movement.x * speed, playerRb.velocity.y);

        // Revisa si el jugador está en el suelo para permitir el salto
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            // Aplica fuerza de salto
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private bool IsGrounded()
    {
        // Lanza un Raycast hacia abajo para detectar si hay suelo debajo del jugador
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, radius, groundLayer);
        
        // Si el Raycast golpea algo, significa que el jugador está en el suelo
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
