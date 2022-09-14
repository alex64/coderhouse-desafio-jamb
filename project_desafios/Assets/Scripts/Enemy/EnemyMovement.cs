using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyMovement : MonoBehaviour
{
    private enum EnemyType {Peeper, Stalker}

    [SerializeField]
    [Range(1f, 10f)]  
    private float speed = 0.5f;

    [SerializeField]
    private EnemyType enemyType = EnemyType.Peeper;

    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private float enemySeparation = 2f;

    //Raycast
    [SerializeField] private Transform raycastPoint;

    [SerializeField]
    private float rayDistance = 10f;

    public Transform PlayerTransform { get => playerTransform; set => playerTransform = value; }
    public float Velocity { get => velocity; set => velocity = value; }

    private float velocity = 0.5f;

    public static event Action onEnemyDestroyed;

    //Raycast



    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch(enemyType)
        {
            case EnemyType.Peeper:
                LookPlayer();
                break;
            case EnemyType.Stalker:
                ChasePlayer();
                break;
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        EnemyRaycast();
    }

    private void ChasePlayer()
    {
        if(!GameManager.HitCar) 
        {
            LookPlayer();
            Vector3 chaseDirection = PlayerTransform.position - transform.position;
            if(chaseDirection.magnitude > enemySeparation)
            { 
                transform.position += chaseDirection.normalized * Velocity * Time.deltaTime; 
            }
        }
        
    }

    private void LookPlayer()
    {
        Quaternion newRotation = Quaternion.LookRotation(PlayerTransform.position - transform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 2f * Time.deltaTime);
    }

    private void EnemyRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(raycastPoint.position, raycastPoint.TransformDirection(Vector3.forward), out hit, rayDistance))
        {
            if (hit.transform.CompareTag("Player"))
            {
                GameManager.HitCar = true;
                if(GameManager.HitCar) 
                {
                    //Debug.Log("Hit Car: " + GameManager.HitCar);
                    Debug.Log("onEnemyDestroyed-Called-EnemyMovement");
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
        Vector3 direction = raycastPoint.TransformDirection(Vector3.forward) * rayDistance;
        Gizmos.DrawRay(raycastPoint.position, direction);
    }
}
