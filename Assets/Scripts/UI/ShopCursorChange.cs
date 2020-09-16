using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopCursorChange : MonoBehaviour
{

    public Texture2D normalCursor;
    public Texture2D buyCursor;
    public Texture2D noCursor;


    public int price;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MouseEnter()
    {
        if(CoinManager.coin < price)
        {
            Cursor.SetCursor(noCursor, UnityEngine.Vector2.zero, CursorMode.ForceSoftware);
        }
        else
        {
            Cursor.SetCursor(buyCursor, UnityEngine.Vector2.zero, CursorMode.ForceSoftware);
        }
        Debug.Log("Entered");
    }

    public void MouseExit()
    {
            Cursor.SetCursor(normalCursor, UnityEngine.Vector2.zero, CursorMode.ForceSoftware); 
    }

    public void MouseClick()
    {
        if (CoinManager.coin < price)
        { 
            Cursor.SetCursor(noCursor, UnityEngine.Vector2.zero, CursorMode.ForceSoftware);
        }
    }
}
