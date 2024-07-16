using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 15;
    private float leftBound = -15;

    private PlayerController pcScript;
    private RunWhiskeyManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        pcScript = GameObject.Find("Player").GetComponent<PlayerController>();
        gameManagerScript = GameObject.Find("Game Manager").GetComponent<RunWhiskeyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManagerScript.isGameActive)
        {
            if (gameManagerScript.meter % 50 == 0)
            {
                speed += 0.2f;
            }
            if (pcScript.gameOver == false)
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }

            if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
            {
                Destroy(gameObject);
            }
        }
    }
}
