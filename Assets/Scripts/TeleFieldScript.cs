using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleFieldScript : MonoBehaviour
{
    GameObject player;
    plaire playerScript;
    [SerializeField]
    GameObject teleportParticle;

    private void Start()
    {
        playerScript = GameObject.FindObjectOfType<plaire>();
        player = playerScript.gameObject;
    }

    void doTeleport()
    {
        player.transform.position = transform.GetChild(0).position;
        GameObject particle = Instantiate(teleportParticle, player.transform.position, Quaternion.identity);
        Destroy(particle, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        Invoke("doTeleport", 1f);
    }
}
