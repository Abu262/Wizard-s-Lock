using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chess : MonoBehaviour
{
    [SerializeField] protected bool isPicked = false;
    [SerializeField] GameObject selectedObject = null;
    [SerializeField] public bool won = false;
    [SerializeField] GameObject winningPiece;
    private Vector3 winningPosition = new Vector3(-2.9f, 4.8f, 0);
    private Vector3 originalPosition = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && selectedObject == null)
            selectedObject = ClickSelect();

        else if (Input.GetMouseButtonDown(0) && selectedObject != null)
            DropObject();

        MoveObject();

    }

    GameObject ClickSelect()
    {
        //Converting Mouse Pos to 2D (vector2) World Pos
        Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);
        
        if (hit)
        {
            Debug.Log("Found Object:");
            Debug.Log(hit.transform.name);
            if (hit.transform.gameObject.CompareTag("Black"))
            {
                Debug.Log("Found Black Piece:");
                Debug.Log(hit.transform.name);
                originalPosition = hit.transform.gameObject.transform.position;
                return hit.transform.gameObject;
            }

            else
                return null;
        }
        else return null;
    }

    void MoveObject()
    {
        if (selectedObject != null && !selectedObject.CompareTag("ChessBoard") && !selectedObject.CompareTag("White"))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            selectedObject.transform.position = mousePos;
        }
    }

    void DropObject()
    {
        Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);

        if (hit)
        {
            selectedObject.transform.position = hit.transform.position;
            if (CheckWin())
            {
                Debug.Log("You Won");
                selectedObject.transform.position = winningPosition;
                selectedObject = null;
            }
            else
            {
                Debug.Log("nope");
                selectedObject.transform.position = originalPosition;
                selectedObject = null;
            }

            

        }

        
    }

    bool CheckWin()
    {
        if (winningPiece.transform.position.x >= winningPosition.x - .6
            && winningPiece.transform.position.x <= winningPosition.x + .6
            && winningPiece.transform.position.y >= winningPosition.y - .6
            && winningPiece.transform.position.y <= winningPosition.y + .6)
        {
            return true;
        }
        return false;
    }
}
