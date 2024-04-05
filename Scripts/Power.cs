using UnityEngine;

public class Power : MonoBehaviour
{
    public float powerAmount = 1f; // Kazanılacak güç miktarı

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player playerController = other.GetComponent<Player>();

            if (playerController != null)
            {
                playerController.GainPower(powerAmount);
                Destroy(gameObject); // Güç objesini yok et, isteğe bağlı olarak
            }
        }
    }
}
