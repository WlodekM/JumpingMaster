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
        bool isTurning = (0 > sped && 0 < rb2d.velocity.x);
        string turningmsg = isTurning ? "\n(Turning)" : "";
        dbgText.text = $"Velocity: ({rb2d.velocity.x}, {rb2d.velocity.y}){turningmsg}";
        if (isTurning) sped *= 5;
        if (Mathf.Abs(rb2d.velocity.x + sped) >= MaxSpeed) return;
        Debug.Log(sped);
        rb2d.AddForce(new Vector2(sped, 0f));
    }
}
