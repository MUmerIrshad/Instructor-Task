using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int totalScore;
    public TMP_Text score;
    public GameObject levelFailed;
    public GameObject levelComplete;
    private int life = 5;
    public GameObject[] Life;
    public static GameManager gamePlayManager;
    private void Awake()
    {

        if (gamePlayManager == null)
        {
            gamePlayManager = this;
        }
    }
    public void LifeDown()
    {
        if (life > 0)
        {
            // Decrement in Life of the player if ball hit to a player
            life -= 1;
            Life[life].gameObject.SetActive(false);
        }
        else
        {
            // if life is Zero then player is died and Stop game and show button is Restart button
            Time.timeScale = 0;
            levelFailed.gameObject.SetActive(true);
        }
    }
    public void levelComple()
    {
        levelComplete.gameObject.SetActive(true);
    }
    public void scorePlus()
    {
        totalScore += 5;
        score.text = totalScore.ToString();
    }
    public void restartScene()
    {
        // restart Scene
        levelFailed.gameObject.SetActive(false);
        levelFailed.gameObject.SetActive(false);
        Time.timeScale = 1;
        SceneManager.LoadScene("Level1");
    }

}
