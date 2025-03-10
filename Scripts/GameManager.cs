using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject pipes;
    [SerializeField] private Vector3 spawnPosition;
    [SerializeField] private float spawnTime;
    [SerializeField] private float minYPosition;
    [SerializeField] private float maxYPosition;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject gameOver;
    [SerializeField] private GameObject restart;
    [SerializeField] private GameObject scoreObject;
    [SerializeField] private GameObject getReady;
    [SerializeField] private AudioManager audioManager;

    private int score = 0;
    private bool canPlay = true;
    [SerializeField] private bool isPlay = false;
    private float spawnTimeSeconds;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimeSeconds = spawnTime;
        scoreText.text = "" + score;
        scoreObject.SetActive(false);
        getReady.SetActive(true);
        gameOver.SetActive(false);
        restart.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!canPlay)
        {
            return;
        }
        spawnTimeSeconds -= Time.deltaTime;
        if(spawnTimeSeconds < 0 && isPlay)
        {
            spawnTimeSeconds = spawnTime;
            float yOffset = Random.Range(minYPosition, maxYPosition);
            spawnPosition.y = yOffset;
            GameObject temp = Instantiate(pipes, spawnPosition, Quaternion.identity);
            Pipes tempPipe = temp.GetComponent<Pipes>();
            tempPipe.Setup(this);
        }
        if(score <=20)
        {
            spawnTime = 1.5f;
        }else if(score>20 && score <=30)
        {
            spawnTime = 1f;
        }else if(score >30 && score <=35)
        {
            spawnTime = 0.75f;
        }else if(score >35)
        {
            spawnTime = 0.5f;
        }
        if(isPlay)
        {
            scoreObject.SetActive(true);
            getReady.SetActive(false);
        }
    }

    public bool GetCanPlay()
    {
        return canPlay;
    }
    public void SetCanPlay(bool cp)
    {
        canPlay = cp;
        if(!canPlay)
        {
            audioManager.AudioGameOver();
            gameOver.SetActive(true);
            restart.SetActive(true);
        }
    }
    public bool GetIsPlay()
    {
        return canPlay;
    }
    public void SetIsPlay(bool ip)
    {
        isPlay = ip;
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = ""+score;
    }

    public void RestartGame() 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
