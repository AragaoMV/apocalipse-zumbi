using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour
{
    public GameObject Jogador;
    public float Velocidade = 5;
    private Rigidbody rigidbodyZumbi;
    private Animator animatorZumbi;
    void Start()
    {
        rigidbodyZumbi = GetComponent<Rigidbody>();
        animatorZumbi = GetComponent<Animator>();
        Jogador = GameObject.FindWithTag("Player");
        int geraSkinZumbi = Random.Range(1, 27);
        transform.GetChild(geraSkinZumbi).gameObject.SetActive(true);
    }
    void Update()
    {

    }

    void FixedUpdate()
    {
        float distancia = Vector3.Distance(transform.position, Jogador.transform.position);
        Vector3 direcao = Jogador.transform.position - transform.position;
        Quaternion novaRotacao = Quaternion.LookRotation(direcao);
        rigidbodyZumbi.MoveRotation(novaRotacao);

        if (distancia > 2.5)
        {
            animatorZumbi.SetBool("Atacando", false);
            rigidbodyZumbi.MovePosition(
            rigidbodyZumbi.position + direcao.normalized * (Velocidade * Time.deltaTime)
        );

        }
        else
        {
            animatorZumbi.SetBool("Atacando", true);
        }

    }

    void AtacaJogador()
    {
        int dano = Random.Range(20, 30);
        Jogador.GetComponent<ControlaJogador>().TomarDano(dano);

    }

}
