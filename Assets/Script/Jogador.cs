using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogador : MonoBehaviour
{
    public GameObject tabuleiro;
    private Transform[] casas;
    [HideInInspector] public static int casaAtual;
    private static int ultimaCasa;
    public static bool podeMover = false;
    public static bool voceVenceu = false;
    public float speed = 2f;
    static int numeroDeCasasParaMover = 0;


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
        #region DEBUG
        /*if(Input.GetKeyDown(KeyCode.X)){
            moverNumeroDeCasas(2);
            numeroDeCasasParaAvancar = 1;
            proximaCasa();
        }
        if(Input.GetKeyDown(KeyCode.Z)){
            //moverNumeroDeCasas(-2);
            numeroDeCasasParaAvancar = -2;
            voltarCasa();
        }*/
        #endregion

        if(podeMover){
            moverPlayer();
        }
    }

    public static void proximaCasa(){
        Debug.Log("Avança Casa");
        if(casaAtual < ultimaCasa-1){
            casaAtual++;
            podeMover = true;
        }
    }

    public static void voltarCasa(){
        Debug.Log("Volta Casa");
        if(casaAtual > 0){
            casaAtual--;
            podeMover = true;
        }
    }

    public static void moverNumeroDeCasas(int casas){
        numeroDeCasasParaMover = casas;  
        if(casas > 0)
            proximaCasa();
        else if(casas < 0)
            voltarCasa(); 
        /*for(int i=0; i<index;i++){
            while(!podeMover){
                if(casas > 0)
                    proximaCasa();
                else if(casas < 0)
                    voltarCasa(); 
            }
        }*/
    }
    
    void moverPlayer(){             
        Vector3 target = casas[casaAtual].position;
        target = new Vector3(target.x, target.y, -2f);
        if(Vector2.Distance(this.transform.position, target) >= 0.01f){
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        } else if(numeroDeCasasParaMover != 0) {
            numeroDeCasasParaMover += numeroDeCasasParaMover > 0 ? -1 : +1;
            moverNumeroDeCasas(numeroDeCasasParaMover);
        } else {      
            podeMover = false;
        }
        if(casaAtual >= (ultimaCasa - 1)) {
            voceVenceu = true;
        }
    }
}
