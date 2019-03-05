﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectClicker : MonoBehaviour
{
    public GameObject addtoInventory, interactWithItem, lookAtItem;
    public Vector3 pos;
    public Collider2D hitCollider;
    public Vector3 colliderPosition;

    void Start()
    {
        SetButtons(false);
    }

    // Update is called once per frame

    void Update()
    {
        
        if (Input.GetMouseButtonDown(1))
        {
            pos = Input.mousePosition;
            hitCollider = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(pos));

            if (hitCollider != null)
            {
                colliderPosition = hitCollider.transform.position;
                addtoInventory.transform.position = new Vector3(pos.x, (pos.y + 100),pos.z);
                interactWithItem.transform.position = new Vector3(pos.x, (pos.y + 70), pos.z);
                lookAtItem.transform.position = new Vector3(pos.x, (pos.y + 40), pos.z);
                SetButtons(true);
            }

            else
            {
                SetButtons(false);
            }

        }

    }

    void SetButtons(bool itemClicked)
    {
        addtoInventory.SetActive(itemClicked);
        interactWithItem.SetActive(itemClicked);
        lookAtItem.SetActive(itemClicked);
    }
    

}
