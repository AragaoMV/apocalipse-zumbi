using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentaPersonagem : MonoBehaviour
{
    private Rigidbody setRigidbody;

    void Awake()
    {
        setRigidbody = GetComponent<Rigidbody>();
    }
    public void Movimento(Vector3 direcao, float velocidade)
    {
        setRigidbody.MovePosition(
            setRigidbody.position + direcao.normalized * (velocidade * Time.deltaTime)
        );
    }
    public void Rotacao(Vector3 direcao)
    {
        Quaternion novaRotacao = Quaternion.LookRotation(direcao);
        setRigidbody.MoveRotation(novaRotacao);
    }
}

