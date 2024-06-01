using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField]
    private WheelJoint2D backWheel, frontWheel;
    private JointMotor2D motor;
    [SerializeField]
    private float speed;
    private bool moveForward, moveBackward = false;
    [SerializeField]
    private float acceleration = 100;
    [SerializeField]
    private float direction = 0;
    public bool[] grounded = { false, false, false };
    public bool ggrroouunnddeedd = false;
    Rigidbody2D rigidbody;

    int toInt(bool a) { return System.Convert.ToInt32(a); }
    // Start is called before the first frame update
    void Start()
    {
        motor.maxMotorTorque = 100000;
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // 1(true, move forward) - 0(false not move backward) = 1
        // 
        direction = (toInt(Input.GetKey("d")) - toInt(Input.GetKey("a")));
        speed += (direction - speed) / (1 / acceleration);
        motor.motorSpeed = speed * 750;
        bool useMotor = (Input.GetKey("d") || Input.GetKey("a"));
        (backWheel.useMotor, frontWheel.useMotor) = (useMotor, useMotor);
        ggrroouunnddeedd = (grounded[0] || grounded[1] || grounded[2]);
        if (!(grounded[0] || grounded[1] || grounded[2]))
        {
            rigidbody.angularVelocity += speed * 2;
        }
    }

    void checkForDie()
    {
        Vector2 rayDir = transform.up;
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, rayDir, 1.5f);
        Debug.DrawRay(transform.position, rayDir * 1.5f, Color.red);
        if (hit.Length <= 1) return;
        RaycastHit2D theHIT = hit[1];
        if (theHIT.transform.gameObject.CompareTag("NoHit")) return;
        SceneManager.LoadScene("SampleScene");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a") || Input.GetKey("d")) (backWheel.motor, frontWheel.motor) = (motor, motor);
        (moveForward, moveBackward) = (Input.GetKey("d"), Input.GetKey("a"));
        grounded[2] = rigidbody.IsTouchingLayers();
        checkForDie();
    }
}
