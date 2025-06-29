using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WolfParameter : MonoBehaviour
{
    private Animator animator;

    private NavMeshAgent agent;

    public void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    public void Update()
    {
       if (agent == null || animator == null) return;

        Vector2 velocity = agent.velocity;

        // ワールド→ローカル方向への変換（自分の前方基準で計算）
        Vector2 localVelocity = transform.InverseTransformDirection(velocity);
        float moveX = localVelocity.x;
        float moveY = localVelocity.y;

        // 正規化して滑らかに（オプション）
        Vector2 moveDir = new Vector2(moveX, moveY).normalized;

        animator.SetFloat("MoveX", moveDir.x);
        animator.SetFloat("MoveY", moveDir.y);
    }
}