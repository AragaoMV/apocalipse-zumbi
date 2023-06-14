using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlaUI : MonoBehaviour
{
    private ControlaJogador scriptControlaJogador;
    public Slider BarraDeVidaJogador;
    void Start()
    {
        scriptControlaJogador = GameObject.FindWithTag("Player").GetComponent<ControlaJogador>();
        BarraDeVidaJogador.maxValue = scriptControlaJogador.StatusJogador.Vida;
        AtualizaBarraDeVida();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void AtualizaBarraDeVida()
    {
        BarraDeVidaJogador.value = scriptControlaJogador.StatusJogador.Vida;
    }
}
