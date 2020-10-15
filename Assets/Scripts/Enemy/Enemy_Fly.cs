using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Fly : Enemy
{ 
    void Start()
    {
        Invoke("Die", timeLeftAlive);   
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        //transform.Rotate(1f, 0f, 0f);
    }


    public override void randomSpawn()
    {
        float randomX = Random.value * 12 - 6;

        setLocation(randomX, 5, randomDirection(randomX));
    }

    private Vector2 randomDirection(float x)
    {
        Vector2 dir = new Vector2(0, 0);
        dir.x = Random.value;
        dir.y = 1;

        dir = dir.normalized;

        if (x > 0)
            dir.x = -Mathf.Abs(dir.x);

        dir.y *= -1;

        return dir;
    }
}
