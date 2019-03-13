using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chess : MonoBehaviour
{
    [SerializeField] GameObject selectedObject = null;
    [SerializeField] public bool won = false;
    [SerializeField] GameObject winningPiece = null;
    [SerializeField] GameObject chessBoard = null;
    private Vector3 winningPosition = new Vector3(-2.9f, 4.8f, 0);
    private Vector3 originalPosition = new Vector3(0, 0, 0);
    public Inventory invscript = null;

    void Awake()
    {
        invscript = GameObject.Find("Inventory").GetComponent<Inventory>();
    }

    // Start is called before the first frame update
    void Start()
    {
        chessBoard = GameObject.FindWithTag("ChessBoard");
        chessBoard.GetComponent<BoxCollider2D>().enabled = false;
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
            if (hit.transform.gameObject.CompareTag("Black"))
            {
                originalPosition = hit.transform.gameObject.transform.position;
                chessBoard.GetComponent<BoxCollider2D>().enabled = true;
                return hit.transform.gameObject;
            }

            else
                return null;
        }
        else return null;
    }

    void MoveObject()
    {
        if (selectedObject != null && selectedObject.CompareTag("Black"))
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
                
                selectedObject.transform.position = winningPosition;
                selectedObject = null;
                invscript.AddItem(6);
                SceneManager.LoadScene(3);
            }
            else
            {
                selectedObject.transform.position = originalPosition;
                chessBoard.GetComponent<BoxCollider2D>().enabled = false;
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
