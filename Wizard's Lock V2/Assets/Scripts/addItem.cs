using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addItem : Inventory
{
    public GameObject selItem = ObjectClicker.selectedItem;

    // Start is called before the first frame update
    void Awake()
    {
    }
    
    void Update() //update?? start?
    {
        Debug.Log("Ember Added");
        if (selItem.name == "Ember")
            AddItem(2);
    }
}
