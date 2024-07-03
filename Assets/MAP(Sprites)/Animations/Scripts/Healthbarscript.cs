using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbarscript : MonoBehaviour
{
    [SerializeField]
    GameObject[] hearts;
    [SerializeField]
    GameObject playerObj;
    [SerializeField]
    Sprite emptyHeartSprite;
    [SerializeField]
    Sprite fullHeartSprite;
    plaire player;
    private void Start()
    {
        player = playerObj.GetComponent<plaire>();
    }
    public void update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            Debug.Log($"{i} > {player.health}");
            GameObject heart = hearts[i];
            if(i < player.health)
            {
                heart.GetComponent<Image>().sprite = fullHeartSprite;
            } else
            {
                heart.GetComponent<Image>().sprite = emptyHeartSprite;
            }
        }
        if(player.health == 0)
        {
            Time.timeScale = 0;
        }
        Debug.LogError("L");
    }
}
