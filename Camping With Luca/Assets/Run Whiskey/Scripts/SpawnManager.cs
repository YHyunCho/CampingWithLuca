using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public List<GameObject> obstacles;
    private PlayerController pcScript;

    private float spawnRate = 3;

    // Start is called before the first frame update
    void Start()
    {
        pcScript = GameObject.Find("Player").GetComponent<PlayerController>();
        
        StartCoroutine(SpawnObstacles());
    }

    IEnumerator SpawnObstacles()
    {
        while(pcScript.gameOver == false)
        {
            yield return new WaitForSeconds(spawnRate);

            int index = Random.Range(0, obstacles.Count);
            Instantiate(obstacles[index]);
        }
    }
}
