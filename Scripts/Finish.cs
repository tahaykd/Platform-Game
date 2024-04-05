using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public AudioClip finishSound; // Çalınacak ses
    public GameObject finishPanel; // Toggle edilecek panel

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // Eğer AudioSource bileşeni yoksa, bir tane ekleyerek al
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        // Eğer AudioClip atanmışsa, audio kaynağına atayarak kullan
        if (finishSound != null)
        {
            audioSource.clip = finishSound;
        }
        else
        {
            Debug.LogWarning("Ses efekti atanmamış!");
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(PlaySoundEffectAndToggleFinishPanel());
        }
    }

    IEnumerator PlaySoundEffectAndToggleFinishPanel()
    {
        if (audioSource != null)
        {
            audioSource.Play();

            // Oyunu duraklat
            Time.timeScale = 0f;

            ToggleFinishPanel();

            // Bekle
            yield return new WaitForSecondsRealtime(3f);

            // Oyunu tekrar başlat
            Time.timeScale = 1f;


            // Yeni sahneye geç
            SceneManager.LoadScene(2);
        }
        else
        {
            Debug.LogWarning("AudioSource bileşeni bulunamadı!");
        }
    }

    void ToggleFinishPanel()
    {
        if (finishPanel != null)
        {
            finishPanel.SetActive(!finishPanel.activeSelf);
        }
        else
        {
            Debug.LogWarning("Finish panel not assigned!");
        }
    }
}
