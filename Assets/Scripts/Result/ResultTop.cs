using UnityEngine;
using UnityEngine.UI;
using UniRx;
using VContainer;

public class ResultTop : MonoBehaviour
{
    [SerializeField] Button retry;

    [SerializeField] Button toTitle;

    private ScreenChange screenChange;

    [Inject]
    public void Inject(ScreenChange screenChange)
    {
        this.screenChange = screenChange;
    }

    public void Start()
    {
        toTitle.OnClickAsObservable()
            .Subscribe(_ => screenChange.ChangeScreen(ScreenStatus.Screen.Title));

        retry.OnClickAsObservable()
            .Subscribe(_ => screenChange.ChangeScreen(ScreenStatus.Screen.Stage1));
    }
}
