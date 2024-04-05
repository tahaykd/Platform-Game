using UnityEngine;

public class SimplePlatform : MonoBehaviour
{
    public float moveSpeed = 5f; // Platformun hareket hızı
    public Transform topPosition; // Platformun ulaşacağı üst pozisyon
    public Transform bottomPosition; // Platformun başlangıç pozisyonu

    private bool movingUp = true;
    private Vector3 originalPosition;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        MovePlatform();

        // Eğer platform üst pozisyonu geçerse aşağıya dönmek üzere hareketi tersine çevirelim
        if (transform.position.y >= topPosition.position.y)
        {
            movingUp = false;
        }

        // Eğer platform başlangıç pozisyonunu geçerse yukarıya dönmek üzere hareketi tersine çevirelim
        else if (transform.position.y <= bottomPosition.position.y)
        {
            movingUp = true;
        }
    }

    void MovePlatform()
    {
        // Platformu yukarı ya da aşağı doğru hareket ettir
        float direction = movingUp ? 1f : -1f;
        transform.Translate(Vector2.up * direction * moveSpeed * Time.deltaTime);
    }
}
