using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRBD2;
    [SerializeField] private float velocityModifier = 5f;
    [SerializeField] private float rayDistance = 10f;
    [SerializeField] private float velocidadBala = 10f;
    [SerializeField] private AnimatorController animatorController;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject bala;

    private void Update() {
        Vector2 movementPlayer = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        myRBD2.velocity = movementPlayer * velocityModifier;

        animatorController.SetVelocity(velocityCharacter: myRBD2.velocity.magnitude);

        Vector2 mouseInput = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        CheckFlip(mouseInput.x);
    
        Debug.DrawRay(transform.position, mouseInput.normalized * rayDistance, Color.red);

        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("Right Click");
            /*
            GameObject labala = Instantiate(bala, transform.position, Quaternion.identity);

            Vector2 direccionbala = (mouseInput-transform.position)
            */
            GameObject labala = Instantiate(bala, transform.position, Quaternion.identity);
            Rigidbody2D lbala = labala.GetComponent<Rigidbody2D>();
            lbala.velocity = mouseInput * velocidadBala;

        }
        else if(Input.GetMouseButtonDown(1))
        {
            Debug.Log("Left Click");
            GameObject labala = Instantiate(bala, transform.position, Quaternion.identity);
            Rigidbody2D lbala = labala.GetComponent<Rigidbody2D>();
            lbala.velocity = mouseInput * velocidadBala;
        }
    }

    private void CheckFlip(float x_Position){
        spriteRenderer.flipX = (x_Position - transform.position.x) < 0;
    }
}
