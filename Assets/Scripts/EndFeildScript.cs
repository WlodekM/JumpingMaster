using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndFeildScript : MonoBehaviour
{
    [SerializeField]
    GameObject show;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        show.SetActive(true);
        Time.timeScale = 0;
    }
}
