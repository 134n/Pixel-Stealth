using Unity.Mathematics;
using VContainer;
using VContainer.Unity;

public class SlimeParameter : ITickable
{
    private PlayerView playerView;

    private Move move;

    [Inject]
    public SlimeParameter(PlayerView playerView, Move move)
    {
        this.playerView = playerView;
        this.move = move;
    }

    void ITickable.Tick()
    {
        if (playerView.PlayerAnimator == null) return;
        
        float speedx = math.abs(move.moveValue.x);
        playerView.PlayerAnimator.SetFloat("speedx", speedx);
        
        float speedy = math.abs(move.moveValue.y);
        playerView.PlayerAnimator.SetFloat("speedy",speedy);
    }
}
