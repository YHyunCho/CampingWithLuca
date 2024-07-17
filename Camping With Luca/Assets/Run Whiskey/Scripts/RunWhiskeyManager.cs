using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RunWhiskeyManager : MonoBehaviour
{
    public TextMeshProUGUI meterText;
    public TextMeshProUGUI howToPlayText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI resultText;

    public Button gameStartButton;
    public Button mainMenuButton;
    public Button restartButton;
    public Button mainMenuButton2;

    public Image notePaper;
    public List<GameObject> obstacles;

    public int meter;
    private float spawnRate = 3;
    public bool isGameActive;
    private int meterValue;

    // Start is called before the first frame update
    void Start()
    {
        meter = 0;
        meterValue = 1;
    }

    IEnumerator AddDistance()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(0.5f);

            UpdateDistance(meterValue);
        }
    }

    IEnumerator SpawnObstacles()
    {
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);

            int index = Random.Range(0, obstacles.Count);
            Instantiate(obstacles[index]);
        }
    }

    private void UpdateDistance(int distanceToAdd)
    {
        meter += distanceToAdd;
        meterText.text = "Score : " + meter;
    }

    public void GameStart()
    {
        isGameActive = true;

        gameStartButton.gameObject.SetActive(false);
        mainMenuButton.gameObject.SetActive(false);
        notePaper.gameObject.SetActive(false);
        howToPlayText.gameObject.SetActive(false);

        meterText.gameObject.SetActive(true);

        StartCoroutine(AddDistance());
        StartCoroutine(SpawnObstacles());
    }

    public void GameOver()
    {
        isGameActive = false;

        meterText.gameObject.SetActive(false);

        gameOverText.gameObject.SetActive(true);
        resultText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        mainMenuButton2.gameObject.SetActive(true);

        resultText.text = "Whiskey ren " + meter + " meter!";
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("Camping With Luca");
    }
}
