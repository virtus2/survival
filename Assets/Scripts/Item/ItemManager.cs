using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public List<Item> itemList;
    public List<bool> isUsed;
    private int usedItem;
    private void Start()
    {
        usedItem = 0;
    }

    public void ResetUsedItemList()
    {
        for(int i=0; i<isUsed.Count; ++i)
        {
            isUsed[i] = false;
        }
    }
    public List<Item> GetUnusedRandomItems(int amount)
    {
        List<Item> randomItem = new List<Item>(amount);
        List<int> rnd = new List<int>(amount);
        if (usedItem >= itemList.Count)
        {
            // 모든 아이템을 다 사용했을때
            randomItem.Add(itemList[0]);
            randomItem.Add(itemList[1]);
            randomItem.Add(itemList[2]);
        }
        while (randomItem.Count < amount)
        {
            // FIX: 중복안나오게
            int r = Random.Range(0, itemList.Count);
            if (rnd.Contains(r))
            {
                continue;
            }
            else
            {
                if (!isUsed[r])
                {
                    rnd.Add(r);
                    randomItem.Add(itemList[r]);
                }

            }
        }
        if (randomItem.Count != amount)
            return null;
        else 
            return randomItem;
    }

    public void SetUsedFlag(Item item)
    {
        usedItem++;
        isUsed[item.itemID] = true;
    }
}
