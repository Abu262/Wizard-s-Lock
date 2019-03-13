using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Inventory instance = null;

    public int slotsY;
    public GUISkin skin;
    public static List<Item> inventory = new List<Item>();
    public List<Item> slots = new List<Item>();
    private bool showInventory = true;
    public ItemDatabase database;
    private bool showTooltip;
    private string tooltip;

    private bool draggingItem;
    private Item draggedItem;
    private int prevIndex;

    void Awake()
    {
        
    }

    void Start()
    {
        for (int i = 0; i < slotsY; i++)
        {
            slots.Add(new Item());
            inventory.Add(new Item());
        }
        database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();
        /*AddItem(0);
        AddItem(1);
        AddItem(2);
        AddItem(3);
        AddItem(4);
        AddItem(5);
        AddItem(6);*/
    }

    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            showInventory = !showInventory;
        }
    }

    void OnGUI()
    {
        tooltip = "";
        //GUI.skin = skin;
        if(showInventory)
        {
            DrawInventory();
            if (showTooltip)
                GUI.Box(new Rect(Event.current.mousePosition.x + 15f, Event.current.mousePosition.y, 200, 200), tooltip);
        }
        if(draggingItem)
        {
            GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 50, 50), draggedItem.itemIcon);
        }
    }

    void DrawInventory()
    {
        Event e = Event.current;
        int i = 0;
        for(int y = 0; y < slotsY; y++)
        {
            Rect slotRect = new Rect(30, y * 47, 40, 40);
            GUI.Box(slotRect, y.ToString()); //skin.GetStyle("Slot"));
            slots[i] = inventory[i];
            if(slots[i].itemName != null)
            {
                GUI.DrawTexture(slotRect, inventory[i].itemIcon);
                if(slotRect.Contains(e.mousePosition))
                {
                    tooltip = CreateTooltip(slots[i]);
                    showTooltip = true;
                    if(e.button == 0 && e.type == EventType.MouseDrag && !draggingItem)
                    {
                        draggingItem = true;
                        prevIndex = i;
                        draggedItem = slots[i];
                        inventory[i] = new Item();
                    }
                    if(e.type == EventType.MouseUp && draggingItem)
                    {
                        inventory[prevIndex] = inventory[i];
                        inventory[i] = draggedItem;
                        draggingItem = false;
                        draggedItem = null;
                    }
                    if (e.isMouse && e.type == EventType.MouseDown && e.button == 1)
                    {
                        useItem(slots[i], i, true);
                    }
                }
            }
            else
            {
                if(slotRect.Contains(e.mousePosition))
                {
                    if(e.type == EventType.MouseUp && draggingItem)
                    {
                        inventory[i] = draggedItem;
                        draggingItem = false;
                        draggedItem = null;
                    }
                }
            }
            if(tooltip == "")
            {
                showTooltip = false;
            }

            i++;
        }
    }

    string CreateTooltip(Item item)
    {
        tooltip = item.itemName + "\n\n" + item.itemDesc;
        return tooltip;
    }

    void RemoveItem(int id)
    {
        for(int i = 0; i < inventory.Count; i++)
        {
            if(inventory[i].itemID == id)
            {
                inventory[i] = new Item();
                break;
            }
        }
    }

    virtual public void AddItem(int id)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].itemName == null)
            {
                for(int j = 0; j < database.items.Count; j++)
                {
                    if(database.items[j].itemID == id)
                    {
                        inventory[i] = database.items[j];
                        Debug.Log("Added Item " + database.items[id].itemName);
                    }
                }
                break;
            }
        }
    }

    public void useStaff()
    {
        for (int i = 0; i<inventory.Count; i++)
        {
            if (inventory[i].itemName == "Staff")
            {
                inventory[i] = null;
                Debug.Log("Used Staff");
            }
        }
    }

    private void useItem(Item item, int slot, bool deleteItem)
    {
        if (deleteItem)
        {
            //inventory[slot] = new Item();
        }
    }

    public bool InventoryContains(int id)
    {
        bool result = false;
        for(int i = 0; i < inventory.Count; i++)
        {
            result = inventory[i].itemID == id;
            if(result)
            {
                break;
            }
        }
        return result;
    }
}
