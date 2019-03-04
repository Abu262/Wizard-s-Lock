﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemObject : Inventory
{
    void Awake()
    {
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                Debug.Log("Item Added By Click");
                AddItem(2);
            }
        }
    }
}
