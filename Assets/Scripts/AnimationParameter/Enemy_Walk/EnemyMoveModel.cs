using UnityEngine;

public class EnemyMoveModel : MonoBehaviour
{
    public bool IsMoving { get; private set; }

    [SerializeField] private float threshold = 0.001f;

    private Vector3 prevPos;

    private void Awake()
    {
        prevPos = transform.position;
    }

    private void LateUpdate()
    {
        var delta = transform.position - prevPos;
        prevPos = transform.position;

        IsMoving = delta.sqrMagnitude > threshold * threshold;
    }
}