using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DogsController : MonoBehaviour
{
    private Animator dogAnim;
    
    // Start is called before the first frame update
    void Start()
    {
        dogAnim = GetComponent<Animator>();

        dogAnim.SetTrigger("Tail_trig");
    }

    private void OnMouseDown()
    {
        if (gameObject.CompareTag("Whiskey"))
        {
            SceneManager.LoadScene("Run Whiskey");
        }
    }

    

}
