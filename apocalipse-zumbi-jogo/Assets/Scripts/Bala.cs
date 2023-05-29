using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour

{
    private Rigidbody rigidbodyBala;
    public float Velocidade = 20;
    void Start() {
       rigidbodyBala = GetComponent<Rigidbody>();
    }
    private void FixedUpdate() {
        rigidbodyBala.MovePosition(
            rigidbodyBala.position + transform.forward * Velocidade * Time.deltaTime
            );
    }
    void OnTriggerEnter(Collider objetoDeColisao) {
        if (objetoDeColisao.tag == "Inimigo")
        {
          Destroy(objetoDeColisao.gameObject);  
        }
        Destroy(gameObject);
        
    }
}
