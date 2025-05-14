using Cysharp.Threading.Tasks;
using UniRx;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using VContainer;

public class HUDService
{
    private HUDManager hUDManager;

    private PlayerStatus playerStatus;

    private GoalController goalController;

    private GameOverService gameOverService;

    [Inject]
    public void Inject(HUDManager hUDManager, PlayerStatus playerStatus, GoalController goalController
        , GameOverService gameOverService)
    {
        this.hUDManager = hUDManager;
        this.playerStatus = playerStatus;
        this.goalController = goalController;
        this.gameOverService = gameOverService;
    }

    public static string stageName;

    private static bool isTimerRun = true;

    public bool IsTimerRun
    {
        set => isTimerRun = value;
        get => isTimerRun;
    } 

    public void TimerStop()
    {
        if(!IsTimerRun) return;
        IsTimerRun = false;
    }

    public void ObjectiveText()
    {
        playerStatus.Key
            .Select(t => $"キーを取得しよう\n残り {hUDManager.itemSlots.Count - t} 個")
            .Subscribe(text => hUDManager.objectiveText.text = text)
            .AddTo(hUDManager);

        playerStatus.Key
            .Where(t => playerStatus.Key.Value == goalController.RequiredItemCount)
            .Select(t => "ゴールへ行け！")
            .Subscribe(text => hUDManager.objectiveText.text = text)
            .AddTo(hUDManager);
    }

    public void StageName()
    {
        stageName = SceneManager.GetActiveScene().name;
        hUDManager.stageText.text = stageName;
    }

    public void StartTimer()
    {
        isTimerRun = true;
        UpdateTimerText();
    }

    public void UpdateTimer()
    {
        if (!isTimerRun) return;

        hUDManager.limitTime -= 1 * Time.deltaTime;

        if (hUDManager.limitTime <= 0f)
        {
            hUDManager.limitTime = 0f;
            isTimerRun = false;
            gameOverService.LimitTimeSubject();
        }

        UpdateTimerText();
    }

    public void UpdateTimerText()
    {
        hUDManager.timerText.text = "Limit:" + Mathf.FloorToInt(hUDManager.limitTime).ToString();
    }

    public void CollectItem()
    {
        hUDManager.OnItemCollected.OnNext(Unit.Default);
    }

    public void ItemPickUI()
    {
        //アイテム個数分グレー表示
        for (int i = 0; i < hUDManager.itemSlots.Count; i++)
        {
            hUDManager.itemSlots[i].sprite = hUDManager.emptySprite;
            hUDManager.itemSlots[i].enabled = i < hUDManager.itemSlots.Count;
        }

        // アイテム取得イベント購読
        hUDManager.OnItemCollected
            .Subscribe(async _ =>
            {
                await AnimateCollectItem();
            })
            .AddTo(hUDManager);
    }

    private async UniTask AnimateCollectItem()
    {
        Image slot = hUDManager.itemSlots[playerStatus.Key.Value - 1];

        slot.sprite = hUDManager.collectedSprite;

        // アニメーション効果
        Vector3 originalScale = slot.rectTransform.localScale;
        slot.rectTransform.localScale = Vector3.zero;

        float duration = 0.2f;
        float time = 0f;

        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;
            slot.rectTransform.localScale = Vector3.Lerp(Vector3.zero, originalScale, t);
            await UniTask.Yield();
        }

        slot.rectTransform.localScale = originalScale;
    }
}
