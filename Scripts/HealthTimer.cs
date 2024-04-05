using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthTimer : MonoBehaviour
{
    public PlayerDamage playerDamage; // PlayerDamage scriptini bu değişken üzerinden referans alacağız
    public TextMeshProUGUI healthText; // UI Text nesnesini bu değişken üzerinden referans alacağız

    void Start()
    {
        // Eğer playerDamage değişkeni atanmışsa, PlayerDamage scriptinden currenthealth değerini al
        if (playerDamage != null)
        {
            UpdateHealthText(); // Oyun başladığında metni güncelle
        }
        else
        {
            Debug.LogError("PlayerDamage scripti atanmamış!");
        }
    }

    void Update()
    {
        // Eğer playerDamage değişkeni atanmışsa, PlayerDamage scriptinden currenthealth değerini izle
        if (playerDamage != null)
        {
            UpdateHealthText(); // Her frame'de metni güncelle
        }
    }

    void UpdateHealthText()
    {
        // Text nesnesine can değerini yazdır
        if (healthText != null)
        {
            healthText.text =playerDamage.GetCurrentHealth().ToString();
        }
    }
    
}
