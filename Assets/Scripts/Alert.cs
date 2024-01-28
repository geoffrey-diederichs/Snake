using UnityEngine;
using UnityEngine.UI;

public class Alert : MonoBehaviour
{
    private int value = -3;
    Text alert;

    private bool doublePoints = false;

    private void Start()
    {
        alert = GetComponent<Text>();
    }

    private void Update()
    {
        if (this.doublePoints == true)
        {
            alert.text = "DOUBLE POINTS";
        }
        else
        {
            alert.text = "";
        }
    }

    public void setDouble(bool state)
    {
        this.doublePoints = state;
    }
}
