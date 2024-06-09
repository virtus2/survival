using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerActive : MonoBehaviour
{
    public Player player;
    private List<ActiveAbility> active;
    private List<float> coolDown;
    WaitForSeconds delay50 = new WaitForSeconds(0.05f);
    public void Init()
    {
        active = new List<ActiveAbility>(15);
        coolDown = new List<float>(15);
        StartCoroutine(UpdateActive());
    }
    public void AddAbility(Item item)
    {
        for(int i=0; i<item.active.Count; i++)
        {
            active.Add(item.active[i]);
            coolDown.Add(0f);
        }
    }

    public IEnumerator UpdateActive()
    {
        while (true)
        {
            if(active.Count > 0)
            {
                for(int i=0; i<active.Count; i++)
                {
                    coolDown[i] += Time.deltaTime;
                    if (coolDown[i] >= active[i].cooldown)
                    {
                        GameObject target = player.monsterManager.GetClosestMonster();
                        if (target == null)
                        {
                            yield return null;
                        }
                        else
                        {
                            active[i].UseAbility(player, target);
                            coolDown[i] = 0f;
                        }
                    }
                }
            }
            yield return null;
        }

    }

}
