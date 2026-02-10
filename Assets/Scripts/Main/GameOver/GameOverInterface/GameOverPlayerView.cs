using System;
using UniRx;
using UniRx.Triggers;
using UnityEngine;

public class GameOverPlayerView : MonoBehaviour , IGameOverInterface , IHitStream 
{
    private readonly Subject<Unit> hitPlayer = new();
    public IObservable<Unit> HitPlayer => hitPlayer;

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void Start()
    {
        this.OnTriggerEnter2DAsObservable()
            .Where(t => t.CompareTag("Enemy"))
            .Subscribe(_ =>
            {
                Debug.Log("hit enemy");
                hitPlayer.OnNext(Unit.Default);
            })
            .AddTo(this);
    }
}
