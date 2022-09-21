using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject[] cameras;
    private int activeCamera = 0;
    private bool mainCameraActive = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F1)) 
        {
            activeCamera = activeCamera<(cameras.Length - 1)?activeCamera + 1:0;
            for(int i=0; i < cameras.Length; i++) 
            {
                if(activeCamera == i)
                {
                    cameras[i].SetActive(true);
                }
                else
                {
                    cameras[i].SetActive(false);
                }
            }
        }
    }

    /*public void ChangeTopCamera() 
    {
        Debug.Log("OnBulletFocus-Received-CameraManager");
        mainCameraActive = false;
        cameras[0].SetActive(mainCameraActive);cameras[1].SetActive(!mainCameraActive);
    }

    public void ChangeMainCamera() 
    {
        Debug.Log("OnBulletUnfocus-Received-CameraManager");
        mainCameraActive = true;
        cameras[0].SetActive(mainCameraActive);cameras[1].SetActive(!mainCameraActive);
        
    }*/
}
