using UnityEngine;
using KanKikuchi.AudioManager;

public class ItemEffectManager: MonoBehaviour
{
    [SerializeField] private GameObject getEffectPrefab;

    [SerializeField] private GameObject player;

    public void Play()
    {
        var effect = Instantiate(getEffectPrefab);
        effect.transform.position = player.transform.position;
        Destroy(effect, 0.5f);

        SEManager.Instance.Play(SEPath.TAP1);
    }
}
