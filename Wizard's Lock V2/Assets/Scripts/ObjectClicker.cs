using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ObjectClicker : MonoBehaviour
{
    
    public GameObject addtoInventory, interactWithItem, lookAtItem;
    public Button adder, interacter, looker = null;
    public static GameObject selectedItem = null;
    public Vector3 pos;
    public Collider2D hitCollider;
    public Vector3 colliderPosition;
    public Text Desc = null;
    public InputField Safe = null;
    public bool drawerInteracted = false;
    public bool staffInteracted = false;
    public bool alchemyInteracted = false;
    // my stuff
    ////////
    private Text kelvintext;
    public Inventory invscript;    // you didnt have your inventory script called
    int objid = -1;   // you had everything in the database set as id numbers so i rolled with that
    bool safeenabled = true;
    public GameObject wallsafe = null;
    ////////


    void Awake()
    {

    }

    void Start()
    {
        if (Safe)
        {
            Safe = Safe.GetComponent<InputField>();
            Safe.enabled = false;
        }
        // get the buttons
        //Button addbtn = adder.GetComponent<Button>(); //add
        //Button lookbtn = looker.GetComponent<Button>(); //look
        //Button interactbtn = interacter.GetComponent<Button>(); //interact
        Button addbtn = GameObject.Find("Add to Inventory").GetComponent<Button>();
        Button interactbtn = GameObject.Find("Interact").GetComponent<Button>();
        Button lookbtn = GameObject.Find("Look At").GetComponent<Button>();
        // give the buttons a function when they are clicked, functions at the bottom
        addbtn.onClick.AddListener(addtask);   // activating the add button
        lookbtn.onClick.AddListener(looktask);  // activating the look button
        interactbtn.onClick.AddListener(interacttask); //activating the interact button
        SetButtons(false);

        Desc = GameObject.Find("descText").GetComponent<Text>();
        invscript = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        //some safe bullshit
        if (GameObject.Find("wallsafe") != null)
        {
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
                        invscript.AddItem(5);
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
        }
        /// /// ///

        if (Input.GetMouseButtonDown(1))
        {
            if (Safe != null)
            {
                Safe.image.enabled = false; //get rid of the input field
            }
            pos = Input.mousePosition;
            hitCollider = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(pos));

            if (hitCollider != null )
            {
                if (kelvintext != null)
                {
                    kelvintext.text = "";
                }
                colliderPosition = hitCollider.transform.position;
                addtoInventory.transform.position = new Vector3(pos.x, (pos.y),pos.z);
                interactWithItem.transform.position = new Vector3((pos.x ) -50, (pos.y), pos.z);
                lookAtItem.transform.position = new Vector3((pos.x)+ 50, pos.y, pos.z);
                SetButtons(true);
                if (hitCollider.gameObject.name == "Basement" || hitCollider.gameObject.name == "LivingRoom" || hitCollider.gameObject.name == "Bedroom")
                {
                    //addtoInventory.transform.position = new Vector3(pos.x, (pos.y), pos.z);
                    //interactWithItem.transform.position = new Vector3(pos.x, (pos.y - 30), pos.z);
                    //lookAtItem.transform.position = new Vector3(pos.x, (pos.y - 60), pos.z);
                    SetButtons(false);
                }
                if(hitCollider.gameObject.name == "Ember")
                {
                    Debug.Log("Ember Selected");
                    selectedItem = GameObject.Find("Ember");
                    objid = 2; //get the ember's ID for adding to inventory
                }
                if (hitCollider.gameObject.name == "Diary")
                {

                    selectedItem = GameObject.Find("Diary");
                    objid = 1;
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
                if (hitCollider.gameObject.name == "TeleporterUp")
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

                if (hitCollider.gameObject.name == "Pedestal")
                {

                    selectedItem = GameObject.Find("Pedestal");
                    objid = 15;
                }

                if (hitCollider.gameObject.name == "Chess")
                {

                    selectedItem = GameObject.Find("Chess");
                    objid = 16;
                }

                if (hitCollider.gameObject.name == "UpstairsTeleporter")
                {

                    selectedItem = GameObject.Find("UpstairsTeleporter");
                    objid = 17;
                }

                if (hitCollider.gameObject.name == "Bed")
                {

                    selectedItem = GameObject.Find("Bed");
                    objid = 18;
                }

                if (hitCollider.gameObject.name == "Drawer")
                {

                    selectedItem = GameObject.Find("Drawer");
                    objid = 19;
                }
                if (hitCollider.gameObject.name == "Alchemy")
                {

                    selectedItem = GameObject.Find("Alchemy");
                    objid = 20;
                }

                if (hitCollider.gameObject.name == "DownstairsTeleporter")
                {

                    selectedItem = GameObject.Find("DownstairsTeleporter");
                    objid = 21;
                }

                if (hitCollider.gameObject.name == "Fireplace")
                {

                    selectedItem = GameObject.Find("Fireplace");
                    objid = 22;
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
        /*if (Input.GetMouseButtonDown(0))
        {
            if (hitCollider.gameObject.name == "Fireplace" )
            {
                selectedItem = GameObject.Find("Fireplace");
                objid = 22;
            }
        }*/

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
            Desc.text = "This diary could be useful";
            Destroy(selectedItem);  //destroys the diary
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
        if (objid == 22)
        {
            kelvintext = GameObject.Find("KelvinText").GetComponent<Text>();
            kelvintext.text = "\n\n\n\n\n\n\n        AY! Hand's off kid!";
            objid = -1;
        }

    }
    //for looking at objects
    public void looktask()
    {
        if (objid == 2)
        {
            Desc.text = "It's a piece of ember from Kelvin";

        }
        if (objid == 1)
        {
            Desc.text = "the wizard's diary, or 'journal' as he calls it.";
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
            Desc.text = "A picture of the wizard's wife; he turned her into an orc, long story.";
        }
        if (objid == 13)
        {
            Desc.text = "He's a Master of the Mystic Arts and he uses a wallsafe. I guess nothing beats reinforced steel";
        }
        if (objid == 14)
        {
            Desc.text = "That comically large door is the only way out";
        }
        //pedestal
        if (objid == 15)
        {
            Desc.text = "'Thor's Toothpick'... I think the wizard won this in a chess match";
        }
        //chess
        if (objid == 16)
        {
            Desc.text = "A recreation of the 1998's chess match: Thorin (black) vs. Ittai (white), right before Thorin checkmated Ittai.";
        }
        //upstairstele
        if (objid == 17)
        {
            Desc.text = "This leads to the living room.";
        }
        //bed
        if (objid == 18)
        {
            Desc.text = "A cozy bed for a not-so-cozy wizard.";
        }
        //drawer
        if (objid == 19)
        {
            Desc.text = "That's where the wizard keeps his clothes.";
        }
        //alchemy
        if (objid == 20)
        {
            Desc.text = "The wizard's alchemy table, what he brews up here would shock you.";
        }
        //downstairstele
        if (objid == 21)
        { 
            Desc.text = "This leads to the living room.";
        }
        //fireplace
        if (objid == 22)
        {
            Desc.text = "That's Kelvin, the Wizard's fireplace. He can talk.";
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
                Desc.text = "I already stole everything inside.";
                objid = -1;
            }
        }
        if (objid == 14)
        {
            if(invscript.InventoryContains(2) && invscript.InventoryContains(4) && invscript.InventoryContains(5) && invscript.InventoryContains(6))
            {
                SceneManager.LoadScene("Win Screen");
            }
            else
                Desc.text = "Oh sure, I can definitely open this door. That giant lock is just for show";
            objid = -1;
        }
        if (objid == 10)
        {
            //Downstairs teleporter
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
            objid = -1;
        }
        if (objid == 9)
        {
            //Upstairs teleporter
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            objid = -1;
        }
       if (objid == 22)
        {
            kelvintext = GameObject.Find("KelvinText").GetComponent<Text>();
            if(invscript.InventoryContains(7))
            {
                invscript.useStaff();
                kelvintext.text = "Thanks, this'll teach him to lock me up. Here, take this ember, \nit should help your escape.";
                invscript.AddItem(2);
            }
            else
                kelvintext.text = "Oh, it’s the wizard’s new test subject. You probably wanna escape, huh? \n\nListen, that wizard refused me my raise AND moved me to the basement. For all I care, he can eat a bag of dicks. \n\nSo tell you what. Get me his staff so I can burn it, and I’ll help you out.";
            objid = -1;
        }
       if (objid == 19)
       {
            Desc.text = "Lots of robes in here, but these gloves look nice.";
            if (!drawerInteracted)
            {
                //invscript.AddItem(0);
                invscript.AddItem(3);
                drawerInteracted = true;
            }
            objid = -1;
        }
       if (objid == 16)
        {
            Desc.text = "";
            SceneManager.LoadScene(4);
            objid = -1;
        }
        if (objid == 20)
        {
            if (alchemyInteracted == false)
            {
                Desc.text = "I think combining three yellow potions make a lightning potion.";
                alchemyInteracted = true;
                SceneManager.LoadScene(5);
            }
            objid = -1;
        }
        if (objid == 11)
        {
            if (invscript.InventoryContains(3))
            {
                Desc.text = "Only the wizard could grab the staff. Luckily his glove could fool the spell.";
                Destroy(selectedItem);
                invscript.AddItem(7);
            }
            objid = -1;
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
