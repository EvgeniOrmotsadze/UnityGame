using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {
    public GameObject restartMenu;
    public Camera mainCamera;
    public GameObject[] obstacles;
    public Vector4[] backgroundColors;
    public Vector3 obstacleSpawnRange;
    public float levelTime;
    public float obstacleWaveWait;

    private bool gameOver;
    private float levelPassedTime;
    private int level;
    private int currentColorIndex;

    private int bestScore;
    private int currentScore;
    private int levelIncrementDeltaSpeed;

    void Start () {
        levelIncrementDeltaSpeed = 5;
        level = 0;
        bestScore = PlayerScores.GetBestScore();
        currentScore = 0;
        gameOver = false;
        levelPassedTime = 0.0f;
        currentColorIndex = 0;
        changeBackgroundColor();
        StartCoroutine(SpawnObstacles());
        StartCoroutine(addScoreInEverySecond());
	}

    private IEnumerator addScoreInEverySecond()
    {
        while (!gameOver)
        {
            addScore(1);
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(1);
    }

    public void GameOver () {
        gameOver = true;
    }

    public void addScore (int score) {
        currentScore += score;
        if (currentScore > bestScore) {
            bestScore = currentScore;
        }
    }

    IEnumerator SpawnObstacles ()
    {
        while (!gameOver)
        {
            if (levelTime < levelPassedTime) {
                loadNextLevel();
            }
            levelPassedTime += Time.deltaTime;
            Vector3 spawnPosition = getRandomPosition();
            GameObject randomObstacle = getRandomObstacle();
            GameObject obstacleObject = Instantiate(randomObstacle, spawnPosition, Quaternion.identity) as GameObject;
            obstacleObject.GetComponent<ObstacleController>().speed += level * levelIncrementDeltaSpeed;
            yield return new WaitForSeconds(obstacleWaveWait);
            levelPassedTime += obstacleWaveWait;
        }
        PlayerScores.addIfIsHighScore(currentScore);
        restartMenu.SetActive(true);
    }

    private GameObject getRandomObstacle() {
        return obstacles[Random.Range(0, obstacles.Length)];
    }

    private Vector3 getRandomPosition ()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float minX = player.transform.position.x - obstacleSpawnRange.x;
        float maxX = player.transform.position.x + obstacleSpawnRange.x;
        float randomXPosition = Random.Range(minX, maxX);
        return new Vector3(randomXPosition, obstacleSpawnRange.y, obstacleSpawnRange.z);
    }

    private void loadNextLevel ()
    {
        levelPassedTime = 0;
        level++;
        currentColorIndex = (currentColorIndex + 1) % backgroundColors.Length;
        changeBackgroundColor();
    }

    private void changeBackgroundColor () {
        mainCamera.GetComponent<Camera>().backgroundColor = backgroundColors[currentColorIndex];
    }

    internal int GetCurrentScore() {
        return currentScore;
    }

    internal int GetHighScore() {
        return bestScore;
    }
}
