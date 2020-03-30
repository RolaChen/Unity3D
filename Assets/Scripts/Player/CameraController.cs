using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0f, -0.29f, -0.55f);
    public float currentZoom = 10f;
    public float pitch = 2f;//玩家的身高

    private void LateUpdate()
    {
        Debug.Log("target "+target.rotation);
        Debug.Log("camera "+transform.rotation);
        transform.rotation=Quaternion.Euler(target.rotation.x, target.rotation.y, transform.rotation.x);
        Debug.Log("camera2 " + transform.rotation);
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);
        //transform.rotation= target.rotation;
    }
}
