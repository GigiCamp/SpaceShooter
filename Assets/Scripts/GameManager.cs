using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public enum GameState
    {
        Start,
        Gameplay,
        GameOver,
        Win
    }

    public GameState currentState;
    private float elapsedTime = 0;
    private float timeRemaining;
    public float startTime;
    private float survivalTime = 0;

    public GameObject[] asteroidType;
    public float spawnRate;
    private float nextAsteroid;

    public Rigidbody player;
    public GameObject gameOver;
    public GameObject start;
    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI survivalTimeText;


    public void Start()
    {
        SwitchState(GameState.Start);
    }

    public void Update()
    {
        switch (currentState)
        {
            case GameState.Start:
                elapsedTime += Time.deltaTime;
                timeRemaining -= Time.deltaTime;

                countdownText.text = Mathf.FloorToInt(timeRemaining % 60).ToString();

                if (elapsedTime > startTime)
                {
                    SwitchState(GameState.Gameplay);
                }

                break;
            case GameState.Gameplay:
                survivalTime += Time.deltaTime;
                

                if (!player)
                {
                    SwitchState(GameState.GameOver);
                }

                if (Time.time > nextAsteroid)
                {
                    nextAsteroid = Time.time + spawnRate;
                    int i = Random.Range(0, asteroidType.Length);
                    Vector3 asteroidPosition = new Vector3(Random.Range(-1.8f, 1.8f), 0.8f, 5.2f);
                    Instantiate(asteroidType[i], asteroidPosition, Quaternion.identity);
                }

                break;
            case GameState.GameOver:

                break;
            case GameState.Win:

                break;

        }
    }

    public void SwitchState(GameState newState)
    {
        currentState = newState;
        switch (currentState)
        {
            case GameState.Start:
                player.isKinematic = true;
                timeRemaining = startTime;
                break;
            case GameState.Gameplay:
                player.isKinematic = false;
                start.SetActive(false);
                break;
            case GameState.GameOver:
                gameOver.SetActive(true);
                survivalTimeText.text = "Survival Time: " + Mathf.FloorToInt(survivalTime % 60).ToString() + "s";
                break;
            case GameState.Win:
                Time.timeScale = 0f;
                break;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void Exit()
    {
        Application.Quit();
    }
}
