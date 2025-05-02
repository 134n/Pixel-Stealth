using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultService
{
    public static string retryScene;
    
    public void SaveRetryScene()
    {
        retryScene = SceneManager.GetActiveScene().name;
        Debug.Log(retryScene);
    }

    public void LoadRetryScene()
    {
        Debug.Log(retryScene);
        if(retryScene == null)return;
        SceneManager.LoadScene(retryScene);
    }
}
