using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeradorZumbis : MonoBehaviour
{
    public GameObject Zumbi;
    float contaTempo = 0;
    public float TempoGeraZumbi = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        contaTempo += Time.deltaTime;
        if (contaTempo>= TempoGeraZumbi)
        {
            Instantiate(Zumbi, transform.position, transform.rotation); 
            contaTempo = 0;
        }       
        
    }
}
