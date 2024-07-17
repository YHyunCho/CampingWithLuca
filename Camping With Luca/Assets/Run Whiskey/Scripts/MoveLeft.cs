using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed = 15;
    private float leftBound = -15;

    private RunWhiskeyManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<RunWhiskeyManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.isGameActive)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);

            if (gameManager.meter % 50 == 0)
            {
                speed += 0.2f;
            }
            if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
            {
                Destroy(gameObject);
            }
        }
    }
}
