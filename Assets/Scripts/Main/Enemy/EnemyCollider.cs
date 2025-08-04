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

    [Inject]
    public void Inject(PlayerView playerView, 
        GameOverService gameOverService, HUDService hUDService)
    {
        this.playerView = playerView;
        this.gameOverService = gameOverService;
        this.hUDService = hUDService;
    }

    public const string player = "Player";

    private void Start()
    {
        this.OnTriggerEnter2DAsObservable()
            .Where(other => other.gameObject.name == player)
            .Subscribe(other =>
            {
                BGMManager.Instance.FadeOut();
                BGMManager.Instance.Play(SEPath.JINGLE10, isLoop: false);
                
                playerView.Player.SetActive(false);
                gameOverService.DisplayGameOver();
                gameOverService.SetGameOverResultData();
                hUDService.TimerStop();
            })
            .AddTo(this);
    }
}
