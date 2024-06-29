using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;

    private void Start()
    {
        Debug.Log("WHAR!");
    }

    private void OnMouseDown()
    {
        Debug.Log("shoot damn it!");
        Vector3 lookPos = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        Instantiate(bullet, transform.position, Quaternion.LookRotation(lookPos));
    }
}
