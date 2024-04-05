using UnityEngine;
using UnityEngine.SceneManagement;

public class Button : MonoBehaviour
{

    public void OnButtonClicked()
    {
        SceneManager.LoadScene(1);
    }

    public void OnEscapeButtonClicked()
    {
        {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
    }
}
