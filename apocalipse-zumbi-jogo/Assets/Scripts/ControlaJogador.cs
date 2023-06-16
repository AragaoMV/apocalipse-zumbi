using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlaJogador : MonoBehaviour, IMatavel
{

    Vector3 direcao;
    public LayerMask MascaraChao;
    public GameObject TextoGameOver;
    public ControlaUI ScriptContolaInterface;
    public AudioClip SomDeDano;
    private MovimentaJogador controleJogador;
    private AnimacaoPersonagem animacaoJogador;
    public Status StatusJogador;

    void Start()
    {
        controleJogador = GetComponent<MovimentaJogador>();
        animacaoJogador = GetComponent<AnimacaoPersonagem>();
        StatusJogador = GetComponent<Status>();
    }
    void Update()
    {
        float eixoX = Input.GetAxis("Horizontal");
        float eixoZ = Input.GetAxis("Vertical");

        direcao = new Vector3(eixoX, 0, eixoZ);

        animacaoJogador.Movimentar(direcao.magnitude);


    }
    void FixedUpdate()
    {
        controleJogador.Movimento(direcao, StatusJogador.Velocidade);
        controleJogador.MiraJogador(MascaraChao);

    }
    public void TomarDano(int dano)
    {
        StatusJogador.Vida -= dano;
        ScriptContolaInterface.AtualizaBarraDeVida();
        ControlaAudio.instacia.PlayOneShot(SomDeDano);

        if (StatusJogador.Vida <= 0)
        {
            Morrer();
        }

    }
    public void Morrer()
    {
        ScriptContolaInterface.GamerOver();
    }
}
