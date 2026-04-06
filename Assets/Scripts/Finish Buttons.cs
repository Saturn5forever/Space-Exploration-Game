using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishButtons : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip nextLevelSound;
    public AudioClip restartSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void ChangeLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            StartCoroutine(ChangeLevelCoroutine());
        }
        
    }
    public void Restartlevel()
    {        
        StartCoroutine(RestartLevelCoroutine());
        
        
    }

    IEnumerator ChangeLevelCoroutine()
    {
        audioSource.PlayOneShot(nextLevelSound);
        yield return new WaitWhile(()=> audioSource.isPlaying);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator RestartLevelCoroutine()
    {
        audioSource.PlayOneShot(restartSound);
        yield return new WaitWhile(()=> audioSource.isPlaying);
        if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
        
    }
}
