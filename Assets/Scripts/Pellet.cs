using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pellet : MonoBehaviour
{
    private Rigidbody2D rb;
    
    public Color colorHostile = Color.red;
    public Color colorFriendly = Color.green;
    public GameManager gameManager;

    private bool isFriendly;

    private void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnEnable()
    {
        isFriendly = false;
        gameObject.GetComponent<SpriteRenderer>().color = colorHostile;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            if (col.gameObject.GetComponent<PlayerMovement>().IsGrounded())
            {
                if (isFriendly)
                {
                    Collect();
                }
                else
                {
                    Hit();
                }
            }
            else
            {
                TurnFriendly();
            }
        }
        else if (col.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Remove();
        }
    }

    private void Hit()
    {
        gameObject.SetActive(false);
        gameManager.UpdateLife(-1);
    }

    private void TurnFriendly()
    {
        gameObject.GetComponent<SpriteRenderer>().color = colorFriendly;
        rb.gravityScale = 0;
        isFriendly = true;
    }

    private void Collect()
    {
        gameObject.SetActive(false);
        gameManager.UpdateScore(1);
    }

    private void Remove()
    {
        gameObject.SetActive(false);
    }
}
