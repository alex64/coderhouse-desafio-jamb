using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //public float scale = 2f;
    public float velocity = 2f;

    public float life = 3f;

    public float damageInfliceted = 0.5f;

    public float healing = 1f;

    public Vector3 direction = Vector3.forward;
    
    // Start is called before the first frame update
    void Start()
    {
        //transform.localScale *= scale;
    }

    // Update is called once per frame
    void Update()
    {
        Damage(damageInfliceted);
        Recovery(healing);
        Movement(direction);
        Debug.Log("Life: " + life);
    }

    private void Movement(Vector3 direction)
    {
        transform.position += direction * velocity * Time.deltaTime;
    }

    private void Damage(float damageInfliceted)
    {
        life -= damageInfliceted;
        Debug.Log("Damage Inflicted: " + damageInfliceted);
    }

    private void Recovery(float healing)
    {
        life += healing;
        Debug.Log("Healing " + healing);
    }
}
