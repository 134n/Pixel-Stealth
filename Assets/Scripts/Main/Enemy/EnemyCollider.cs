using UniRx;
using UniRx.Triggers;
using UnityEngine;
using VContainer;

public class EnemyCollider : MonoBehaviour
{
    private ScreenChange screenChange;

    [Inject] public void Inject(ScreenChange screenChange) => this.screenChange = screenChange;

    public const string player = "Player";

    private void Start()
    {
        this.OnTriggerEnter2DAsObservable()
            .Where(other => other.gameObject.name == player)
            .Subscribe(other => screenChange.ScreenChanged(ScreenStatus.Screen.Result))
            .AddTo(this);
    }
}
