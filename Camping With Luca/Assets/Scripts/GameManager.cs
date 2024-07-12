using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public GameObject gameStartButton;
    public GameObject mainCamera;
    public GameObject gameTitle;

    private Vector3 cameraToRotation = new Vector3(14.659f, 29.092f, 2.639f);
    private Vector3 cameraToPosition = new Vector3(-5.26f, 2.87f, -39.63f);
    private float rotationSpeed = 0.3f;
    private float positionSpeed = 0.3f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickStartButton()
    {
        gameStartButton.gameObject.SetActive(false);
        gameTitle.gameObject.SetActive(false);
        mainCamera.transform.DORotate(cameraToRotation, rotationSpeed);
        mainCamera.transform.DOMove(cameraToPosition, positionSpeed);
    }
}
