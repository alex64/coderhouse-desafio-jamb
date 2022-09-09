using UnityEngine;

public class EnemyChaser : Enemy
{

    [SerializeField]
    protected EnemyChaseData enemyChaserData;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChasePlayer();
    }

    private void ChasePlayer()
    {
        if(!GameManager.HitCar) 
        {
            LookPlayer();
            Vector3 chaseDirection = PlayerTransform.position - transform.position;
            if(chaseDirection.magnitude > enemyChaserData.EnemySeparation)
            { 
                transform.position += chaseDirection.normalized * enemyChaserData.Speed
                 * Time.deltaTime; 
            }
        }
        
    }
}
