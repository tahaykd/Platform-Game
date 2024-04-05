using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    public float totalTime = 20f;
    private float currentTime;
    private bool toggleFinished = false;

    public TextMeshProUGUI timerText;
    public GameObject finishPanel;

    void Start()
    {
        currentTime = totalTime;
        UpdateTimerText();
    }

    void Update()
    {
        if (currentTime > 0f)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerText();
        }
        else
        {
            if (!toggleFinished)
            {
                ToggleFinishPanel();
                toggleFinished = true;
            }
        }
    }

    void ToggleFinishPanel()
    {
        if (finishPanel != null)
        {
            finishPanel.SetActive(!finishPanel.activeSelf);
            Time.timeScale = 0f;
        }
    }

    void UpdateTimerText()
    {
        if (timerText != null)
        {
            timerText.text = Mathf.CeilToInt(currentTime).ToString();
        }
    }
}
