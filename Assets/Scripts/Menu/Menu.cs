using UnityEngine;
using UnityEngine.UI;
using UniRx;
using VContainer;

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
            .Subscribe(_ => screenChange.ScreenChanged(ScreenStatus.Screen.Title));
    }
}
