using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    void Awake()
    {
        items.Add(new Item("Book", 0, "A bad book sprite"));
        items.Add(new Item("Blue Potion", 1, "A bad blue potion"));
        items.Add(new Item("Green Potion", 2, "A bad green potion"));
        items.Add(new Item("Red Potion", 3, "A bad red potion"));
        items.Add(new Item("Glasses", 4, "A bad pair of glasses"));
        items.Add(new Item("Hat", 5, "A bad hat"));
        items.Add(new Item("Lightning", 6, "A bad drawing of lighting"));
        items.Add(new Item("Thunder", 7, "A bad drawing of thunder???"));
        items.Add(new Item("Key", 8, "A bad key"));
    }
}
