using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 2f;

    public Vector3 direction = new Vector3(0f, 0f, 1f);

    //public Vector3 position = new Vector3();

    public float damage = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move() 
    {
        transform.position += direction * speed * Time.deltaTime;
    }
}
