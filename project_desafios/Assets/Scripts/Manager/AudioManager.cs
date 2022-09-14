using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [SerializeField] private AudioClip backAudio;
    [SerializeField] private AudioClip enemyAudio;

    private AudioSource audioPlayer;

    // Start is called before the first frame update
    void Start()
    {
        audioPlayer = GetComponent<AudioSource>();
        PlayerMovement.onMoveBackwards += PlayerBackMovement;
        EnemyManager.onEnemyCreated += EnemyAudio;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void PlayerBackMovement() 
    {
        Debug.Log("onMoveBackwards-Received-AudioManager");
        PlayAudio(backAudio);
    }

    private void EnemyAudio() {
        Debug.Log("onEnemyCreated-Received-AudioManager");
        PlayAudio(enemyAudio);
    }

    private void PlayAudio(AudioClip auidoClip) {
        if (!audioPlayer.isPlaying)
        {
            audioPlayer.PlayOneShot(auidoClip);
        }
    } 
}
