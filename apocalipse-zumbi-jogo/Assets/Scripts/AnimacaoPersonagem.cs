using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimacaoPersonagem : MonoBehaviour
{
    private Animator animacao;

    void Awake()
    {
        animacao = GetComponent<Animator>();
    }
    public void Atacar(bool state)
    {
        animacao.SetBool("Atacando", state);
    }

    public void Movimentar(float valorMovimento)
    {
        animacao.SetFloat("Movendo", valorMovimento);
    }
}
