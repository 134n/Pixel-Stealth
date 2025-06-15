using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public GameObject Player => player;

    [SerializeField] private Animator playerAnimator;

    public Animator PlayerAnimator => playerAnimator;

    public void DestroyObj(GameObject gameObject) => Destroy(gameObject);
}
