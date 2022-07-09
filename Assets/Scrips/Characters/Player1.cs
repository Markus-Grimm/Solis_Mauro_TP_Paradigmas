using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1 : Player
{
    void Start()
    {
        gc = GameObject.FindGameObjectWithTag("GameController");
    }

    void Update()
    {
        movement();
        Jump();

        if (this.transform.position.y <= -20)
        {
            dead();
        }


    }
}
