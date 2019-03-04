using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectClicker : MonoBehaviour
{
    public GameObject addtoInventory, interactWithItem, lookAtItem;

    void Start()
    {
        setButtons(false);
    }

    // Update is called once per frame

    void Update()
    {
        
        if (Input.GetMouseButtonDown(1))
        {
            Vector3 pos = Input.mousePosition;
            Collider2D hitCollider = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(pos));

            if (hitCollider != null)
            {
                Debug.Log(hitCollider.name);

                addtoInventory.transform.position = new Vector3(pos.x, (pos.y + 20),pos.z);
                interactWithItem.transform.position = new Vector3(pos.x, (pos.y + 50), pos.z);
                lookAtItem.transform.position = new Vector3(pos.x, (pos.y + 80), pos.z);
                setButtons(true);
            }
            else
            {
                setButtons(false);
            }
        }
    }

    void setButtons(bool itemClicked)
    {
        addtoInventory.SetActive(itemClicked);
        interactWithItem.SetActive(itemClicked);
        lookAtItem.SetActive(itemClicked);
    }

}
