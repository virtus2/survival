using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Supply : MonoBehaviour
{

    public Player player;
    public GameObject supplyPrefab;
    public void DropSupply(Vector2 position)
    {
        // FIX: LeanPool 써야할수도있음
        Instantiate(supplyPrefab, position, new Quaternion(0,0,0,0));
    }

    public void DestroySupply()
    {
        Destroy(this);
    }
}
