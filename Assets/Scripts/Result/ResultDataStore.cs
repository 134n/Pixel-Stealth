using YuRinChiLibrary.PlayFab;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class ResultDataStore
{
    public static float LimitTimeData { get; set; }

    public static string RankData { get; set; }

    private static string RankingName = "HighScore";

    public async UniTask SubmitScoreAsync()
    {
        int score = 10000 - (int)(LimitTimeData * 100); 
        if(score <= 0){ score = 0; }

        try
        {
            bool success = await PlayFabManager.Instance.SubmitMyScore(score, RankingName);

            if (success)
                Debug.Log("スコア送信成功");
            else
                Debug.Log("スコア送信失敗");
        }

        catch (Exception ex)
        {
            Debug.LogError($"スコア送信中の例外エラー: {ex.Message}");
        }
    }
}