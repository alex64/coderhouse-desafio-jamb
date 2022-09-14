using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private Transform playerTransform;

    //Raycast
    [SerializeField] private Transform raycastPoint;

    [SerializeField]
    protected EnemyData enemyData;
    //private float rayDistance = 10f;

    public Transform PlayerTransform { get => playerTransform; set => playerTransform = value; }

    public static event Action onEnemyDestroyed;

    // Update is called once per frame
    private void FixedUpdate()
    {
        EnemyRaycast();
    }

    protected void LookPlayer()
    {
        Quaternion newRotation = Quaternion.LookRotation(PlayerTransform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 2f * Time.deltaTime);
    }

    private void EnemyRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(raycastPoint.position, raycastPoint.TransformDirection(Vector3.forward), out hit, enemyData.RayDistance))
        {
            if (hit.transform.CompareTag("Player"))
            {
                GameManager.HitCar = true;
                if(GameManager.HitCar) 
                {
                    //Debug.Log("Hit Car: " + GameManager.HitCar);
                    Debug.Log("onEnemyDestroyed-Called-Enemy");
                    onEnemyDestroyed?.Invoke();
                    GameManager.Score--;
                    //Delete object
                    Destroy(gameObject);
                }
            }
        }
        else {
            GameManager.HitCar = false;
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector3 direction = raycastPoint.TransformDirection(Vector3.forward) * enemyData.RayDistance;
        Gizmos.DrawRay(raycastPoint.position, direction);
    }
}
