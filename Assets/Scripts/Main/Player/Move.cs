using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    public InputAction inputMove;

    public Vector2 moveValue;

    public float speed = 0.001f;


    private void OnEnable()
    {
        inputMove.Enable();
    }

    private void OnDisable()
    {
        inputMove.Disable();
    }

    public void Update()
    {
        moveValue = inputMove.ReadValue<Vector2>();

        transform.Translate(
            moveValue.x * speed,
            moveValue.y * speed,
            0.0f);
    }
}
