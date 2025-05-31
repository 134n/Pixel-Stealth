using UnityEngine;
using UnityEngine.UI;
using UniRx;
using VContainer;
using KanKikuchi.AudioManager;

public class Menu : MonoBehaviour
{
    [SerializeField] Button buck;

    private ScreenChange screenChange;

    [Inject]
    public void Inject(ScreenChange screenChange)
    {
        this.screenChange = screenChange;
    }
    private void Start()
    {
        buck.OnClickAsObservable()
            .Subscribe(_ =>
            {
                SEManager.Instance.Play(SEPath.TAP1);
                screenChange.ChangeScreen(ScreenStatus.Screen.Title);
            })
            .AddTo(buck);
    }
}
