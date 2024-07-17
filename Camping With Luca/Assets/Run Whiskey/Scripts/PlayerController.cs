using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private Animator playerAnim;
    private AudioSource playerAudio;
    private RunWhiskeyManager gameManager;

    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip jumpSound;
    public AudioClip crashSound;

    private float jumpForce = 130;
    private float gravityModifier = 5;

    private bool isOnTheGround;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        gameManager = GameObject.Find("Game Manager").GetComponent<RunWhiskeyManager>();

        Physics.gravity *= gravityModifier;

        playerAnim.SetTrigger("Stop_trig");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnTheGround && gameManager.isGameActive)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnTheGround = false;

            dirtParticle.Stop();
            playerAudio.PlayOneShot(jumpSound, 1.0f);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            isOnTheGround = true;
            dirtParticle.Play();

        } else if(collision.gameObject.CompareTag("Obstacle"))
        {
            gameManager.GameOver();

            dirtParticle.Stop();
            explosionParticle.Play();

            playerAnim.SetTrigger("Angry_trig");
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
    }
}
