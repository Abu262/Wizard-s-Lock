using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private bool moving = false;
    private Vector3 movedTo;
    public float speed;
    private GameObject hitten;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0)){
            Debug.Log("has hit");
            CheckClick();
            Debug.Log(movedTo);
            moving = true;
            
        }

        if (moving){
            MoveChara();
        }

        if ( movedTo == this.transform.position){
            moving = false;
        }
    }

    void MoveChara()
    {
        //if they are moving, transform into where they wanted to move
        if (hitten){
            if (hitten.tag == "Background"){
                
                this.transform.position = Vector3.MoveTowards(this.transform.position, movedTo, speed * Time.deltaTime);
            }
        }
    }

    void CheckClick()
    {
        //if the mouse button is pressed, find out where they want to move and set moving to true
        movedTo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        movedTo.z = transform.position.z;
        hitten = OutOfBound();
         Debug.Log(hitten.name);
    }

    GameObject OutOfBound()
    {
        Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);

        if (hit){
            return hit.transform.gameObject;
        }
        else return null;
    }
}
