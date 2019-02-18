using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMove : MonoBehaviour
{
    public float moveSpeed;

    public float minY;
    public float maxY;

    private float oldPosition;
    private GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject; //get reference to current gameObject for later use, for performance optimizing
        oldPosition = 10;

        //initialize moveSpeed and moveRange
        moveSpeed = 5;

        minY = -1;
        maxY = 1;
        
    }

    // Move wall along X
    void Update()
    {
        //transform.position = new Vector3(transform.position.x - 1, transform.position.y, 0);
        obj.transform.Translate(new Vector3(-1 * Time.deltaTime * moveSpeed, 0, 0));        
    }

    //move wall to new position when collide with ResetWall
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("ResetWall")) //reset wall when a wall collide with the ResetWall gameObject
            obj.transform.position = new Vector3(oldPosition, Random.Range(minY, maxY + 1), 0);
    }
}
