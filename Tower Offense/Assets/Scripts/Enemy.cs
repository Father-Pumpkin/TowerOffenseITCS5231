using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    private Animator m_animator;

    [Header("Combat")]
    public Transform headTransform;
    public Transform aimTargetTransform;
    public PointOfInterest pointOfInterest;
    public float flashTime = .5f;
    PointOfInterest player;

    [Tooltip("Range The Enemy Will Look At Player")]
    public float perception = 5f;
    [Tooltip("Range The Enemy Will Attack Player")]
    public float awareness = 3f;

    public float lerpSpeed = 10f;
    public Vector3 origin;
    


    //Gravity things
    [Header("Gravity")]
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    Vector3 velocity;
    bool isGrounded;
    
    Vector3 targetPosition;
    private void Start()
    {
        origin = aimTargetTransform.position;
        m_animator = GetComponentInChildren<Animator>();

    }

    private void Update()
    {
        Collider[] cols = Physics.OverlapSphere(headTransform.position + transform.forward, perception);
        Collider[] awarenessCols = Physics.OverlapSphere(transform.position, awareness);

        pointOfInterest = null;
        foreach(Collider col in awarenessCols)
        {
            if (col.GetComponent<PointOfInterest>())
            {
                pointOfInterest = col.GetComponent<PointOfInterest>();
                break;
            }
        }
        foreach (Collider col in cols)
        {
            if (col.GetComponent<PointOfInterest>())
            {
                player = col.GetComponent<PointOfInterest>();
                break;
            }
        }
        Vector3 targetMovePosition;
        float speed = lerpSpeed / 10;
        if(pointOfInterest != null)
        {
            targetPosition = pointOfInterest.GetLookTarget().position;
            if(player != null)
            {
                targetMovePosition = player.GetLookTarget().position;
                targetPosition.y = this.transform.position.y;
                m_animator.SetTrigger("Walk");
                targetMovePosition.y = this.transform.position.y;
                this.transform.position = Vector3.Lerp(this.transform.position, targetMovePosition, Time.deltaTime * speed);
                transform.rotation = Quaternion.LookRotation(targetPosition - this.transform.position);
            }
            this.headTransform.rotation = Quaternion.LookRotation(targetPosition - this.headTransform.position);
        }
            
        aimTargetTransform.position = Vector3.Lerp(aimTargetTransform.position, targetPosition, Time.deltaTime * speed);
        
        //check a circle around groundCheck with radius groundDistance Checking against things in groundMask
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // gravity
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y += gravity * Time.deltaTime;
    }
    private void FixedUpdate()
    {
        /* For drawing forward vector
        LineRenderer lineRenderer = this.GetComponent<LineRenderer>();
        lineRenderer.SetVertexCount(2);
        lineRenderer.SetPosition(0, transform.position);
        lineRenderer.SetPosition(1, transform.forward * 20 + transform.position);
        Debug.DrawRay(transform.position, transform.forward * 10, Color.red, 0);
        */
    }

    void Die()
    {
        m_animator.SetTrigger("Die");
    }


    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(this.transform.position, perception);
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(this.transform.position, awareness);
    }
}
