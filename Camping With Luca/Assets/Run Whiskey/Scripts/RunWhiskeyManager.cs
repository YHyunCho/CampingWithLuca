using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class RunWhiskeyManager : MonoBehaviour
{
    public TextMeshProUGUI meterText;
    public TextMeshProUGUI howToPlayText;
    public Button gameStartButton;
    public Button mainMenuButton;
    public Image notePaper;
    public List<GameObject> obstacles;

    private PlayerController pcScript;

    public int meter;
    private float spawnRate = 3;
    public bool isGameActive;
    private int meterValue;

    // Start is called before the first frame update
    void Start()
    {
        meter = 0;
        meterValue = 1;

        pcScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    IEnumerator AddDistance()
    {
        while (!pcScript.gameOver)
        {
            yield return new WaitForSeconds(0.5f);

            UpdateDistance(meterValue);
        }
    }

    IEnumerator SpawnObstacles()
    {
        while (!pcScript.gameOver)
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

        StartCoroutine(AddDistance());
        StartCoroutine(SpawnObstacles());
    }
}
