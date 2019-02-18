using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMove : MonoBehaviour
{
    public float moveSpeed;
    public float moveRange;

    private Vector3 oldPosition;
    private GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        obj = gameObject; //get reference to current gameObject for later use, for performance optimizing
        oldPosition = obj.transform.position;

        //initialize moveSpeed and moveRange
        moveSpeed = 5;
        moveRange = 20;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = new Vector3(transform.position.x - 1, transform.position.y, 0);
        obj.transform.Translate(new Vector3(-1 * Time.deltaTime * moveSpeed, transform.position.y, 0));

        //reset object to oldPosition
        if (Vector3.Distance(oldPosition, obj.transform.position) > moveRange)
        {
            obj.transform.position = oldPosition; 
        }
    }
}
