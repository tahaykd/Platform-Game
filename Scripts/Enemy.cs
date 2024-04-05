using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 3f;
    public float movementRange = 5f;

    private Vector2 initialPosition;
    private SpriteRenderer spriteRenderer;
    private float previousXPosition;

    void Start()
    {
        initialPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
        previousXPosition = transform.position.x;
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
}
