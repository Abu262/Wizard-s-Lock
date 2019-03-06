using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeColor : Inventory
{
    public GameObject Left, Middle, Right;
    Color[] colors = { Color.red, Color.blue, Color.yellow, Color.green, Color.cyan, Color.magenta, Color.grey };
    // Start is called before the first frame update
    void Start()
    {
        Left = GameObject.Find("Left");
        Middle = GameObject.Find("Middle");
        Right = GameObject.Find("Right");

        Left.GetComponent<Renderer>().material.color = Color.red;
        Middle.GetComponent<Renderer>().material.color = Color.blue;
        Right.GetComponent<Renderer>().material.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
        if (Left.GetComponent<Renderer>().material.color == Color.yellow && Middle.GetComponent<Renderer>().material.color == Color.yellow && Right.GetComponent<Renderer>().material.color == Color.yellow)
        {
            AddItem(4);
            Debug.Log("Potion Complete!");
            SceneManager.LoadScene(1);
        }
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                /*IF LEFT CLICKED*/
                if (hit.collider.gameObject == Left)
                {
                    int leftColorIndex = 0;
                    int middleColorIndex = 0;
                    int rightColorindex = 0;
                    for (int i = 0; i < colors.Length; i++)
                    {
                        if (Left.GetComponent<Renderer>().material.color == colors[i])
                            leftColorIndex = i;
                        if (Middle.GetComponent<Renderer>().material.color == colors[i])
                            middleColorIndex = i;
                        if (Right.GetComponent<Renderer>().material.color == colors[i])
                            rightColorindex = i;
                    }

                    switch (leftColorIndex)
                    {
                        case 0: //red
                            Left.GetComponent<Renderer>().material.color = Color.blue;
                            Debug.Log("Turn Blue");
                            break;
                        case 1: //blue
                            Left.GetComponent<Renderer>().material.color = Color.yellow;
                            Debug.Log("Turn yellow");
                            break;
                        case 2: //yellow
                            Left.GetComponent<Renderer>().material.color = Color.green;
                            Debug.Log("Turn Green");
                            break;
                        case 3: //green
                            Left.GetComponent<Renderer>().material.color = Color.cyan;
                            Debug.Log("Turn Purple");
                            break;
                        case 4: //cyan
                            Left.GetComponent<Renderer>().material.color = Color.magenta;
                            Debug.Log("Turn Orange");
                            break;
                        case 5: //magenta
                            Left.GetComponent<Renderer>().material.color = Color.grey;
                            Debug.Log("Turn Pink");
                            break;
                        case 6: //grey
                            Left.GetComponent<Renderer>().material.color = Color.red;
                            Debug.Log("Turn Red");
                            break;
                    }

                    /*switch (middleColorIndex)
                    {
                        case 0: //red
                            Middle.GetComponent<Renderer>().material.color = Color.blue;
                            Debug.Log("Turn Blue");
                            break;
                        case 1: //blue
                            Middle.GetComponent<Renderer>().material.color = Color.yellow;
                            Debug.Log("Turn yellow");
                            break;
                        case 2: //yellow
                            Middle.GetComponent<Renderer>().material.color = Color.red;
                            Debug.Log("Turn Red");
                            break;
                    }*/
                }

                /*IF RIGHT CLICKED*/
                if (hit.collider.gameObject == Right)
                {
                    int leftColorIndex = 0;
                    int rightColorIndex = 0;
                    int middleColorIndex = 0;
                    for (int i = 0; i < colors.Length; i++)
                    {
                        if (Right.GetComponent<Renderer>().material.color == colors[i])
                            rightColorIndex = i;
                        if (Middle.GetComponent<Renderer>().material.color == colors[i])
                            middleColorIndex = i;
                        if (Left.GetComponent<Renderer>().material.color == colors[i])
                            leftColorIndex = i;
                    }

                    switch (rightColorIndex)
                    {
                        case 0: //red
                            Right.GetComponent<Renderer>().material.color = Color.blue;
                            Debug.Log("Turn Blue");
                            break;
                        case 1: //blue
                            Right.GetComponent<Renderer>().material.color = Color.yellow;
                            Debug.Log("Turn yellow");
                            break;
                        case 2: //yellow
                            Right.GetComponent<Renderer>().material.color = Color.green;
                            Debug.Log("Turn Green");
                            break;
                        case 3: //green
                            Right.GetComponent<Renderer>().material.color = Color.cyan;
                            Debug.Log("Turn Purple");
                            break;
                        case 4: //cyan
                            Right.GetComponent<Renderer>().material.color = Color.magenta;
                            Debug.Log("Turn Orange");
                            break;
                        case 5: //magenta
                            Right.GetComponent<Renderer>().material.color = Color.grey;
                            Debug.Log("Turn Pink");
                            break;
                        case 6: //grey
                            Right.GetComponent<Renderer>().material.color = Color.red;
                            Debug.Log("Turn Red");
                            break;
                    }

                    switch (middleColorIndex)
                    {
                        case 0: //red
                            Middle.GetComponent<Renderer>().material.color = Color.blue;
                            Debug.Log("Turn Blue");
                            break;
                        case 1: //blue
                            Middle.GetComponent<Renderer>().material.color = Color.yellow;
                            Debug.Log("Turn yellow");
                            break;
                        case 2: //yellow
                            Middle.GetComponent<Renderer>().material.color = Color.green;
                            Debug.Log("Turn Green");
                            break;
                        case 3: //green
                            Middle.GetComponent<Renderer>().material.color = Color.cyan;
                            Debug.Log("Turn Purple");
                            break;
                        case 4: //purple
                            Middle.GetComponent<Renderer>().material.color = Color.magenta;
                            Debug.Log("Turn Orange");
                            break;
                        case 5: //orange
                            Middle.GetComponent<Renderer>().material.color = Color.grey;
                            Debug.Log("Turn Pink");
                            break;
                        case 6: //pink
                            Middle.GetComponent<Renderer>().material.color = Color.red;
                            Debug.Log("Turn Red");
                            break;
                    }

                    /*switch (leftColorIndex)
                    {
                        case 0: //red
                            Left.GetComponent<Renderer>().material.color = Color.blue;
                            Debug.Log("Turn Blue");
                            break;
                        case 1: //blue
                            Left.GetComponent<Renderer>().material.color = Color.yellow;
                            Debug.Log("Turn yellow");
                            break;
                        case 2: //yellow
                            Left.GetComponent<Renderer>().material.color = Color.green;
                            Debug.Log("Turn Red");
                            break;
                        case 3: //green
                            Left.GetComponent<Renderer>().material.color = Color.red;
                            Debug.Log("Turn Green");
                            break;

                    }*/
                }

                if (hit.collider.gameObject == Middle)
                {
                    int middleColorIndex = 0;
                    int leftColorIndex = 0;
                    int rightColorIndex = 0;
                    for (int i = 0; i < colors.Length; i++)
                    {
                        if (Right.GetComponent<Renderer>().material.color == colors[i])
                            rightColorIndex = i;
                        if (Left.GetComponent<Renderer>().material.color == colors[i])
                            leftColorIndex = i;
                        if (Middle.GetComponent<Renderer>().material.color == colors[i])
                            middleColorIndex = i;
                    }

                    switch (middleColorIndex)
                    {
                        case 0: //red
                            Middle.GetComponent<Renderer>().material.color = Color.blue;
                            Debug.Log("Turn Blue");
                            break;
                        case 1: //blue
                            Middle.GetComponent<Renderer>().material.color = Color.yellow;
                            Debug.Log("Turn yellow");
                            break;
                        case 2: //yellow
                            Middle.GetComponent<Renderer>().material.color = Color.green;
                            Debug.Log("Turn Green");
                            break;
                        case 3: //green
                            Middle.GetComponent<Renderer>().material.color = Color.cyan;
                            Debug.Log("Turn Purple");
                            break;
                        case 4: //purple
                            Middle.GetComponent<Renderer>().material.color = Color.magenta;
                            Debug.Log("Turn Orange");
                            break;
                        case 5: //orange
                            Middle.GetComponent<Renderer>().material.color = Color.grey;
                            Debug.Log("Turn Pink");
                            break;
                        case 6: //pink
                            Middle.GetComponent<Renderer>().material.color = Color.red;
                            Debug.Log("Turn Red");
                            break;

                    }

                    /*switch (rightColorIndex)
                    {
                        case 0: //red
                            Right.GetComponent<Renderer>().material.color = Color.blue;
                            Debug.Log("Turn Blue");
                            break;
                        case 1: //blue
                            Right.GetComponent<Renderer>().material.color = Color.yellow;
                            Debug.Log("Turn yellow");
                            break;
                        case 2: //yellow
                            Right.GetComponent<Renderer>().material.color = Color.red;
                            Debug.Log("Turn Red");
                            break;

                    }*/

                    switch (leftColorIndex)
                    {
                        case 0: //red
                            Left.GetComponent<Renderer>().material.color = Color.blue;
                            Debug.Log("Turn Blue");
                            break;
                        case 1: //blue
                            Left.GetComponent<Renderer>().material.color = Color.yellow;
                            Debug.Log("Turn yellow");
                            break;
                        case 2: //yellow
                            Left.GetComponent<Renderer>().material.color = Color.green;
                            Debug.Log("Turn Green");
                            break;
                        case 3: //green
                            Left.GetComponent<Renderer>().material.color = Color.cyan;
                            Debug.Log("Turn Purple");
                            break;
                        case 4: //purple
                            Left.GetComponent<Renderer>().material.color = Color.magenta;
                            Debug.Log("Turn Orange");
                            break;
                        case 5: //orange
                            Left.GetComponent<Renderer>().material.color = Color.grey;
                            Debug.Log("Turn Pink");
                            break;
                        case 6: //pink
                            Left.GetComponent<Renderer>().material.color = Color.red;
                            Debug.Log("Turn Red");
                            break;

                    }
                }
            }
         }

        }
    }
