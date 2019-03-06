using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectClicker : MonoBehaviour
{
    public GameObject addtoInventory, interactWithItem, lookAtItem;
    public Button adder, interacter, looker;
    public static GameObject selectedItem;
    public Vector3 pos;
    public Collider2D hitCollider;
    public Vector3 colliderPosition;
    public Text Desc;
    public InputField Safe;
    // my stuff
    ////////
    public Inventory invscript;    // you didnt have your inventory script called
    int objid = -1;   // you had everything in the database set as id numbers so i rolled with that
    bool safeenabled = true;
    public GameObject wallsafe;
    ////////

    void Start()
    {
        Safe = Safe.GetComponent<InputField>();
        Safe.enabled = false;
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
        //some safe bullshit
        if (Safe.image.enabled == true)
        {
            if (Input.GetKeyUp("return"))
            {
                if (Safe.text == "99BTGIA6")
                {
                    Desc.text = "I got it open! There's a gold ring inside... well it's mine now";
                    Safe.image.enabled = false;
                    Safe.text = "";

                    Safe.enabled = false;
                    safeenabled = false;
                    objid = -1;

                }
                else
                {
                    Safe.text = "";

                    Safe.enabled = false;
                    Desc.text = "hmmm, that wasnt the code";
                    Safe.image.enabled = false;
                    objid = -1;
                }
            }
        }
        /// /// ///

        if (Input.GetMouseButtonDown(1))
        {
            Safe.image.enabled = false; //get rid of the input field
            pos = Input.mousePosition;
            hitCollider = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(pos));

            if (hitCollider != null)
            {
                colliderPosition = hitCollider.transform.position;
                addtoInventory.transform.position = new Vector3(pos.x, (pos.y),pos.z);
                interactWithItem.transform.position = new Vector3(pos.x, (pos.y - 30), pos.z);
                lookAtItem.transform.position = new Vector3(pos.x, (pos.y - 60), pos.z);
                SetButtons(true);
                if(hitCollider.gameObject.name == "Ember")
                {
                    Debug.Log("Ember Selected");
                    selectedItem = GameObject.Find("Ember");
                    objid = 2; //get the ember's ID for adding to inventory
                }
                if (hitCollider.gameObject.name == "Candleplaced")
                {

                    selectedItem = GameObject.Find("Candleplaced");
                    objid = 7;
                }
                if (hitCollider.gameObject.name == "Corkboard")
                {

                    selectedItem = GameObject.Find("Corkboard");
                    objid = 8; 
                }
                if (hitCollider.gameObject.name == "Teleporterup")
                {
                    
                    selectedItem = GameObject.Find("TeleporterUp");
                    objid = 9; 
                    Debug.Log("9");
                }
                if (hitCollider.gameObject.name == "TeleporterDown")
                {
                    
                    selectedItem = GameObject.Find("TeleporterDown");
                    objid = 10; 
                }
                if (hitCollider.gameObject.name == "Staff")
                {

                    selectedItem = GameObject.Find("Staff");
                    objid = 11; 
                }
                if (hitCollider.gameObject.name == "painting")
                {

                    selectedItem = GameObject.Find("painting");
                    objid = 12; 
                }
                if (hitCollider.gameObject.name == "wallsafe")
                {

                    selectedItem = GameObject.Find("wallsafe");
                    objid = 13; 
                }
                if (hitCollider.gameObject.name == "Door")
                {

                    selectedItem = GameObject.Find("Door");
                    objid = 14; 
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
            Desc.text = "I'll just pocket this ember";
            
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
        else if (objid == 11)
        {
            Desc.text = "*zap* YEOUCH! there's some sort of spell on the staff! Wonder why the wizard is able to pick it up.";
            objid = -1;

        }

    }
    //for looking at objects
    void looktask()
    {
        if (objid == 2)
        {
            Desc.text = "It's a piece of ember from Mr. Fireplace";

        }
        if (objid == 7)
        {
            Desc.text = "I think these candles hold some sort of magic properties";
        }
        if (objid == 8)
        {
            Desc.text = "This corkboards have a bunch of sticky notes. They read: 4A6, 2BT, 199, 3GI";
        }
        if (objid == 9)
        {
            Desc.text = "This teleporter leads upstairs";
        }
        if (objid == 10)
        {
            Desc.text = "This teleporter leads to the basement";
        }
        if (objid == 11)
        {
            Desc.text = "It's the wizard's staff! I can appreciate a man with a good staff.";
        }
        if (objid == 12)
        {
            Desc.text = "A picture of the wziard's wife; he turned her into an orc, long story.";
        }
        if (objid == 13)
        {
            Desc.text = "He's a Master of the Mystic Arts and he uses a wallsafe. I guess nothing beats reinforced steel";
        }
        if (objid == 14)
        {
            Desc.text = "That comically large door is the only way out";
        }
    }
    //for interacting with objects
    void interacttask()
        {
        if (objid == 12)
        {
            Desc.text = "Oops";
            wallsafe.SetActive(true);
            Destroy(selectedItem);
            objid = -1;
        }
        if (objid == 13)
        {
            if (safeenabled == true)
            {
                Desc.text = "What's the code?";

                Safe.enabled = true;
                Safe.image.enabled = true;
                objid = -1;
            }
            if (safeenabled == false)
            {
                Desc.text = "I already stole his prized possesions";
                objid = -1;
            }
        }
        if (objid == 14)
        {
            Desc.text = "Oh sure, I can definitely open this door. That giant lock is just for show";
            objid = -1;
        }
        if (objid == 10)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        if (objid == 9)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
    //////////////////////////////////

    void SetButtons(bool itemClicked)
    {
        addtoInventory.SetActive(itemClicked);
        interactWithItem.SetActive(itemClicked);
        lookAtItem.SetActive(itemClicked);
    }



}
