using UniRx;
using UnityEngine;
using UnityEngine.UI;
using KanKikuchi.AudioManager;

public class SetTitleAudio : MonoBehaviour
{
    public void Awake()
    {
        Button[] allButtons = FindObjectsOfType<Button>(true);

        foreach (var btn in allButtons)
        {
            btn.OnClickAsObservable()
                .Subscribe(_ => SEManager.Instance.Play(SEPath.TAP1))
                .AddTo(btn);
        }
    }
}
