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
        if (retryScene == null) return;
        SceneManager.LoadScene(retryScene);
    }

    /// <summary>
    /// 残り時間によってランクを分ける
    /// </summary>
    public string RankCheck()
    {
        if (ResultDataStore.LimitTimeData >= 3f) return "S";
        if (ResultDataStore.LimitTimeData >= 2.5f) return "A+";
        if (ResultDataStore.LimitTimeData >= 2f) return "A";
        if (ResultDataStore.LimitTimeData >= 1.5f) return "B+";
        if (ResultDataStore.LimitTimeData >= 1f) return "B";
        return "C";
    }
}
