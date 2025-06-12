using UnityEngine;
using System.Collections;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidBody;
    

    public LogicScript logic;

    public bool birdIsAlive = true;
    public float flapStrength;
    public float moveSpeed = 0;
    public float rotateSpeed = 0;
    private AudioSource audioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rotateSpeed<0){
            rotateSpeed += 20 * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            audioSource.Play();
        }

        if(Input.GetKeyDown(KeyCode.Space) && birdIsAlive){
            myRigidBody.linearVelocity = Vector2.up * flapStrength;
            rotateSpeed -= 50;
        }

        transform.position = transform.position + Vector3.left * moveSpeed * Time.deltaTime;

        float rotAmount = rotateSpeed * Time.deltaTime;
        float curRot = transform.localRotation.eulerAngles.z;
        transform.localRotation = Quaternion.Euler(new Vector3(0,0,curRot+rotAmount));
        if(birdIsAlive){
            logic.setSpeed(Mathf.Round(rotateSpeed)*-1);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.layer == 8){
            birdIsAlive = false;
            // SO HACKY VERY BAD
            moveSpeed = 9;
            rotateSpeed = 0;
            logic.gameOver();
        }
    }
}
