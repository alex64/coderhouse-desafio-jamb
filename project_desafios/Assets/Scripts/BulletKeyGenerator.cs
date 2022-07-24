using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletKeyGenerator : MonoBehaviour
{
    public GameObject munition;

    public bool canShoot = true;

    public float munitionDelay = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            Shoot(1);
        }
        if(Input.GetKeyDown(KeyCode.J)) {
            Shoot(2);
        }
        if(Input.GetKeyDown(KeyCode.K)) {
            Shoot(3);
        }
        if(Input.GetKeyDown(KeyCode.L)) {
            Shoot(4);
        }
    }

    private void Shoot(int munitionQuantity) 
    {
        float resetDelay = munitionQuantity * munitionDelay + 1f;
        if(canShoot) {
            Debug.Log("Queue munition shoot: " + resetDelay);
            canShoot = false;
            for(int index = 0; index < munitionQuantity; index++) 
            {
                Invoke("CreateMunition", munitionDelay * index);
            }
            
            Invoke("ResetShoot", resetDelay);
        }
    }

    private void CreateMunition() 
    {
        Debug.Log("Munition");
        Instantiate(munition, transform);
    }

    private void ResetShoot() 
    {
        Debug.Log("Reset shoot");
        canShoot = true;
    }
}
