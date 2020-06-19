using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    public GameObject tabuleiro;
    private Transform[] casas;
    [HideInInspector] public static int casaAtual;
    private int ultimaCasa;
    private static bool podeMover = false;
    public static bool podeContinuar = false;
    public static bool voceVenceu = false;
    public float speed = 2f;

    void Awake()
    {
        ultimaCasa = tabuleiro.transform.childCount;
        Debug.Log("Max:"+ultimaCasa);
        casas = new Transform[ultimaCasa];
        for (int i = 0; i < ultimaCasa; ++i) {
            casas[i] = tabuleiro.transform.GetChild(i);
        }
    }

    void Update()
    {
        if(podeMover){
            moverPlayer();
        }
    }

    public static void proximaCasa(){
        Debug.Log("Avança Casa");
        casaAtual++;
        podeMover = true;
    }

    public static void voltarCasa(){
        Debug.Log("Volta Casa");
        if(casaAtual > 0){
            casaAtual--;
            podeMover = true;
        }
    }

    public static void moverNumeroDeCasas(int casas){
        podeContinuar = false;
        Debug.Log("SorteAzar" + casas);
        int index = casas > 0 ? casas : -casas; 
        for(int i=0; i<index;i++){
            if(casas > 0)
                proximaCasa();
            else if(casas < 0)
                voltarCasa();               
        }
        podeContinuar = true;
    }
    
    void moverPlayer(){       
        Vector3 target = casas[casaAtual+1].position;
        target = new Vector3(target.x, target.y, -2f);
        if(Vector2.Distance(this.transform.position, target) >= 0f){
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        } else {
            podeMover = false;
        }
        if(casaAtual == ultimaCasa - 1) 
            voceVenceu = true;     
    }
}
