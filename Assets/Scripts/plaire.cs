﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class plaire : MonoBehaviour
{
    public float health = 100f; // publick
    Rigidbody2D rb2d;
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float MaxSpeed = 5f;
    [SerializeField]
    private float jumpHeight = 5f;

    private int jumpCount = 0;

    private Text dbgText;

    private bool touching;


    // Start is called before the first frame update
    void Start()
    {
        dbgText = GameObject.FindWithTag("debugText").GetComponent<Text>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        touching = true;
        jumpCount = 0;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        touching = false;
    }

    // Update is called once per frame
    void Update()
    {
        float sped = Input.GetAxis("Horizontal") * speed * Time.deltaTime * 100;
        bool isTurning = (0 > sped && 0 < rb2d.velocity.x) || (sped > 0 && rb2d.velocity.x < 0);
        string turningmsg = isTurning ? "\n(Turning)" : "";
        dbgText.text = $"Velocity: ({rb2d.velocity.x}, {rb2d.velocity.y}){turningmsg}";
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && (touching || jumpCount < 2))
        {
            dbgText.text = $"Velocity: ({rb2d.velocity.x}, {rb2d.velocity.y}){turningmsg}\n(JUMPING, jc: {jumpCount})";
            rb2d.AddForce(new Vector2(0, jumpHeight * 100));
            jumpCount++;
            return;
        }
        if (isTurning) sped *= 5;
        if(rb2d.velocity.x > MaxSpeed)
        {
            sped = MaxSpeed - rb2d.velocity.x;
        }
        if (rb2d.velocity.x < -MaxSpeed)
        {
            sped = -MaxSpeed - rb2d.velocity.x;
        }
        Debug.Log(sped);
        rb2d.AddForce(new Vector2(sped, 0f));
    }
}
