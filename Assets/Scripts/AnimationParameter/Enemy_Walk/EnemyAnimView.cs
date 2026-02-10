using UnityEngine;
using VContainer;

public class EnemyAnimView : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private EnemyMoveModel model;

    [Inject]
    public void Inject(EnemyMoveModel model)
    {
        this.model = model;
    }

    private void Update()
    {
        if (animator == null) return;
        animator.SetBool("Walk", model.IsMoving);
    }
}