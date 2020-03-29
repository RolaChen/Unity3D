using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{
    Camera cam;
    Touch touch;
    PlayerMovement movement;
    void Start()
    {
        cam = Camera.main;
        movement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount>0)
        {
            touch = Input.GetTouch(0);
            if(touch.phase==TouchPhase.Began)
            {
               Ray ray = cam.ScreenPointToRay(touch.position);
               RaycastHit hit;
               if(Physics.Raycast(ray, out hit))
               {
                  movement.MoveToPoint(hit.point);
               }
            }
        }
        
    }
}
