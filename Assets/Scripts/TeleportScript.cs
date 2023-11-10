using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    //public GameObject portals;
    GameObject teleportLocation;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        //portals = GameObject.FindWithTag("PortalPart");

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            TeleportPlayer();

        }
    }


    public void TeleportPlayer()
    {
        GameObject loc = GameObject.Find("TeleportLocation");
        player.transform.position = loc.transform.position;
    }


}
