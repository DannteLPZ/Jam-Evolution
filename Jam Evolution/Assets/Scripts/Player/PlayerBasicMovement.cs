using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBasicMovement : MonoBehaviour
{
    private Rigidbody2D playerRb;
    [SerializeField] private float radius = 0.51f;
    [SerializeField] private float speed = 2.0f; // Velocidad de movimiento del jugador
    
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
         
        BasicMovement();
              
    }

    private void BasicMovement()
    {
        // Desactiva la gravedad del Rigidbody2D
        playerRb.gravityScale = 0;     

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        // Calcula el vector de movimiento
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);

        // Normaliza el vector para mantener la misma velocidad en todas las direcciones
        movement.Normalize();

        // Aplica movimiento al jugador
        //transform.Translate(movement * speed * Time.deltaTime);
        //playerRb.velocity = speed * movement;
        playerRb.AddForce(speed * movement);

    }   

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
