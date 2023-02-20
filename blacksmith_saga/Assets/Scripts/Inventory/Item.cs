using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    // Start is called before the first frame update
    public enum ItemType
    {
        BlueShard,
        RedShard,
        IronShard,
        GoldShard
    }

    public ItemType itemType;
    public int amount;
    

    public Sprite GetSprite()
    {
        switch (itemType)
        {
            default:
                case ItemType.BlueShard: return ItemAssets.Instance.shardBlue;
                case ItemType.RedShard: return ItemAssets.Instance.shardRed;
                case ItemType.GoldShard: return ItemAssets.Instance.shardGold;
                case ItemType.IronShard: return ItemAssets.Instance.shardIron;
        }
    }
}
