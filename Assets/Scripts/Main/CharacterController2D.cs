using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CharacterController2D : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public Vector2 maxBounds;
    public Vector2 minBounds;
    private float characterHeight;
    private float characterWidth;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null) //반 크기 가져오기
        {
            characterWidth = spriteRenderer.bounds.extents.x;
            characterHeight = spriteRenderer.bounds.extents.y;
        }
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal"); // 좌우 이동 (A, D, ←, →)
        float moveY = Input.GetAxisRaw("Vertical");   // 상하 이동 (W, S, ↑, ↓)

        moveInput = new Vector3(moveX, moveY, 0); //이동

        bool isMoving = moveInput.sqrMagnitude > 0;
        animator.SetBool("isMoving", isMoving);

        if (moveX > 0) spriteRenderer.flipX = false; // 오른쪽 이동 (원래 방향)
        else if (moveX < 0) spriteRenderer.flipX = true;  // 왼쪽 이동 (반전)
    }

    void FixedUpdate()
    {
        Vector2 newPosition = rb.position + moveInput * moveSpeed * Time.fixedDeltaTime;

        // 경계를 벗어나지 않도록 Clamp 적용
        float clampedX = Mathf.Clamp(newPosition.x, minBounds.x + characterWidth, maxBounds.x - characterWidth);
        float clampedY = Mathf.Clamp(newPosition.y, minBounds.y + characterHeight, maxBounds.y - characterHeight);

        rb.MovePosition(new Vector2(clampedX, clampedY));
    }
}
