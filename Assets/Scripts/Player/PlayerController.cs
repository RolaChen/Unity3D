using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{
    Camera cam;
    Touch touch;
    GameObject player;
    PlayerMovement movement;
    Vector2 start,end;
    float yaw = 0;

    void Start()
    {
        player = (GameObject)Resources.Load(PlayerData.instance.address);
        player = Instantiate(player, transform.position, transform.rotation);
        player.transform.parent = transform;
        player.name = PlayerData.instance.E_career;
        cam = Camera.main;
        movement = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount>0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                start = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Ended)
            {
                //Debug.Log("here");
                end = touch.position;
                yaw = start.x - end.x;
                
                if (Mathf.Abs(yaw) <0.1f)
                {
                    Ray ray = cam.ScreenPointToRay(touch.position);
                    RaycastHit hit;
                    Debug.Log("here");
                    if (Physics.Raycast(ray, out hit))
                    {
                        Debug.Log("before we hit" + hit.point);
                        movement.MoveToPoint(hit.point);
                    }
                }
            }
        }
        
    }
}
