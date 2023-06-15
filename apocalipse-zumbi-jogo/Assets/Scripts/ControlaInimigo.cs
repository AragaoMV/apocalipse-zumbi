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
    private Vector3 posicaoAleatoria;
    private Vector3 direcao;
    private float contadorVagar;
    private float tempoEntrePosicaoAleatoria = 4;



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
        movimentoZumbi.Rotacao(direcao);
        animacaoZumbi.Movimentar(direcao.magnitude);

        if (distancia > 15)
        {
            Vagar();
        }
        else if (distancia > 2.5)
        {
            direcao = Jogador.transform.position - transform.position;
            movimentoZumbi.Movimento(direcao, statusZumbi.Velocidade);
            animacaoZumbi.Atacar(false);
        }
        else
        {
            animacaoZumbi.Atacar(true);
        }
    }

    void Vagar()
    {

        contadorVagar -= Time.deltaTime;
        if (contadorVagar <= 0)
        {
            posicaoAleatoria = AleatoriazarPosicao();
            contadorVagar += tempoEntrePosicaoAleatoria; 
        }

        bool menorDistancia = Vector3.Distance(transform.position, posicaoAleatoria) <=0.5;

        if (menorDistancia == false)
        {
            direcao = posicaoAleatoria - transform.position;
            movimentoZumbi.Movimento(direcao, statusZumbi.Velocidade);
        }
    }
    Vector3 AleatoriazarPosicao()
    {
        Vector3 posicao = Random.insideUnitSphere * 10;
        posicao += transform.position;
        posicao.y = transform.position.y;

        return posicao;
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
