using UnityEngine;
using UnityEngine.AI;
using UniRx;
using UniRx.Triggers;
using VContainer;
using Cysharp.Threading.Tasks;

public class EnemyTrack : MonoBehaviour
{

    [SerializeField] private Collider2D enemyScope;

    [SerializeField] private Transform target;

    [SerializeField] private Transform[] wanderingPoints;

    private FollowPlayer followPlayer;

    private WanderingEnemy wanderingEnemy;

    private WaitTime waitTime;

    

    [Inject]
    public void Inject(FollowPlayer followPlayer, WanderingEnemy wanderingEnemy, WaitTime waitTime)
    {
        this.followPlayer = followPlayer;
        this.wanderingEnemy = wanderingEnemy;
        this.waitTime = waitTime;
    }

    private bool isPatrol = true;

    private bool isFollow = false;

    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;

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

    public void Update()
    {
        if (wanderingPoints == null || wanderingPoints.Length == 0) Debug.LogError("wanderingPoints is null or empty!");

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
}
