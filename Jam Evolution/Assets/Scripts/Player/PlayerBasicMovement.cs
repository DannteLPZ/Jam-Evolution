using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public class PlayerBasicMovement : MonoBehaviour
{
    [SerializeField] private float speed = 2.0f; // Velocidad de movimiento del jugador
    
    private Rigidbody2D playerRb;
    float moveVertical;
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveVertical = Input.GetAxis("Vertical");

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mousePos - (Vector2)transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90.0f;
        if(Vector2.Distance(transform.position, mousePos) > 0.2f)
            transform.rotation = Quaternion.Euler(angle * Vector3.forward);
    }

    private void FixedUpdate()
    {   
        BasicMovement();           
    }

    private void BasicMovement()
    {
        if(moveVertical == 0)
            playerRb.velocity *= 0.9f;
        else
        {
            Vector2 speedVector = moveVertical * speed * transform.up.normalized;
            playerRb.velocity = speedVector;
            //playerRb.velocity = Vector2.ClampMagnitude(playerRb.velocity, speed);
        }
    }   
}
