using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;
    public float movSpeed = 5f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private Vector2 moveInput;
    private bool isMoving;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        GetInput();
        Animate();
    }

    void FixedUpdate()
    {
        Move();
    }

    private void GetInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        moveInput = new Vector2(x, y).normalized;
    }

    private void Move()
    {
        rb.linearVelocity = moveInput * movSpeed;
    }

    private void Animate()
    {
        isMoving = moveInput != Vector2.zero;
        anim.SetBool("isMoving", isMoving);

        // Flip sprite hanya saat ada input horizontal
        if (moveInput.x != 0)
        {
            spriteRenderer.flipX = moveInput.x < 0;
        }
    }
}
