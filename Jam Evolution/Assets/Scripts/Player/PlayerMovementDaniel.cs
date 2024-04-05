using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovementDaniel : MonoBehaviour
{
    [SerializeField] private float speed = 3.0f;
    private Rigidbody2D PlayerRb;
    private Vector2 moveInput;
    // Start is called before the first frame update
    void Start()
    {
        PlayerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveInput = new Vector2(moveX, moveY).normalized;
    }

    void FixedUpdate(){

        PlayerRb.MovePosition(PlayerRb.position + moveInput * speed * Time.fixedDeltaTime);
    }
}
