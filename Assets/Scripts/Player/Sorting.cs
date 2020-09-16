using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorting : MonoBehaviour
{
    public Renderer myRenderer;

    // Update is called once per frame
    void LateUpdate()
    {
        myRenderer.sortingOrder = (int)(-transform.position.y); 
    }
}
