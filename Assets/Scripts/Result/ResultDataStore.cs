using YuRinChiLibrary.PlayFab;
using Cysharp.Threading.Tasks;
using System;
using UnityEngine;
using VContainer;

public class ResultDataStore
{
    public static float LimitTimeData { get; set; }

    public static string RankData { get; set; }

    private readonly ResultService resultService;

    private string statisticName;

    [Inject]
    public ResultDataStore(ResultService resultService)
    {
        this.resultService = resultService;
    }

    public async UniTask SubmitScoreAsync()
    {
        int score = 10000 - (int)(LimitTimeData * 100);
        if (score <= 0) { score = 0; }

        statisticName = resultService.GetLoadScene()?? "DefaultStage";

        try
        {
            bool success = await PlayFabManager.Instance.SubmitMyScore(score, statisticName);

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