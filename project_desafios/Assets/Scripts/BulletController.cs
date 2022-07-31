using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public float speed = 2f;
    public Vector3 direction = new Vector3(0f, 0f, 1f);
    public float damage = 1f;
    public float liveTime = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyDelay", liveTime);
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Resize();
        }
    }

    private void Move() 
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void Resize() 
    {
        transform.localScale = transform.localScale * 2;
    }

    private void DestroyDelay()
    {
        Destroy(gameObject);
    }
}
