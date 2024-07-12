using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RunWhiskeyManager : MonoBehaviour
{
    public TextMeshProUGUI meterText;
    private PlayerController pcScript;
    private int meter;
    private int meterValue;

    // Start is called before the first frame update
    void Start()
    {
        meter = 0;
        meterValue = 1;

        pcScript = GameObject.Find("Player").GetComponent<PlayerController>();

        StartCoroutine(AddDistance());
        UpdateDistance(0);
    }

    IEnumerator AddDistance()
    {
        while(pcScript.gameOver == false)
        {
            yield return new WaitForSeconds(0.5f);

            UpdateDistance(meterValue);
        }
    }

    private void UpdateDistance(int distanceToAdd)
    {
        meter += distanceToAdd;
        meterText.text = "Score : " + meter;
    }
}
