using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cursorTexture : MonoBehaviour
{
    

    private int cursorSizeX = 32;
    private int cursorSizeY = 32;

    public Texture2D ARROW;
    public Texture2D ARROWALL;
    public CursorMode cursorMode = CursorMode.Auto;
     Vector2 hotSpot = Vector2.zero;

    void Start()
    {

        
        
    }

     void Update()
    {
        Cursor.SetCursor(ARROW, hotSpot, cursorMode);
        if (Input.GetKey(KeyCode.Mouse3))
        {
            Cursor.SetCursor(ARROWALL, hotSpot, cursorMode);
        }

            
            

        
            
    }

}