﻿using UnityEngine;

public class baseScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy1" || collision.tag == "Enemy2" || collision.tag == "Enemy3")
        {
            enemyShotScript.lost = true;
        }
    }
}
