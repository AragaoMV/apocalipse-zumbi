using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorZumbis : MonoBehaviour
{
    public GameObject Zumbi;
    float contaTempo = 0;
    public float TempoGeraZumbi = 1;
    public LayerMask LayerZumbi;
    private float rangeDeGeracao = 5;
    private float distanciaJogadorInimigo = 20;
    private GameObject jogador;

    private void Start()
    {
        jogador = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        if (Vector3.Distance(transform.position, jogador.transform.position) > distanciaJogadorInimigo)
        {
            contaTempo += Time.deltaTime;
            if (contaTempo >= TempoGeraZumbi)
            {
                StartCoroutine(GeraZumbi());
                contaTempo = 0;
            }
        }
    }
    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, rangeDeGeracao);
    }
    IEnumerator GeraZumbi()
    {
        Vector3 novoSpawn = AleatorizaSpawn();
        Collider[] colisores = Physics.OverlapSphere(novoSpawn, 1, LayerZumbi);
        while (colisores.Length > 0)
        {
            novoSpawn = AleatorizaSpawn();
            colisores = Physics.OverlapSphere(novoSpawn, 1, LayerZumbi);
            yield return null;
        }
        Instantiate(Zumbi, novoSpawn, transform.rotation);
    }
    Vector3 AleatorizaSpawn()
    {
        Vector3 posicao = Random.insideUnitSphere * rangeDeGeracao;
        posicao += transform.position;
        posicao.y = 0;

        return posicao;
    }
}
