using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private bool moving;
    private Vector3 movedTo;
    public float speed;
    //public GameObject chara;
    

    // Start is called before the first frame update
    void Start()
    {
        //rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //get the player moving left right, up or down
        if (Input.GetMouseButtonDown(0)) {
            movedTo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            movedTo.z = transform.position.z;
            if( !moving ){
                moving = true;
            }
            //Instantiate( chara, movedTo, Quaternion.identity );
        }

        if ( moving ){
            transform.position = Vector3.MoveTowards(transform.position, movedTo, speed * Time.deltaTime);
        }
        //float horizontal = Input.GetButtonDown("Mouse X");
        //float vertical = Input.GetAxis("Vertical");

        //storing movement in a 2d vector
        //Vector2 moving = new Vector2(horizontal, vertical);

        //give the rigidbody movement * how fast we want them to move
        //rigidBody.AddForce(moving * speed);
    }
}
