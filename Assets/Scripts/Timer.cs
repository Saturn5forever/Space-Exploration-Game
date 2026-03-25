using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float roundedTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        timerText.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        roundedTime = Mathf.Round(Time.time * 100f) / 100f;
        timerText.text = roundedTime.ToString();
    }
}
