using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BulletManager : MonoBehaviour
{
    [SerializeField] private UnityEvent OnTriggerSpeedUp;

    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            Debug.Log("OnTriggerSpeedUp-Called-WallManager");
            OnTriggerSpeedUp?.Invoke();
            Destroy(gameObject);
        }
    }
}
