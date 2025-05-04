using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    public InputAction inputMove;

    public Vector2 moveValue;

    public float speed = 1f;


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
            moveValue.x * speed * Time.deltaTime,
            moveValue.y * speed * Time.deltaTime,
            0.0f);
    }
}
