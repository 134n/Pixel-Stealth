using KanKikuchi.AudioManager;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using VContainer;

public class EnemyCollider : MonoBehaviour
{
    private PlayerView playerView;

    private GameOverService gameOverService;

    private HUDService hUDService;

    private ResultService resultService;

    [Inject]
    public void Inject(PlayerView playerView,
        GameOverService gameOverService, HUDService hUDService, ResultService resultService)
    {
        this.playerView = playerView;
        this.gameOverService = gameOverService;
        this.hUDService = hUDService;
        this.resultService = resultService;
    }

    public const string player = "Player";

    private void Start()
    {
        this.OnTriggerEnter2DAsObservable()
            .Where(other => other.gameObject.name == player)
            .Subscribe(other =>
            {
                BGMManager.Instance.FadeOut();
                BGMManager.Instance.Play(SEPath.NESRPGA121_INN, isLoop: false);

                resultService.SaveRetryScene();

                playerView.Player.SetActive(false);
                gameOverService.DisplayGameOver();
                gameOverService.SetGameOverResultData();
                hUDService.TimerStop();
            })
        .AddTo(this);
    }
}
