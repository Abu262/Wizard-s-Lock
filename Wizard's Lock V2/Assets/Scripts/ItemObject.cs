using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : Inventory
{
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Item Added By Click");
            AddItem(2);
        }
    }
}
