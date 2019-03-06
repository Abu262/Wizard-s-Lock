using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectClicker : MonoBehaviour
{
    public GameObject addtoInventory, interactWithItem, lookAtItem;
    public Button adder, interacter, looker;
    public static GameObject selectedItem;
    public Vector3 pos;
    public Collider2D hitCollider;
    public Vector3 colliderPosition;

    // my stuff
    ////////
    public Inventory invscript;    // you didnt have your inventory script called
    int objid = -1;   // you had everything in the database set as id numbers so i rolled with that
    ////////

    void Start()
    {

        // get the buttons
        Button addbtn = adder.GetComponent<Button>(); //add
        Button lookbtn = looker.GetComponent<Button>(); //look
        Button interactbtn = interacter.GetComponent<Button>(); //interact

        // give the buttons a function when they are clicked, functions at the bottom
        addbtn.onClick.AddListener(addtask);   // activating the add button
        lookbtn.onClick.AddListener(looktask);  // activating the look button
        interactbtn.onClick.AddListener(interacttask); //activating the interact button
        SetButtons(false);
        selectedItem = null;
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
                if(hitCollider.gameObject.name == "Ember")
                {
                    Debug.Log("Ember Selected");
                    selectedItem = GameObject.Find("Ember");
                    objid = 2; //get the ember's ID for adding to inventory
                }
                //didnt need this
                //if (hitCollider.gameObject.name == "Add to Inventory")
                //{

                   // Debug.Log("Here");
                //}
            }

            else
            {
                SetButtons(false);
            }

        }

    }


    //THESE ARE THE BUTTONS
    ///////////////////////
    //for picking up items
    void addtask()
    {

        //candle
        if (objid == 0)
        {
            Debug.Log("I'll just pocket this ember");
            invscript.AddItem(0);
          
            objid = -1;
        }
        //diary
        else if (objid == 1)
        {
            invscript.AddItem(1);
            objid = -1;
        }
        //ember
        else if (objid == 2)
        {
            invscript.AddItem(2);
            objid = -1;
            Destroy(selectedItem);  //destroys the ember
        }
        //glove
        else if (objid == 3)
        {
            invscript.AddItem(3);
            objid = -1;
        }
        //lightning in bottle
        else if (objid == 4)
        {
            invscript.AddItem(4);
            objid = -1;
        }
        //ring
        else if (objid == 5)
        {
            invscript.AddItem(5);
            objid = -1;
        }
        //toothpick
        else if (objid == 6)
        {
            invscript.AddItem(6);
            objid = -1;
        }
    }
    //for looking at objects
    void looktask()
    {
        if (objid == 2)
        {
            Debug.Log("It's a piece of ember from Mr. Fireplace");
        }
    }
    //for interacting with objects
    void interacttask()
        {
            Debug.Log("I'm interacting with the object!");
        }
    //////////////////////////////////

    void SetButtons(bool itemClicked)
    {
        addtoInventory.SetActive(itemClicked);
        interactWithItem.SetActive(itemClicked);
        lookAtItem.SetActive(itemClicked);
    }
    

}
