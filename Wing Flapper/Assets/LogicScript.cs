using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;
    public Text highScoreText;
    public GameObject gameOverScreen;
    private AudioSource audioSrc;
    public static int highScore;
    bool initDone = false;

    private void Start()
    {
        if (!initDone)
        {
            Debug.Log("Running in Start");
            Debug.Log("Initializing the High Score");

            //Check to see if we have a high score in PlayerPrefs.  If so, populate it into highScore
            //If not, set it to 1
            if (PlayerPrefs.HasKey("highScore"))
            {
                highScore = PlayerPrefs.GetInt("highScore");
                Debug.Log("Found High Score in Prefs");
                Debug.Log("High Score = " + highScore.ToString());
            }
            else
            {
                Debug.Log("No High Score Found in Prefs");
                PlayerPrefs.SetInt("highScore", 1);
                highScore = 1;
                PlayerPrefs.Save();
            }
            initDone = true;
            highScoreText.text = highScore.ToString();
        }

        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    [ContextMenu("Increase Score")]
    public void addScore(int scoreToAdd)
    {
        playerScore = playerScore + scoreToAdd;
        scoreText.text = playerScore.ToString();
        if (playerScore > highScore)
        {
            highScore = playerScore;
            highScoreText.text = highScore.ToString();
        }
        audioSrc = GetComponent<AudioSource>();
        audioSrc.Play();
    }

    public void restartGame()
    {
        //Check to see if we have a high score in PlayerPrefs.  If so, populate it into highScore
        //If not, set it to 1
        if (PlayerPrefs.HasKey("highScore"))
        {
            highScore = PlayerPrefs.GetInt("highScore");
            Debug.Log("Found High Score in Prefs");
            Debug.Log("High Score = " + highScore.ToString());
        }
        else
        {
            Debug.Log("No High Score Found in Prefs");
            PlayerPrefs.SetInt("highScore", 1);
            highScore = 1;
            PlayerPrefs.Save();
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void gameOver()
    {
        Debug.Log("Game is over. playerScore = " + playerScore.ToString());
        Debug.Log("highScore = " + highScore.ToString());
        //If the player's score exceeded the highScore, update it.
        if (playerScore > highScore)
        {
            Debug.Log("Player beat high score.");
            PlayerPrefs.SetInt("highScore", playerScore);
            PlayerPrefs.Save();
        }
        gameOverScreen.SetActive(true);
    }
}
