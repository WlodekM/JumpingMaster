using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleFieldScript : MonoBehaviour
{
    GameObject player;
    plaire playerScript;
    [SerializeField]
    GameObject teleportParticle;
    bool whiteTransition = false;
    float elapsedTime = 0f;
    float transitionDuration = 1f;
    float transitionStart = 0f;
    float transitionEnd = 1f;
    GameObject whiteObj;
    SpriteRenderer sr;

    private void Start()
    {
        whiteObj = GameObject.FindGameObjectWithTag("white");
        playerScript = GameObject.FindObjectOfType<plaire>();
        player = playerScript.gameObject;
        sr = whiteObj.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (whiteTransition) {
            elapsedTime += Time.deltaTime;
            sr.color = new Color(1, 1, 1, Mathf.Lerp(transitionStart, transitionEnd, elapsedTime / transitionDuration));
            if (elapsedTime >= transitionDuration) whiteTransition = false;
        } else
        {
            elapsedTime = 0f;
        }
    }

    void doTeleport()
    {
        Transform child = transform.GetChild(0);
        whiteTransition = true;
        transitionDuration = 0.1f;
        transitionStart = 1f;
        transitionEnd = 0f;
        sr.color = new Color(1, 1, 1, 0);
        player.transform.position = new Vector3(child.position.x, child.position.y, 0);
        GameObject particle = Instantiate(teleportParticle, player.transform.position, Quaternion.identity);
        Destroy(particle, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        whiteTransition = true;
        Invoke("doTeleport", 1f);
    }
}
