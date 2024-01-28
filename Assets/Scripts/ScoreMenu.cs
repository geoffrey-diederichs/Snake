using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreMenu : MonoBehaviour
{
    public void Menu()
    {
    	SceneManager.LoadScene("Menu");
    }

    public void Leave()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
}
