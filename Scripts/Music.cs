using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioClip backgroundMusic;
    public float musicVolume = 0.5f; // Varsayılan ses seviyesi

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.clip = backgroundMusic;
        audioSource.loop = true; // Müziği döngüde oynat
        audioSource.volume = musicVolume; // Ses seviyesini ayarla
        audioSource.Play();
    }
}
