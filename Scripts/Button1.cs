using UnityEngine;
using UnityEngine.SceneManagement;

public class Button1 : MonoBehaviour
{

    public int sceneno;

     public void OnButtonClicked()
    {
        SceneManager.LoadScene(sceneno);
        Time.timeScale = 1f;
    }
}
