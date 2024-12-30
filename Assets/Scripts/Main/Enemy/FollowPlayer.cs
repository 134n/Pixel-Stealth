using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
     //NavMeshAgent2Dを使用するための変数
    [SerializeField] private Transform target; //追跡するターゲット

    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        agent. SetDestination(target.position);
    }
}
