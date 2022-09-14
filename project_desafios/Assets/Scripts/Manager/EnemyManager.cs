using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> enemyList;
    [SerializeField] private Transform playerTransform;

    public static float enemyNumber = 0f;
    private float enemySpeed = 0.5f;

    public static event Action onEnemyCreated;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(enemyList.Count);
        Enemy.onEnemyDestroyed += increaseEnemySpeed;
        InvokeRepeating("CreateEnemy", 5f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void CreateEnemy() {
        Debug.Log("onEnemyCreated-Called-AudioManager");
        onEnemyCreated?.Invoke();
        int random = UnityEngine.Random.Range(0, enemyList.Count);
        GameObject enemy = Instantiate(enemyList[random], new Vector3(playerTransform.position.x, 0f, playerTransform.position.z * -1), playerTransform.rotation);
        enemy.GetComponent<Enemy>().PlayerTransform = playerTransform;
        enemy.GetComponent<EnemyChaser>().Velocity = enemySpeed;
        //HUDManager.instance.SetLastEnemyText(enemy.gameObject.tag);
    }

    private void increaseEnemySpeed() {
        Debug.Log("onEnemyDestroyed-Received-EnemyManager");
        Debug.Log("Speed" + enemySpeed);
        enemySpeed += 0.5f;
    }
}
