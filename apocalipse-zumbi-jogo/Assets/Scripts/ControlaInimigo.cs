using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaInimigo : MonoBehaviour, IMatavel
{
    public GameObject Jogador;
    private MovimentaPersonagem movimentoZumbi;
    private AnimacaoPersonagem animacaoZumbi;
    private Status statusZumbi;
    public AudioClip DanoZumbi;
    void Start()
    {
        Jogador = GameObject.FindWithTag("Player");
        GeraSkin();
        movimentoZumbi = GetComponent<MovimentaPersonagem>();
        animacaoZumbi = GetComponent<AnimacaoPersonagem>();
        statusZumbi = GetComponent<Status>();
    }
    void GeraSkin()
    {
        int geraSkinZumbi = Random.Range(1, 27);
        transform.GetChild(geraSkinZumbi).gameObject.SetActive(true);
    }
    void FixedUpdate()
    {
        float distancia = Vector3.Distance(transform.position, Jogador.transform.position);
        Vector3 direcao = Jogador.transform.position - transform.position;
        movimentoZumbi.Rotacao(direcao);

        if (distancia > 2.5)
        {
            movimentoZumbi.Movimento(direcao, statusZumbi.Velocidade);
            animacaoZumbi.Atacar(false);
        }
        else
        {
            animacaoZumbi.Atacar(true);
        }
    }
    void AtacaJogador()
    {
        int dano = Random.Range(20, 30);
        Jogador.GetComponent<ControlaJogador>().TomarDano(dano);

    }

    public void TomarDano(int dano)
    {
        statusZumbi.Vida -= dano;
        if (statusZumbi.Vida <= 0)
        {
            Morrer();
        }
    }
    public void Morrer()
    {
        Destroy(gameObject);
        ControlaAudio.instacia.PlayOneShot(DanoZumbi);
    }
}
