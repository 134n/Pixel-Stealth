using UnityEngine;

public class ItemKey 
{
    private readonly PlayerStatus player;

    private const int keyCount = 1;

    public ItemKey(PlayerStatus player)
    {
        this.player = player;
    }
    
    public void Pick()
    {
        player.Key += keyCount;
        
        Debug.Log(player.Key);
    }
}

public class ItemMatatabi
{
    private readonly PlayerStatus player;

    private const int MataCount = 1;

    public ItemMatatabi(PlayerStatus player)
    {
        this.player = player;
    }
    
    public void Pick()
    {
        player.Matatabi += MataCount;
        Debug.Log(player.Matatabi);
    }
}
