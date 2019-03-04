using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestItem : MonoBehaviour
{

    public string itemName;
    public int itemID;
    public string itemDesc;

    // Start is called before the first frame update

    public void Item(string name, int id, string desc)
    {
        itemName = name;
        itemID = id;
        itemDesc = desc;
    }

    public string ReturnItemDesc()
    {
        return itemDesc;
    }

        void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
