using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer
{
    public void Follow(NavMeshAgent agent, Transform target)
    {
        if (target == null || target.gameObject == null) { return; }
        agent.SetDestination(target.position);
    }
}

public class WanderingEnemy
{
    private int currentPointIndex;

    public void Wandering(NavMeshAgent agent, Transform[] wanderingPoints)
    {
        var randomPos = UnityEngine.Random.Range(0, wanderingPoints.Length);

        agent.SetDestination(wanderingPoints[currentPointIndex].position);

        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            currentPointIndex = (currentPointIndex + randomPos) % wanderingPoints.Length;
        }
    }
}
public class WaitTime
{
    public async UniTask WaitFiveSec()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(5));
    }
}
