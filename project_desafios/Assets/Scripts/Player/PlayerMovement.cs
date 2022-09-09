using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField]
    private Vector3 direction = Vector3.forward;

    [SerializeField]
    private float cameraAxisX = 0f;

    private Dictionary<KeyCode, Vector3> movementList = new Dictionary<KeyCode, Vector3>();

    //Raycast
    [SerializeField] private Transform raycastPoint;
    //Raycast

    [SerializeField]
    private PlayerData playerData;
    
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

    // Update is called once per frame
    private void FixedUpdate()
    {
        PlayerRaycast();
    }

    private void Movement(Vector3 direction)
    {
        if(!GameManager.HitWall) 
        {
            transform.Translate(direction * playerData.Speed * Time.deltaTime);
        }
        
    }

    public void RotatePlayer()
    {
        cameraAxisX += Input.GetAxis("Mouse X");
        Quaternion newRotation = Quaternion.Euler(0, cameraAxisX, 0);
        transform.rotation= Quaternion.Lerp(transform.rotation, newRotation, 2f * Time.deltaTime);
    }

    private void PlayerRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(raycastPoint.position, raycastPoint.TransformDirection(Vector3.forward), out hit, playerData.RayDistance))
        {
            if (hit.transform.CompareTag("Wall"))
            {
                GameManager.HitWall = true;
                if(GameManager.HitWall)
                {
                    Debug.Log("Hit Wall: " + GameManager.HitWall);
                }
            }
        }
        else 
        {
            GameManager.HitWall = false;
        }
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Vector3 direction = raycastPoint.TransformDirection(Vector3.forward) * playerData.RayDistance;
        Gizmos.DrawRay(raycastPoint.position, direction);
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
