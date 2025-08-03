using UnityEngine;
using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using System;
using UnityEngine.UI;
using UniRx;
using KanKikuchi.AudioManager;

public class GameStartCountDown : MonoBehaviour
{
    [SerializeField] Text countdownText;

    public async UniTask StartCountDownAsync(System.Threading.CancellationToken cancellation)
    {
        await UniTaskAsyncEnumerable.Create<int>(async (writter, innertoken) =>
        {
            for (int i = 3; i >= 1; i--)
            {
                SEManager.Instance.Play(SEPath.TAP1);
                await writter.YieldAsync(i);
                await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken: innertoken);
            }
        })
        .ForEachAwaitAsync(count =>
        {
            countdownText.text = count.ToString();
            return UniTask.CompletedTask;
        }, cancellationToken: cancellation);

        SEManager.Instance.Play(SEPath.TAP1);
        BGMManager.Instance.Play(BGMPath.BATTLE27);

        countdownText.text = "Start";
        await UniTask.Delay(TimeSpan.FromSeconds(1), cancellationToken: cancellation);
        countdownText.text = "";
        MessageBroker.Default.Publish(new CountDownCompletedMessage());
    }
}
public class CountDownCompletedMessage {}
