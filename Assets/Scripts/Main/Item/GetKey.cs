using UnityEngine;
using VContainer;

public class GetKey
{
    private PlayerStatus playerStatus;

    [Inject]
    public void Inject(PlayerStatus playerStatus)
    {
        this.playerStatus = playerStatus;
    }

    public void ItemPick()
    {
        playerStatus.Key.Value += 1;
        Debug.Log(playerStatus.Key);
    }
}
