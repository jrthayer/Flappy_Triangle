using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public Text speedText;
    public GameObject gameOverScreen;
    public GameObject musicManager;
    public AudioSource backgroundMusic;

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd){
        score+= scoreToAdd;
        scoreText.text = score.ToString();
    }

    public void setSpeed(float speed){
        speedText.text = speed.ToString();
    }

    public void restartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver(){
        gameOverScreen.SetActive(true);
        
        backgroundMusic.Stop();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public AudioSource audioSource;

    private void Start()
    {
        //Setup background music
        backgroundMusic = musicManager.GetComponent<AudioSource>();
        backgroundMusic.Play();

        //Hide cursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
