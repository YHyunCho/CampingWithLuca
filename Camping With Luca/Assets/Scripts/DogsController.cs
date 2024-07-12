using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DogsController : MonoBehaviour
{
    private Rigidbody dogRb;
    private Vector3 moveDir;

    public float speed = 10;
    private float turnSpeed = 50;
    private float rotationSpeed = 1;

    //private float xMaxRange = -0.5f;
    //private float xMinRange = -5.4f;
    //private float zMaxRange = -31f;
    //private float zMinRange = -35f;
    
    // Start is called before the first frame update
    void Start()
    {
        dogRb = GetComponent<Rigidbody>();
        moveDir = RandomDirection();
    }

    // Update is called once per frame
    void Update()
    {
        //CheckOutOfBound();
        dogRb.AddForce(moveDir * speed, ForceMode.Impulse);
        transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * turnSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collision");
        //transform.Rotate(0, Random.Range(-90, 90), 0);
        RandomDirection();
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Debug.Log("Trigger");
    //    transform.Rotate(0, Random.Range(-90, 90), 0);
    //}

    //private void CheckOutOfBound()
    //{
    //    if (transform.position.x > xMaxRange)
    //    {
    //        transform.position = new Vector3(xMaxRange, transform.position.y, transform.position.z);
    //        DogMovement();
    //    }
    //    if (transform.position.x < xMinRange)
    //    {
    //        transform.position = new Vector3(xMinRange, transform.position.y, transform.position.z);
    //        DogMovement();
    //    }
    //    if (transform.position.z > zMaxRange)
    //    {
    //        transform.position = new Vector3(transform.position.x, transform.position.y, zMaxRange);
    //        DogMovement();
    //    }
    //    if (transform.position.z < zMinRange)
    //    {
    //        transform.position = new Vector3(transform.position.x, transform.position.y, zMinRange);
    //        DogMovement();
    //    }
    //    if (transform.position.y < 0)
    //    {
    //        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
    //        DogMovement();
    //    }
    //}

    Vector3 RandomDirection()
    {
        return new Vector3(Random.Range(-1, 2), 0, Random.Range(-1, 2)).normalized;
    }

    //void DogMovement()
    //{
    //    dogRb.AddForce(moveDir * speed, ForceMode.Impulse);
    //    transform.forward = Vector3.Slerp(transform.forward, moveDir, Time.deltaTime * turnSpeed);
    //}
}
