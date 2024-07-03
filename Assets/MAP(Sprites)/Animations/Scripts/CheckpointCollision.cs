using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointCollision : MonoBehaviour
{
    GameObject player;
    plaire playerScript;
    [SerializeField]
    GameObject coinParticle;
    private void Start()
    {
        playerScript = GameObject.FindObjectOfType<plaire>();
        player = playerScript.gameObject;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("checkpoint")) return;
        playerScript.startPosition = player.transform.position;
        //playerScript.updateCoinDisplay();
        //GameObject particle = Instantiate(coinParticle, collision.transform.position, Quaternion.identity);
        //Destroy(collision.gameObject);
        //Destroy(particle, 5f);
    }
}
