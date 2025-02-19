using UnityEngine;
using UnityEngine.AI;
using UniRx;
using UniRx.Triggers;
using VContainer;
using Cysharp.Threading.Tasks;

public class EnemyTrack : MonoBehaviour
{
    [SerializeField] private GameObject enemyScope;

    [SerializeField] private Transform target;

    [SerializeField] private Transform[] wanderingPoints;

    private FollowPlayer followPlayer;

    private WanderingEnemy wanderingEnemy;

    private WaitTime waitTime;

    [Inject] public void Inject(FollowPlayer followPlayer) { this.followPlayer = followPlayer; }

    [Inject] public void Inject(WanderingEnemy wanderingEnemy) { this.wanderingEnemy = wanderingEnemy; }

    [Inject] public void Inject(WaitTime waitTime) { this.waitTime = waitTime; }

    private bool isPatrol = false;
    private bool isFollow = false;

    private NavMeshAgent agent;

    public void Update()
    {
        if (isPatrol)
        {
            wanderingEnemy.Wandering(agent, wanderingPoints);
        }

        if (isFollow)
        {
            isPatrol = false;
            followPlayer.Follow(agent, target);
        }
    }

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        enemyScope.OnTriggerEnter2DAsObservable()
            .Subscribe(_ =>
            {
                if (isFollow == false)
                    isFollow = true;
            })
            .AddTo(this);

        enemyScope.OnTriggerExit2DAsObservable()
            .SelectMany(_ =>
                waitTime.WaitFiveSec().ToObservable().TakeUntil(enemyScope.OnTriggerEnter2DAsObservable())
            )
            .Subscribe(async _ =>
            {
                isFollow = false;
                await waitTime.WaitFiveSec().ToObservable();
                isPatrol = true;
            })
            .AddTo(this);
    }
}
