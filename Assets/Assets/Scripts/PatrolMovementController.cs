using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolMovementController : MonoBehaviour
{
    [SerializeField] private Transform[] checkpointsPatrol;
    [SerializeField] private Transform transformMy;
    [SerializeField] private Rigidbody2D myRBD2;
    [SerializeField] private AnimatorController animatorController;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float velocityModifier = 5f;
    private Transform currentPositionTarget;
    private int patrolPos = 0;
    RaycastHit2D ray;

    [SerializeField] private float distanciaRay = 2;
    [SerializeField] private LayerMask LayerRay;

    private void Start() {
        currentPositionTarget = checkpointsPatrol[patrolPos];
        transform.position = currentPositionTarget.position;
    }

    private void Update() 
    {

        //
        ray = Physics2D.Raycast(transform.position, myRBD2.velocity.normalized, distanciaRay, LayerRay);
        Debug.DrawRay(transform.position, myRBD2.velocity.normalized * distanciaRay, Color.red);
        CheckNewPoint();
        animatorController.SetVelocity(velocityCharacter: myRBD2.velocity.magnitude);
        if (ray.collider == null)
        {
            myRBD2.velocity = (currentPositionTarget.position - transform.position).normalized * velocityModifier;
        }
        else
        {
            myRBD2.velocity = (currentPositionTarget.position - transform.position).normalized * velocityModifier * 2;
        }
    }

    private void CheckNewPoint(){
        if(Mathf.Abs((transform.position - currentPositionTarget.position).magnitude) < 0.25)
        {
            patrolPos = patrolPos + 1 == checkpointsPatrol.Length? 0: patrolPos+1;
            currentPositionTarget = checkpointsPatrol[patrolPos];
            myRBD2.velocity = (currentPositionTarget.position - transform.position).normalized * velocityModifier;
            

            CheckFlip(myRBD2.velocity.x);
        }
        
    }

    private void CheckFlip(float x_Position){
        spriteRenderer.flipX = (x_Position - transform.position.x) < 0;
    }
}
