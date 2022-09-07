using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static bool hitCar;
    public static bool HitCar { get => hitCar; set => hitCar = value; }

    private static bool hitWall;
    public static bool HitWall { get => hitWall; set => hitWall = value; }
    
    private static int score = 100;
    public static int Score { 
        get => score; 
        set {
            score = value;
            HUDManager.instance.SetScoreText();
        }
    }

    public static GameManager instance;

    private void Awake()
    {
        if (instance == null)
        {   
            instance = this;
            Debug.Log(instance);
            hitWall = false;
            hitCar = false;
            DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        }
    }
}
