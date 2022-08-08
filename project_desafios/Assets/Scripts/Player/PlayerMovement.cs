using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float velocity = 2f;

    // [SerializeField]
    // private float life = 3f;

    // [SerializeField]
    // private float damageInfliceted = 0.5f;

    // [SerializeField]
    // private float healing = 1f;

    [SerializeField]
    private Vector3 direction = Vector3.forward;

    [SerializeField]
    private float speed = 2f;

    [SerializeField]
    private float cameraAxisX = 0f;

    private Dictionary<KeyCode, Vector3> movementList = new Dictionary<KeyCode, Vector3>();
    
    // Start is called before the first frame update
    void Start()
    {
        movementList.Add(KeyCode.W, Vector3.forward);
        movementList.Add(KeyCode.S, Vector3.back);
        //movementList.Add(KeyCode.A, Vector3.left);
        //movementList.Add(KeyCode.D, Vector3.right);
    }

    // Update is called once per frame
    void Update()
    {
        //Damage(damageInfliceted);
        //Recovery(healing);
        //Movement(direction);
        RotatePlayer();
        foreach(KeyValuePair<KeyCode, Vector3> movement in movementList) 
        {
            if(Input.GetKey(movement.Key)) 
            {
                Movement(movement.Value);
            }
        }
    }

    private void Movement(Vector3 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    public void RotatePlayer()
    {
        cameraAxisX += Input.GetAxis("Mouse X");
        Quaternion newRotation = Quaternion.Euler(0, cameraAxisX, 0);
        transform.rotation= Quaternion.Lerp(transform.rotation, newRotation, 2f * Time.deltaTime);
    }

    // private void Damage(float damageInfliceted)
    // {
    //     life -= damageInfliceted;
    // }

    // private void Recovery(float healing)
    // {
    //     life += healing;
    // }
}
