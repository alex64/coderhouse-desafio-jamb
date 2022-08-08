using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private bool decreaseSize = false;

    public void ChangeSize()
    {
        if(decreaseSize) 
        {
            ScalePlayer(2f);
            decreaseSize = false;
        }
        else 
        {
            ScalePlayer(0.5f);
            decreaseSize = true;
        }
            
    }

    public bool IsDecreasedSize()
    {
        return decreaseSize;
    }

    private void ScalePlayer(float size)
    {
        transform.localScale = transform.localScale * size;
    }
}
