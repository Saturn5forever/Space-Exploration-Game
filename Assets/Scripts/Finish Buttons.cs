using Unity.Loading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public void ChangeLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
        }
        else
        {
            SceneManager.LoadScene(0);
        }
        
    }
    public void Restartlevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
