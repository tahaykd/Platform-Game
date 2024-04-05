using UnityEngine;

public class HealthObject : MonoBehaviour
{
    public int hp_point = 20; // Kazanılacak can miktarı

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerDamage playerDamage = other.GetComponent<PlayerDamage>();

            if (playerDamage != null)
            {
                playerDamage.GainHealth(hp_point);
                Destroy(gameObject); // Can objesini yok et, isteğe bağlı olarak
            }
        }
    }
}
