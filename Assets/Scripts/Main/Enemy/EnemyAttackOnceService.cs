using System;
using Cysharp.Threading.Tasks;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using VContainer;

public class EnemyAttackOnceService
{
    private readonly EnemyAttackOnceView enemyAttackOnceView;

    [Inject]
    public EnemyAttackOnceService(
        EnemyAttackOnceView enemyAttackOnceView)
    {
        this.enemyAttackOnceView = enemyAttackOnceView;
    }

    public void PlayerSearchEnable()
    {
        enemyAttackOnceView.SearchAria.OnTriggerEnter2DAsObservable()
            .Where(collider => collider.CompareTag("Player"))
            .Subscribe(_ =>
            {
                if (!enemyAttackOnceView.IsPlayerSearch.Value)
                    enemyAttackOnceView.SetPlayerSearch(true);
            })
            .AddTo(enemyAttackOnceView);
    }

    public void PlayerSearchDisable()
    {
        enemyAttackOnceView.SearchAria.OnTriggerExit2DAsObservable()
            .Where(collider => collider.CompareTag("Player"))
            .Subscribe(_ =>
            {
                if (enemyAttackOnceView.IsPlayerSearch.Value)
                    enemyAttackOnceView.SetPlayerSearch(false);
            })
            .AddTo(enemyAttackOnceView);
    }

    public void PlayerSearchEXEnable()
    {
        enemyAttackOnceView.SearchAriaEX.OnTriggerEnter2DAsObservable()
            .Where(collider => collider.CompareTag("Player"))
            .Subscribe(_ =>
            {
                if (!enemyAttackOnceView.IsPlayerSearchEX.Value)
                    enemyAttackOnceView.SetPlayerSearchEX(true);
            })
            .AddTo(enemyAttackOnceView);
    }

    public void PlayerSearchEXDisable()
    {
        enemyAttackOnceView.SearchAriaEX.OnTriggerExit2DAsObservable()
            .Where(collider => collider.CompareTag("Player"))
            .Subscribe(_ =>
            {
                if (enemyAttackOnceView.IsPlayerSearchEX.Value)
                    enemyAttackOnceView.SetPlayerSearchEX(false);
            })
            .AddTo(enemyAttackOnceView);
    }

    public void EnemyAttackOnce()
    {
        Observable.Interval(TimeSpan.FromSeconds(1))
        .Where(_ => !enemyAttackOnceView.IsAttack)
        .Where(_ => enemyAttackOnceView.IsPlayerSearch.Value)
        .Subscribe(async _ =>
        {
            enemyAttackOnceView.SetIsAttack(true);

            await UniTask.Delay(TimeSpan.FromSeconds(1));

            if (!enemyAttackOnceView.IsPlayerSearch.Value)
            {
                enemyAttackOnceView.SetIsAttack(false);
                return;
            }
            enemyAttackOnceView.Agent.speed = 5f;

            enemyAttackOnceView.SetIsAttack(true);

            enemyAttackOnceView.Agent.SetDestination(enemyAttackOnceView.Target.position);

            await UniTask.WaitUntil(() =>
                !enemyAttackOnceView.Agent.pathPending && 
                enemyAttackOnceView.Agent.remainingDistance <= enemyAttackOnceView.Agent.stoppingDistance
            );

            enemyAttackOnceView.SetIsAttack(false);
        })
        .AddTo(enemyAttackOnceView);
    }

    public void EnemyAttackOnceForAgent()
    {
        Observable.Interval(TimeSpan.FromSeconds(5))
            .Where(_ => !enemyAttackOnceView.IsAttackEX)
            .Where(_ => !enemyAttackOnceView.IsPlayerSearch.Value)
            .Where(_ => enemyAttackOnceView.IsPlayerSearchEX.Value)
            .Subscribe(async _ =>
            {
                enemyAttackOnceView.SetIsAttackEX(true);
                await UniTask.Delay(TimeSpan.FromSeconds(1));
                if (!enemyAttackOnceView.IsPlayerSearchEX.Value)
                {
                    enemyAttackOnceView.SetIsAttackEX(false);
                    return;
                }
                enemyAttackOnceView.Agent.speed = 1f;
                enemyAttackOnceView.Agent.SetDestination(enemyAttackOnceView.Target.position);
                enemyAttackOnceView.SetIsAttackEX(false);
            })
            .AddTo(enemyAttackOnceView);
    }
}
