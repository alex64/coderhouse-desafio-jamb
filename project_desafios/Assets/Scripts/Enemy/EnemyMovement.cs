using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private enum EnemyType {Peeper, Stalker}

    [SerializeField]
    [Range(1f, 10f)]  
    private float speed = 2f;

    [SerializeField]
    private EnemyType enemyType = EnemyType.Peeper;

    [SerializeField]
    private Transform playerTransform;

    [SerializeField]
    private float enemySeparation = 2f;

    private float playerXAxis = 0f;
    private float playerZAxis = 0f;

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

    private void ChasePlayer()
    {
        LookPlayer();
        Vector3 chaseDirection = playerTransform.position - transform.position;
        if(chaseDirection.magnitude > enemySeparation)
        { 
            transform.position += chaseDirection.normalized * speed * Time.deltaTime; 
        }
    }

    private void LookPlayer()
    {
        Quaternion newRotation = Quaternion.LookRotation(transform.position - playerTransform.position);
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, 2f * Time.deltaTime);
    }
}
