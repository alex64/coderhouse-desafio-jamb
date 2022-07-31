using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public GameObject bullet;

    public float delayShoot = 1f;

    public float repeatShoot = 2f;

    // Start is called before the first frame update
    void Start()
    {
        Shoot();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Shoot() {
        InvokeRepeating("CreateBullet", delayShoot, repeatShoot);
    }

    private void CreateBullet() {
        Instantiate(bullet, transform.position, transform.rotation);        
    }
}
