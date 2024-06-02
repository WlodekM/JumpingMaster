using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class plaire : MonoBehaviour
{
    Rigidbody2D rb2d;
    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float MaxSpeed = 5f;

    private Text dbgText;


    // Start is called before the first frame update
    void Start()
    {
        dbgText = GameObject.FindWithTag("debugText").GetComponent<Text>();
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float sped = Input.GetAxis("Horizontal") * speed * Time.deltaTime * 100;
        bool isTurning = (0 > sped && 0 < rb2d.velocity.x) || (sped > 0 && rb2d.velocity.x < 0);
        string turningmsg = isTurning ? "\n(Turning)" : "";
        if(Input.GetKeyDown("W") || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            //Do jump
        }
        dbgText.text = $"Velocity: ({rb2d.velocity.x}, {rb2d.velocity.y}){turningmsg}";
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
