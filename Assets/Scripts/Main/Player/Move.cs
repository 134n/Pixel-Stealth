using UniRx;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    public InputAction inputMove;

    public Vector2 moveValue;

    public float speed = 1f;

    private bool canMove;

    private void OnEnable()
    {
        inputMove.Enable();

        MessageBroker.Default.Receive<CountDownCompletedMessage>()
            .Subscribe(_ =>
            {
                canMove = true;
            })
            .AddTo(this);
    }

    private void OnDisable()
    {
        inputMove.Disable();
    }

    private void Update()
    {
        if (!canMove) return;

        moveValue = inputMove.ReadValue<Vector2>();

        transform.Translate(
            moveValue.x * speed * Time.deltaTime,
            moveValue.y * speed * Time.deltaTime,
            0.0f);
    }
}
