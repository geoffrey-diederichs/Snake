using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void Easy()
    {
        SceneManager.LoadScene("Easy");
    }

    public void Normal()
    {
        SceneManager.LoadScene("Normal");
    }

    public void Hard()
    {
        SceneManager.LoadScene("Hard");
    }

    public void Leave()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
