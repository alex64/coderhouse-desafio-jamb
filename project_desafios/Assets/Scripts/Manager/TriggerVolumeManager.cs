using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TriggerVolumeManager : MonoBehaviour
{
    private PostProcessVolume globalVolume;
    //[SerializeField]
    private bool isTriggered;
    // Start is called before the first frame update
    void Start()
    {
        globalVolume = GetComponent<PostProcessVolume>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        LensDistortion lensDist;
        if(other.CompareTag("Player")) {
            if(globalVolume.profile.TryGetSettings(out lensDist)) {
                lensDist.active = true;
            }
        }
    }

    private void OnTriggerExit(Collider other) {
        LensDistortion lensDist;
        if(other.CompareTag("Player")) {
            if(globalVolume.profile.TryGetSettings(out lensDist)) {
                lensDist.active = false;
            }
        }

    }
}
