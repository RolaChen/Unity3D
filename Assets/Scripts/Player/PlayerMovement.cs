using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

//[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = transform.parent.GetComponent<NavMeshAgent>();
        
    }

    public void MoveToPoint(Vector3 point)
    {         
        agent.SetDestination(point);
    }

    public void born(Vector3 vector)
    {
        agent.Warp(vector);
    }

    private void Update()
    {
        if (Mathf.Abs(agent.remainingDistance) < 0.01f)
            animator.SetBool("Iswalking", false);
        else
            animator.SetBool("Iswalking", true);
    }
}
