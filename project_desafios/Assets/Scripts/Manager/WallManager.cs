using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WallManager : MonoBehaviour
{
    /*[SerializeField]
    private float triggerTeleportTime = 2f;
    [SerializeField]
    private Transform nextPortal;
    private float timeInPortal = 0;

    private void OnCollisionEnter(Collision other) {
        timeInPortal = 0f;
    }

    private  void OnCollisionStay(Collision other) 
    {
        timeInPortal += Time.deltaTime;
        if(timeInPortal >= triggerTeleportTime)
        {
            other.transform.position = new Vector3(Random.Range(-4f, 4f), other.transform.position.y, Random.Range(-4f, 4f));
        }
    }*/

    [SerializeField] private UnityEvent OnTriggerOutOfBounds;

    private void OnTriggerEnter(Collider other) {
        Debug.Log("----TEST");
        if(other.CompareTag("Player"))
        {
            Debug.Log("OnTriggerOutOfBounds-Called-WallManager");
            OnTriggerOutOfBounds?.Invoke();
        }
    }
}
