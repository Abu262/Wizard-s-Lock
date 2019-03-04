using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    void Awake()
    {
        items.Add(new Item("Candle", 0, "Candle"));
        items.Add(new Item("Diary", 1, "Diary"));
        items.Add(new Item("Fire Ember", 2, "Fire Ember"));
        items.Add(new Item("Glove", 3, "Glove"));
        items.Add(new Item("Lightning in a Jar", 4, "Lightning in a Jar"));
        items.Add(new Item("Ring", 5, "Ring"));
        items.Add(new Item("Thor's Toothpick", 6, "Thor's Toothpick"));
    }
}
