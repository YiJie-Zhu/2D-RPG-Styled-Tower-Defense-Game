using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    public Texture2D cursorPic;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.SetCursor(cursorPic, UnityEngine.Vector2.zero, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
