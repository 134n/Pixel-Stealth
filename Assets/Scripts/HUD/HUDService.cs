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

    [Inject]
    public void Inject(HUDManager hUDManager, PlayerStatus playerStatus, GoalController goalController)
    {
        this.hUDManager = hUDManager;
        this.playerStatus = playerStatus;
        this.goalController = goalController;
    }

    public static float limitTime = 300f;  // 例: 5分（300秒）

    public static string stageName;

    public static bool timeUp;

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

    public void TimerSet()
    {
        hUDManager.timerText.text = limitTime.ToString();
    }

    public void TimerStart()
    {
        limitTime -= 1 * Time.deltaTime;
        hUDManager.timerText.text = Mathf.FloorToInt(limitTime).ToString();
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
