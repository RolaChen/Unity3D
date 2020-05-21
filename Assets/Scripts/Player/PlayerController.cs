using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//[RequireComponent(typeof(PlayerMovement))]
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
        StartCoroutine(getMovement());
    }

    IEnumerator getMovement()
    {
        yield return
        movement = transform.Find(PlayerData.instance.E_career).GetComponent<PlayerMovement>();
        Scene scene = SceneManager.GetActiveScene();
        if(scene.name=="LoginScene")
        {
            Debug.Log(scene.name);
            if (PlayerData.instance.pre_Scene != null)
                movement.born(UserData.instance.location[PlayerData.instance.pre_Scene]);
        }
        else if(scene.name == "Hospital")
        {
            Debug.Log(scene.name);
            switch(PlayerData.instance.pre_Scene)
            {
                case "TCM":
                    movement.born(UserData.instance.location["TCM"]);
                    break;
                case "Dentist":
                    movement.born(UserData.instance.location["Dentist"]);
                    break;
                case "Psychiatrist":
                    movement.born(UserData.instance.location["Psychiatrist"]);
                    break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {       
        //Debug.Log(player.transform.position);
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
