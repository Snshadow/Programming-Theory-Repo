using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player; 
    public Button startButton; 
    public Button restartButton;
    public TextMeshProUGUI titleText; 
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI timeText;
    public AudioSource explodeSound;
    public ParticleSystem explodeParticle;
    public bool isGameActive;
    private float time;
    private int seconds;
    private int minutes;

    void Start() 
    {
       
    }

    void Update()
    {
        if (isGameActive)
        {
            time += Time.deltaTime;
            seconds = (int)time % 60;
            minutes = (int)time / 60;
            timeText.text = "Time: " + minutes + "min " + seconds + "sec";
        }
    }

    public void StartGame()
    {
        isGameActive = true;
        titleText.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        explodeParticle.Play();
        explodeSound.Play();
        Invoke(nameof(DeletePlayer), 0.2f);
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void DeletePlayer()
    {
        player.SetActive(false);
    }
}
