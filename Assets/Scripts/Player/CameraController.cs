using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, -0.29f, -0.55f);
    public float currentZoom = 10f;
    public float pitch = 2f;//玩家的身高
    Touch touch;
    Vector2 start, end;
    float yaw = 0;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                start = touch.position;
            }

            else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Ended)
            {
                end = touch.position;
                yaw -= (start.x - end.x)/10*Time.deltaTime;               
            }
        }
        else
            yaw -= 0;
    }


    void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);
        transform.RotateAround(target.position, Vector3.up, yaw);
    }


}
