using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    [SerializeField] private Text lastEnemyText;
    [SerializeField] private Image lastEnemyImage;
    [SerializeField] private Sprite[] lastEnemyIcon;

    [SerializeField] private Text scoreText;

    public static HUDManager instance;

    private void Awake()
    {
        if (instance == null)
        {   
            instance = this;
            Debug.Log(instance);
            DontDestroyOnLoad(gameObject);
        }else
        {
            Destroy(gameObject);
        }
    }

    private void Start() {
        scoreText.text = GameManager.Score.ToString();
    }

    public void SetLastEnemyText(string newText) {
        lastEnemyText.text = newText;
        SetLastEnemyIcon(newText);
    }

    public void SetLastEnemyIcon(string newText) {
        switch(newText) {
            case "Firetruck":
                lastEnemyImage.sprite = lastEnemyIcon[0];
                break;
            case "Racecar":
                lastEnemyImage.sprite = lastEnemyIcon[1];
                break;
            case "Suv":
                lastEnemyImage.sprite = lastEnemyIcon[2];
                break;
        }
    }

    public void SetScoreText() {
        scoreText.text = GameManager.Score.ToString();
    }
}
