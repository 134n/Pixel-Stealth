using UniRx;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]

public class EnemyAttackOnceView : MonoBehaviour
{
    [SerializeField] private Transform target;
    public Transform Target => target;

    [SerializeField] private GameObject slime;
    public GameObject Slime => slime;

    [SerializeField] private float slimeSpeed;
    public float SlimeSpeed => slimeSpeed;

    [SerializeField] private Collider2D searchAria;
    public Collider2D SearchAria => searchAria;

    [SerializeField] private Collider2D searchAriaEX;
    public Collider2D SearchAriaEX => searchAriaEX;

    [SerializeField] private NavMeshAgent agent;
    public NavMeshAgent Agent => agent;

    private readonly BoolReactiveProperty isPlayerSearch = new(false);

    public IReadOnlyReactiveProperty<bool> IsPlayerSearch => isPlayerSearch;

    private readonly BoolReactiveProperty isPlayerSearchEX = new(false);

    public IReadOnlyReactiveProperty<bool> IsPlayerSearchEX => isPlayerSearchEX;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.obstacleAvoidanceType = ObstacleAvoidanceType.NoObstacleAvoidance;
    }

    public void SetPlayerSearch(bool value)
    {
        isPlayerSearch.Value = value;
    }

    public void SetPlayerSearchEX(bool value)
    {
        isPlayerSearchEX.Value = value;
    }

    private bool isAttack = false;
    public bool IsAttack => isAttack;

    public void SetIsAttack(bool value)
    {
        isAttack = value;
    }

    private bool isAttackEX = false;
    public bool IsAttackEX => isAttackEX;

    public void SetIsAttackEX(bool value)
    {
        isAttackEX = value;
    }
}
