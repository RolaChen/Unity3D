using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterNewScene : MonoBehaviour
{
    public Transform player;
    bool m_IsPlayerInRange;
    public GameObject image;
    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform==player)
        {
            m_IsPlayerInRange = true;
            PlayerData.instance.location = transform.name;
            Debug.Log(PlayerData.instance.location);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.transform==player)
        {
            m_IsPlayerInRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (m_IsPlayerInRange)
            image.SetActive(true);
        else
            image.SetActive(false);
    }
}
