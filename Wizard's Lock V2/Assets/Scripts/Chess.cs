using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chess : MonoBehaviour
{
    [SerializeField] protected bool isPicked = false;
    [SerializeField] GameObject selectedObject = null;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && selectedObject == null)
            selectedObject = ClickSelect();

        if (Input.GetMouseButtonDown(0) && selectedObject != null)
            DropObject();

        MoveObject();

        CheckBoard();

    }

    GameObject ClickSelect()
    {
        //Converting Mouse Pos to 2D (vector2) World Pos
        Vector2 rayPos = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        RaycastHit2D hit = Physics2D.Raycast(rayPos, Vector2.zero, 0f);

        if (hit)
        {
            Debug.Log(hit.transform.name);
            return hit.transform.gameObject;
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
            selectedObject = null;
        }

        
    }

    void CheckBoard()
    {
        
    }
}
