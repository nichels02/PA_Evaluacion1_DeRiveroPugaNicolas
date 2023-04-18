using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class area : MonoBehaviour
{
    GameObject jugador;
    [SerializeField] GameObject enemigo;
    [SerializeField] GameObject ubicacion;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        enemigo2 elenemigo2 = enemigo.GetComponent<enemigo2>();
        if (jugador == null)
        {
            elenemigo2.irUbicacion(ubicacion);
        }
        else
        {
            elenemigo2.seguir(jugador);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "jugador")
        {
            jugador=collision.gameObject;
            Debug.Log("1");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "jugador")
        {
            jugador = null;
            Debug.Log("2");
        }
    }
}



