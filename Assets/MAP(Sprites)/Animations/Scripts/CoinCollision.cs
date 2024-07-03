using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollision : MonoBehaviour
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("coin")) return;
        playerScript.coins++;
        playerScript.updateCoinDisplay();
        GameObject particle = Instantiate(coinParticle, collision.transform.position, Quaternion.identity);
        Destroy(collision.gameObject);
        Destroy(particle, 5f);
    }
}
