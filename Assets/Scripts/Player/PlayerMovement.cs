using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class PlayerMovement : MonoBehaviour
{
    NavMeshAgent agent;
    Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = transform.Find("doctor").GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }

    private void Update()
    {
        if(Mathf.Abs(agent.remainingDistance) < 0.001f)
            animator.SetBool("Iswalking", false);
        else
            animator.SetBool("Iswalking", true);
    }
}
