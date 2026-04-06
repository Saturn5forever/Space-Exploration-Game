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

    public GameObject nextLevelButton;
    public GameObject restartLevelButton;
    public TextMeshProUGUI newHighText;

    AudioSource audioSource;
    public AudioClip finishSound;
    public AudioClip newHighscoreSound;

    void Awake()
    {
        timerText.enabled = true;
        nextLevelButton.SetActive(false);
        restartLevelButton.SetActive(false);
        newHighText.text = "";
    }

    void Start()
    {
        highScoreKey = "Highscore_" + SceneManager.GetActiveScene().name;
        LoadHighScore();
        audioSource = GetComponent<AudioSource>();
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            collision.gameObject.GetComponentInChildren<Gravity>().enabled = true;
            GetComponent<Movement>().enabled = false;
            finishTime = roundedTime;
            timerActive = false;
            nextLevelButton.SetActive(true);
            restartLevelButton.SetActive(true);
            ChangeHighScore();
            audioSource.PlayOneShot(finishSound);
            

        }
    }

    void Update()
    {
        if (timerActive)
        {
            roundedTime = Mathf.Round(Time.timeSinceLevelLoad * 100f) / 100f;
            timerText.text = roundedTime.ToString();     
        }
            
    }
    
    void LoadHighScore()
    {
        float savedHighScore = PlayerPrefs.GetFloat(highScoreKey, 100000000000);
        highScoreText.text = "High: " + savedHighScore.ToString();
    }

    void ChangeHighScore()
    {
        float savedHighScore = PlayerPrefs.GetFloat(highScoreKey, 100000000000);
        if(finishTime < savedHighScore)
        {
            PlayerPrefs.SetFloat(highScoreKey, finishTime);
            PlayerPrefs.Save();
            newHighText.text = "New Highscore!";
            audioSource.PlayOneShot(newHighscoreSound);
            UpdateUI();
        }
    }

    void UpdateUI()
    {
        float savedHighScore = PlayerPrefs.GetFloat(highScoreKey, 100000000000);
        highScoreText.text = "High: " + savedHighScore; 
    }
}   

