using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour

{
    private Rigidbody rigidbodyBala;
    public float Velocidade = 20;
    public AudioClip DanoZumbi;
    private int danoTiro = 1;
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
          objetoDeColisao.GetComponent<ControlaInimigo>().TomarDano(danoTiro);
        }
        Destroy(gameObject);
        
    }
}
