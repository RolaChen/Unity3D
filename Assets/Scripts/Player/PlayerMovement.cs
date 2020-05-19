using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;
    public Text text;


    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(PlayerData.instance.E_career);
        animator = transform.Find(PlayerData.instance.E_career).GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        
    }

    public void MoveToPoint(Vector3 point)
    {
        if (text != null)
        {
            text.text = "we hit " + point;
            if(animator==null)
            {
                text.text = point + " null";
                transform.Find(PlayerData.instance.E_career).GetComponent<Animator>();
            }
        }    
        if(agent==null)
            agent = GetComponent<NavMeshAgent>();            
        agent.SetDestination(point);
    }

    private void Update()
    {
        if (Mathf.Abs(agent.remainingDistance) < 0.01f)
            animator.SetBool("Iswalking", false);
        else
            animator.SetBool("Iswalking", true);
    }
}
