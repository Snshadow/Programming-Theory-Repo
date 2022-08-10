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
    public TextMeshProUGUI instruction;
    public AudioSource explodeSound;
    public ParticleSystem explodeParticle;

    public bool isGameActive;
    public float time;

    private int seconds;
    private int minutes;

    void Update()
    {
        if (isGameActive)
        {
            time += Time.deltaTime;
            seconds = (int)time % 60;
            minutes = (int)time / 60;
            timeText.text = "Time: " + minutes + "min " + seconds + "sec";
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void StartGame()
    {
        isGameActive = true;
        titleText.gameObject.SetActive(false);
        startButton.gameObject.SetActive(false);
        instruction.gameObject.SetActive(false);
        Cursor.visible = false;
    }

    public void GameOver()
    {
        explodeParticle.Play();
        explodeSound.Play();
        Invoke(nameof(DeletePlayer), 0.2f);
        isGameActive = false;
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        Cursor.visible = true;
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
