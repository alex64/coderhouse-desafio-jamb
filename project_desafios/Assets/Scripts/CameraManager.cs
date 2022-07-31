using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public GameObject[] cameras;
    private Dictionary<KeyCode, GameObject> cameraList = new Dictionary<KeyCode, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        cameraList.Add(KeyCode.F1, cameras[0]);
        cameraList.Add(KeyCode.F2, cameras[1]);
    }

    // Update is called once per frame
    void Update() //Frame
    {
        foreach(KeyValuePair<KeyCode, GameObject> camera in cameraList) 
        {     
            if(Input.GetKeyDown(camera.Key)) 
            {
                camera.Value.SetActive(true);
                foreach(KeyValuePair<KeyCode, GameObject> disableCamera in cameraList)
                {
                    if(disableCamera.Value != camera.Value) 
                    {
                        disableCamera.Value.SetActive(false);
                    }
                }
            }
        }
    }
}
