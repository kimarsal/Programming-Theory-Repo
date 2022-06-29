using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Sprite[] handSprites = new Sprite[3];
    public ParticleSystem explosionPrefab;
    public AudioSource winAudio;
    public AudioSource loseAudio;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public GameObject gameOverScreen;
    private int score = 0;
    private int numEnemies;
    private int numRound;

    void Start()
    {
        if (PersistanceManager.Instance != null && PersistanceManager.Instance.highScore.score != 0)
        {
            highScoreText.text = "High Score: " + PersistanceManager.Instance.highScore.score + " [" + PersistanceManager.Instance.highScore.name + "]";
        }
    }

    void Update()
    {
        if(numEnemies == 0)
        {
            numRound++;

            for (numEnemies = 0; numEnemies < numRound * 3; numEnemies++)
            {
                GameObject hand = Instantiate(enemyPrefab);
                hand.GetComponent<EnemyScript>().Type = (HandScript.HandType)(numEnemies % 3);
            }
        }
    }

    public void EnemyLose(Vector3 position)
    {
        winAudio.Play();
        PlayExplosion(position);
        score++;
        scoreText.text = "Score: " + score;
        numEnemies--;
    }

    public void PlayerLose(Vector3 position)
    {
        loseAudio.Play();
        PlayExplosion(position);

        gameOverScreen.SetActive(true);
        if (PersistanceManager.Instance != null && PersistanceManager.Instance.playerName != null)
        {
            if (PersistanceManager.Instance.highScore.name == null || PersistanceManager.Instance.highScore.score < score)
            {
                PersistanceManager.Instance.highScore.name = PersistanceManager.Instance.playerName;
                PersistanceManager.Instance.highScore.score = score;
                PersistanceManager.Instance.SaveHighScore();
            }
        }
    }

    private void PlayExplosion(Vector3 position)
    {
        position += new Vector3(0, 0, 20);
        ParticleSystem explosion = Instantiate(explosionPrefab, position, explosionPrefab.transform.rotation);
        explosion.Play();
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
