using UnityEngine;
using UnityEngine.UI;

public class MenuScore : MonoBehaviour
{
    public int value;
    public Text score;
	
    void OnEnable()
    {
    	value = PlayerPrefs.GetInt("score");
    }

    void Start()
    {
        score = GetComponent<Text>();
    }

    void Update()
    {
        score.text = value.ToString();
    }
}
