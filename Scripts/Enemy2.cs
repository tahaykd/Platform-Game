using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float movementRange = 5f;
    public float jumpForce = 2f;
    public float jumpInterval = 1f; // Zıplama aralığı

    private Vector2 initialPosition;
    private SpriteRenderer spriteRenderer;
    private float previousXPosition;
    private Rigidbody2D rb;

    void Start()
    {
        initialPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        previousXPosition = transform.position.x;
        rb = GetComponent<Rigidbody2D>();

        // Zıplama fonksiyonunu belirli aralıklarla çağır
        InvokeRepeating("Jump", 0f, jumpInterval);
    }

    void Update()
    {
        MoveEnemy();
        FlipSprite();
    }

    void MoveEnemy()
    {
        float movement = Mathf.Sin(Time.time) * moveSpeed;

        transform.position = new Vector2(initialPosition.x + movement, transform.position.y);

        if (Mathf.Abs(transform.position.x - initialPosition.x) >= movementRange)
        {
            moveSpeed *= -1;
        }
    }

    void FlipSprite()
    {
        float currentXPosition = transform.position.x;

        if (currentXPosition > previousXPosition)
        {
            // Sağa gidiyorsa sprite'ı normal bırak
            spriteRenderer.flipX = false;
        }
        else if (currentXPosition < previousXPosition)
        {
            // Sola gidiyorsa sprite'ı çevir
            spriteRenderer.flipX = true;
        }

        previousXPosition = currentXPosition;
    }

    void Jump()
    {
        // Zıplama fonksiyonu
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }
}
