using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerAnimation : MonoBehaviour
{
    private NavMeshAgent agent;
    public float rotationSpeed = 10f;
    public Animator anim;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (agent == null)
        {
            Debug.LogError("NavMeshAgent component not found! Please add a NavMeshAgent component to this GameObject.");
            return;
        }
        
        // Auto-assign Animator if not assigned in Inspector
        if (anim == null)
        {
            anim = GetComponent<Animator>();
            if (anim == null)
            {
                Debug.LogWarning("Animator component not found. Animation features will be disabled.");
            }
        }
        
        // Additional safety check
        if (!agent.isOnNavMesh)
        {
            Debug.LogWarning("NavMeshAgent is not on a NavMesh. Make sure the NavMesh is baked and the object is positioned correctly.");
        }
    }
    
    public void MovetoPoint(Vector3 point)
    {
        if (agent != null && agent.isActiveAndEnabled && agent.isOnNavMesh)
        {
            // NavMesh will automatically find a path around obstacles
            NavMeshHit hit;
            if (NavMesh.SamplePosition(point, out hit, 5.0f, NavMesh.AllAreas))
            {
                agent.SetDestination(hit.position);
                
            }
            else
            {
                Debug.LogWarning("Cannot find valid NavMesh position near the clicked point!");
            }
        }
        else
        {
            Debug.LogError("NavMeshAgent is not ready or not on NavMesh! Make sure NavMesh is baked.");
        }
    }
    
    void Update()
    {
        // Handle animations
        if (anim != null && agent != null && agent.isActiveAndEnabled)
        {
            bool isMoving = agent.velocity.magnitude > 0.1f;
            anim.SetBool("isWalk", isMoving);
        }

        // Optional: Add custom rotation behavior
        if (agent != null && agent.hasPath && agent.velocity.magnitude > 0.1f)
        {
            Vector3 direction = agent.velocity.normalized;
            if (direction != Vector3.zero)
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
            }
        }
    }
}
