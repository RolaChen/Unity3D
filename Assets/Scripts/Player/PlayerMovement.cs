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
        Debug.Log(PlayerData.instance.E_career);
        animator = transform.Find(PlayerData.instance.E_career+"(Clone)").GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    public void MoveToPoint(Vector3 point)
    {
        agent.SetDestination(point);
    }

    private void Update()
    {
        if(Mathf.Abs(agent.remainingDistance) < 0.01f)
            animator.SetBool("Iswalking", false);
        else
            animator.SetBool("Iswalking", true);
    }
}
