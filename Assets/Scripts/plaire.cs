using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// dani is love dani is life
// unity's particle system, my fellow boners

public class plaire : MonoBehaviour
{
    public int health = 3; // publick
    public int coins = 0;
    Rigidbody2D rb2d;
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float MaxSpeed = 5f;
    [SerializeField]
    private float jumpHeight = 5f;
    [SerializeField]
    private Vector2 startPosition = new Vector2(0f, 0f);

    private Text coinDisplayText;

    private float notTouchingTime = 0f;

    private int jumpCount = 0;

    private Text dbgText;

    private bool touching;


    // Start is called before the first frame update
    void Start()
    {
        dbgText = GameObject.FindWithTag("debugText").GetComponent<Text>();
        coinDisplayText = GameObject.Find("CoinDisplay").GetComponent<Text>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        updateCoinDisplay();
    }

    public void updateCoinDisplay()
    {
        coinDisplayText.text = $"Coins: {coins}";
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        touching = true;
        jumpCount = 0;
        notTouchingTime = 1f;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("spike"))
        {
            health--;
            //transform.position = startPosition;
            FindObjectOfType<Healthbarscript>().update();
        }
    }

    private void FixedUpdate()
    {
        if (!touching && notTouchingTime > 0f) notTouchingTime -= 0.5f;
        if (notTouchingTime <= 0f) notTouchingTime = 0f;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        touching = false;
    }

    // Update is called once per frame
    void Update()
    {
        float sped = Input.GetAxis("Horizontal") * speed * Time.deltaTime * 100;
        bool bCanAppllyInAirBoostToCharacterSpeed = !touching && notTouchingTime <= 0.5f;
        bool isTurning = (0 > sped && 0 < rb2d.velocity.x) || (sped > 0 && rb2d.velocity.x < 0);
        string turningmsg = isTurning ? "\n(Turning)" : "";
        dbgText.text = $"Velocity: ({rb2d.velocity.x}, {rb2d.velocity.y}){turningmsg}\n{bCanAppllyInAirBoostToCharacterSpeed}\nntt: {notTouchingTime}";
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space)) && (touching || jumpCount < 2))
        {
            //dbgText.text = $"Velocity: ({rb2d.velocity.x}, {rb2d.velocity.y}){turningmsg}\n(JUMPING, jc: {jumpCount})";
            rb2d.AddForce(new Vector2(0, jumpHeight * 100));
            jumpCount++;
            return;
        }
        if (isTurning) sped *= 5;
        if (bCanAppllyInAirBoostToCharacterSpeed && isTurning) sped *= (25 * (1f - notTouchingTime));
        if (rb2d.velocity.x > MaxSpeed)
        {
            sped = MaxSpeed - rb2d.velocity.x;
        }
        if (rb2d.velocity.x < -MaxSpeed)
        {
            sped = -MaxSpeed - rb2d.velocity.x;
        }
        rb2d.AddForce(new Vector2(sped, 0f));
    }
}
