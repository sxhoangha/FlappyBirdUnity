using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdController : MonoBehaviour
{

    GameObject obj; //to store current game object 
    GameObject gameController; // to get access to GameController class

    public AudioClip flyClip;
    public AudioClip gameOverClip;
    private AudioSource audioSource;

    public float flyPower = 50; 
    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject; //get the current game object
        //flyPower = 20;

        audioSource = obj.GetComponent<AudioSource>(); //get audio source
        audioSource.clip = flyClip; //set the clip when game start

        if (gameController == null)
        {
            gameController = GameObject.FindGameObjectWithTag("GameController");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (!gameController.GetComponent<GameController>().isEndGame) //audio play only when in game, not after end game
                audioSource.Play();
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, flyPower));
        }
    }

    void OnCollisionEnter2D(Collision2D other) //when bird collide with wall
    {
        EndGame();
    }

    //Get point when bird collide with trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        gameController.GetComponent<GameController>().GetPoint();
    }

    private void EndGame()
    {
        audioSource.clip = gameOverClip;
        audioSource.Play();
        gameController.GetComponent<GameController>().EndGame();
    }
}
