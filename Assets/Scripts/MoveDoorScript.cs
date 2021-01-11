using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDoorScript : MonoBehaviour
{
    private float timerWait = 5.0f;
    public float timer;
    public bool move;
    public GameObject Door;


    // Start is called before the first frame update
    void Start()
    {
        move = false;
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(move && Door.transform.position.y <= 10)
        {
            Door.transform.position += new Vector3 (0,0.01f,0);
            timer = 0;
        }
        if(!move && Door.transform.position.y >= 3.75 & timer >= timerWait)
        {
            Door.transform.position -= new Vector3(0, 0.01f, 0);
        }
    }

    public void moveTrue()
    {
        move = true;
    }
    public void moveFalse()
    {
        move = false;
    }
}
