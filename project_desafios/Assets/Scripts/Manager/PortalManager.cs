using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{

    private bool triggerChangeSize = false;
    private bool enteredAtResize = false;

    private void OnTriggerEnter(Collider other) 
    {
        if(triggerChangeSize) {
            enteredAtResize = true;
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        if(other.gameObject.name.Equals("Player")) 
        {
            PlayerManager playerManager = other.GetComponent<PlayerManager>();
            triggerChangeSize = playerManager.IsDecreasedSize()?true:false;
            if(enteredAtResize)
            {
                triggerChangeSize = false;
                enteredAtResize = false;
            }
            else {
                playerManager.ChangeSize();
            }
        }
    }
}
