using Unity.Loading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour
{
    public void ChangeLevel()
    {
        Debug.Log("LEVELEVELLEVEL");
        if (SceneManager.GetActiveScene().buildIndex < SceneManager.sceneCountInBuildSettings)
        {
           SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
           Debug.Log("Loading Scene");
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
