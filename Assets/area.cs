using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class area : MonoBehaviour
{
    GameObject jugador;
    [SerializeField] GameObject enemigo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (jugador == null)
        {
            
        }
        else
        {
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("1");
        if (collision.gameObject.tag == "jugador")
        {
            jugador = collision.gameObject;
            Debug.Log("2");
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        //Debug.Log("3");
        if (collision.gameObject.tag == "jugador")
        {
            jugador = null;
            Debug.Log("4");
        }
    }
}
