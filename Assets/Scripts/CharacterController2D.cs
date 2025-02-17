using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector3 moveInput;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); // 좌우 이동 (A, D, ←, →)
        float moveY = Input.GetAxisRaw("Vertical");   // 상하 이동 (W, S, ↑, ↓)
        
        moveInput = new Vector3(moveX, moveY,0); //이동

        bool isMoving = moveInput.sqrMagnitude >0;
        animator.SetBool("isMoving", isMoving);

        if (moveX > 0) spriteRenderer.flipX = false; // 오른쪽 이동 (원래 방향)
        else if (moveX < 0) spriteRenderer.flipX = true;  // 왼쪽 이동 (반전)
    }

    void FixedUpdate()
    {
        rb.velocity = moveInput * moveSpeed;
    }
}
