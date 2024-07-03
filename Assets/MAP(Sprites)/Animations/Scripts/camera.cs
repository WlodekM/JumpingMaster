using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    public float speed = 50;
    private Transform _target;

    // Start is called before the first frame update
    void Start()
    {
        _target = FindObjectOfType<plaire>().GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        /*Debug.Log(_target.position.y);*/
        if (true)
        {
            Vector3 newPos = new Vector3(_target.position.x, _target.position.y, -10);
            transform.position = Vector3.Lerp(transform.position, newPos, speed);
        }
    }
}
