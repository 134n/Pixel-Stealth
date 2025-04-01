using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class PlayerView : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public GameObject Player => player;

    public void DestroyObj(GameObject gameObject) => Destroy(gameObject);
}
