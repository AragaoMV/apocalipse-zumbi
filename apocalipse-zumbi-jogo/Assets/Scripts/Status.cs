using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Status : MonoBehaviour
{
    public int VidaBase = 100;
    [HideInInspector] public int Vida;
   public float Velocidade = 10;

 void Start() {
    Vida = VidaBase;
}
}
