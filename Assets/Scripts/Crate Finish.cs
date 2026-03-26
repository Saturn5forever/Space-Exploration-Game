using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrateFinish : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    public TextMeshProUGUI highScoreText;
    private float roundedTime;
    public float finishTime;
    private string highScoreKey;

    private bool timerActive = true;

    void Awake()
    {
        timerText.enabled = true;
    }

    void Start()
    {
        highScoreKey = "Highscore_" + SceneManager.GetActiveScene().name;
        LoadHighScore();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            collision.gameObject.GetComponentInChildren<Gravity>().enabled = true;
            finishTime = roundedTime;
            timerActive = false;
            ChangeHighScore();
        }
    }

    void Update()
    {
        if (timerActive)
        {
            roundedTime = Mathf.Round(Time.time * 100f) / 100f;
            timerText.text = roundedTime.ToString();     
        }
            
    }
    
    void LoadHighScore()
    {
        float savedHighScore = PlayerPrefs.GetFloat(highScoreKey, 0);
        highScoreText.text = "High: " + savedHighScore.ToString();
    }

    void ChangeHighScore()
    {
        float savedHighScore = PlayerPrefs.GetFloat(highScoreKey, 0);
        if(finishTime < savedHighScore)
        {
            PlayerPrefs.SetFloat(highScoreKey, finishTime);
            PlayerPrefs.Save();
            Debug.Log("SAVED HIGHSCORE");
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        float savedHighScore = PlayerPrefs.GetFloat(highScoreKey, 0);
        highScoreText.text = "High: " + savedHighScore; 
    }
}   

