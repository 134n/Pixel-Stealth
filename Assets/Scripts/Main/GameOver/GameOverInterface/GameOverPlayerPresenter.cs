using System;
using UniRx;
using VContainer;
using VContainer.Unity;

public class GameOverPlayerPresenter : IStartable, IDisposable
{
    readonly IGameOverInterface gameOverInterface;

    readonly IHitStream hitStream;

    readonly GameOverPlayerService tryGameOverService;

    readonly GameOverService gameOverDisplayService;

    readonly CompositeDisposable disposable = new();

    public GameOverPlayerPresenter(GameOverPlayerService tryGameOverService
        , IGameOverInterface gameOverInterface
        , IHitStream hitStream
        , GameOverService gameOverDisplayService)
    {
        this.tryGameOverService = tryGameOverService;
        this.gameOverInterface = gameOverInterface;
        this.hitStream = hitStream;
        this.gameOverDisplayService = gameOverDisplayService;
    }

    void IStartable.Start()
    {
        hitStream.HitPlayer
        .Subscribe(_ =>
        {
            if (!tryGameOverService.TryGameOver()) return;
            gameOverInterface.Hide();
            gameOverDisplayService.DisplayGameOver();
        })
        .AddTo(disposable);
    }
    public void Dispose()
    {
        disposable.Dispose();
    }
}
