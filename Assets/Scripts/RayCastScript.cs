using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RayCastScript : MonoBehaviour
{
    LayerMask groundLayerMask;

    void Start()
    {
        groundLayerMask = LayerMask.GetMask("Ground");
    }

    public bool DoRayCollisionCheck(float xo, float yo)
    {
        float rayLength = 0.4f;
        Vector3 offset = new Vector3(xo, yo, 0);

        RaycastHit2D hit;
        bool hitGround = false;
        hit = Physics2D.Raycast(transform.position + offset, Vector2.down, rayLength, groundLayerMask);
        Color hitColor = Color.white;

        if (hit.collider != null)
        {
            hitGround = true;
            hitColor = Color.green;
        }

        Debug.DrawRay(transform.position + offset, Vector2.down * rayLength, hitColor);return hitGround;
    }

    public bool ExtendedRayCollisionCheck(float xoffs, float yoffs)
    {
        float rayLength = 0.4f;
        bool hitSomething = false;

        Vector3 offset = new Vector3(xoffs, yoffs, 0);

        RaycastHit2D hit;

        hit = Physics2D.Raycast(transform.position + offset, -Vector2.up, rayLength, groundLayerMask);

        Color hitColor = Color.white;

        if (hit.collider != null)
        {
            hitColor = Color.green;
            hitSomething = true;
        }

        Debug.DrawRay(transform.position + offset, -Vector2.up * rayLength, hitColor);

        return hitSomething;
    }
}
