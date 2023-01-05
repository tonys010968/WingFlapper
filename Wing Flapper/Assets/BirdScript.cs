using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;


    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        float yPos;
        float topTrigger = 16;
        float bottomTrigger = -16;

        //If the space bar is pressed, flap the bird
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
        }

        //Check the Y Position
        //If the bird goes off the screen, end the game
        yPos = myRigidbody.position.y;
        //Debug.Log("Bird is at " + yPos.ToString());
        if (yPos > topTrigger || yPos < bottomTrigger)
        {
            logic.gameOver();
            birdIsAlive = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        birdIsAlive = false;
    }

}
