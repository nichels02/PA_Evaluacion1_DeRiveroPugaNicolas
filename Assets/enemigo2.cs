using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemigo2 : MonoBehaviour
{
    
    [SerializeField] GameObject jugador;
    [SerializeField] float velocidad=2;
    [SerializeField] Transform mytransform;
    [SerializeField] Rigidbody2D elrigidbody2D;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void seguir(GameObject jugador)
    {
        elrigidbody2D.velocity = (jugador.transform.position - mytransform.position).normalized * velocidad;
    }
    public void irUbicacion(GameObject ubicacion)
    {
        elrigidbody2D.velocity = (ubicacion.transform.position - mytransform.position).normalized * velocidad;
    }
}
