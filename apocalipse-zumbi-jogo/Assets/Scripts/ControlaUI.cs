using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ControlaUI : MonoBehaviour
{
    private ControlaJogador scriptControlaJogador;
    public Slider BarraDeVidaJogador;
    public GameObject TelaGameOver;
    public Text TimerText;
    public Text TextRecordTime;
    private float salvaTempoMaximo;
    void Start()
    {
        scriptControlaJogador = GameObject.FindWithTag("Player").GetComponent<ControlaJogador>();
        BarraDeVidaJogador.maxValue = scriptControlaJogador.StatusJogador.Vida;
        AtualizaBarraDeVida();
        Time.timeScale = 1;
        salvaTempoMaximo = PlayerPrefs.GetFloat("PontuacaoMaxima");

    }
    public void AtualizaBarraDeVida()
    {
        BarraDeVidaJogador.value = scriptControlaJogador.StatusJogador.Vida;
    }
    public void Reiniciar()
    {
        SceneManager.LoadScene("game");
    }
    public void GamerOver()
    {
        Time.timeScale = 0;
        TelaGameOver.SetActive(true);
        int minutos = (int)(Time.timeSinceLevelLoad / 60);
        int segundos = (int)(Time.timeSinceLevelLoad % 60);
        TimerText.text = "Tempo de Sobrevivência:      " + minutos + " minutos e " + segundos + "segundos";

        SetTempoMaximo(minutos, segundos);

    }
    void SetTempoMaximo(int min, int seg)
    {
        if (Time.timeSinceLevelLoad > salvaTempoMaximo)
        {
            salvaTempoMaximo = Time.timeSinceLevelLoad;
            TextRecordTime.text = string.Format("Tempo Record:{0} minutos e {1}segundos.", min, seg);

            PlayerPrefs.SetFloat("PontuacaoMaxima", salvaTempoMaximo);
        }
        if (TextRecordTime.text == "")
        {
            min = (int)salvaTempoMaximo / 60;
            seg = (int)salvaTempoMaximo % 60;
            TextRecordTime.text = string.Format("Tempo Record:{0} minutos e {1}segundos.", min, seg);
        }
    }
}
