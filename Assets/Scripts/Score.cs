using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int value = -3;
    public Text score;

    void Start()
    {
        score = GetComponent<Text>();
    }

    void Update()
    {
        score.text = value.ToString();
    }

    public void UpdateScore(int inc)
    {
        this.value += inc;
    }

    void OnDisable()
    {
    	PlayerPrefs.SetInt("score", value);
    }
}
