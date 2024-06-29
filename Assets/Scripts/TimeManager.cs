using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField]
    private float timeScale = 1f;
    // Start is called before the first frame update
    void FixedUpdate()
    {
        Time.timeScale = timeScale;
    }
}
