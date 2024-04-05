using System.Net.Http.Headers;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    private Animator animator;

    public AudioClip soundEffect;
    public AudioClip soundEffect1;
    public GameObject finishPanel;

    void Start()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Health"))
        {
            GainHealth(20); // Sağlık nesnesine çarpıldığında kazanılacak sağlık puanı
        }
    }

    void TakeDamage(GameObject enemy)
    {
        EnemyDamage enemyDamage = enemy.GetComponent<EnemyDamage>();

        if (enemyDamage != null)
        {
            int damageAmount = enemyDamage.damage;
            currentHealth -= damageAmount;
            PlaySoundEffect();

            if (currentHealth <= 0)
            {
                Die();
            }
            else
            {
                animator.SetTrigger("Hit");
            }
        }
    }

    public void GainHealth(int hpPoint)
    {
        currentHealth += hpPoint;
        PlaySoundEffect1();
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
    void PlaySoundEffect()
    {
        if (soundEffect != null)
        {
            // GameObject üzerindeki AudioSource bileşenini al
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();

            // Eğer AudioSource yoksa, bir tane ekleyerek al
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }

            // AudioClip'i atayarak ses efektini oynat
            audioSource.clip = soundEffect;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Ses efekti atanmamış!");
        }
    }
    void PlaySoundEffect1()
    {
        if (soundEffect1 != null)
        {
            // GameObject üzerindeki AudioSource bileşenini al
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();

            // Eğer AudioSource yoksa, bir tane ekleyerek al
            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }

            // AudioClip'i atayarak ses efektini oynat
            audioSource.clip = soundEffect1;
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Ses efekti atanmamış!");
        }
    }

    void Die()
    {
        if (finishPanel != null)
        {
            finishPanel.SetActive(!finishPanel.activeSelf);
            Time.timeScale = 0f;
        }
    }
}
