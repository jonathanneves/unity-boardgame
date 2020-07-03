using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{   
    public List<Carta> cartas = new List<Carta>();
    List<Carta> listaAux = new List<Carta>();
    private Carta card;

    [Header("UI")]
    public GameObject tabuleiro;
    public GameObject winScreen;
    public Text scoreTxt;
   
    [Space(2)]
    [Header("Card Sorte ou Azar")]
    public TMP_Text txtTitleSorteAzar;
    public TMP_Text txtCarta;
    public GameObject panelSorteAzar;
    public Image figura;
    
    [Space(2)]
    [Header("Card Questão")]
    public GameObject panelQuestao;
    public TMP_Text txtTitleQuestao;
    public TMP_Text txtPergunta;
    public Button button1;
    public Button button2;
    public Button button3;
 
    private bool startGame = true;
    public float timeWaitByCard = 1f;
    int acertos, erros = 0;

    void Awake(){
        tabuleiro.SetActive(false);
        winScreen.SetActive(false);
        Shuffle(cartas);
    }

    void visualizarCarta(){
        AudioManager.instance.trocarCarta();
       
        if(cartas.Count == 0)
            embaralhar();
    
        card = pop(cartas);
        Debug.Log(card);
        if(card.ehQuestao)
            habilitarQuestao();
        else
            habilitarSorteAzar();
    }

    void habilitarQuestao(){
        txtTitleQuestao.text = card.name;
        txtPergunta.text = card.questao;
        button1.transform.GetChild(0).GetComponent<TMP_Text>().text = card.alternativas[0];
        button2.transform.GetChild(0).GetComponent<TMP_Text>().text = card.alternativas[1];
        if (card.alternativas.Length == 3)
            button3.transform.GetChild(0).GetComponent<TMP_Text>().text = card.alternativas[2];
        else{
            button3.GetComponent<Image>().enabled = false;
            button3.transform.GetChild(0).GetComponent<TMP_Text>().text = "";
        }
        panelQuestao.SetActive(true);
    }

    void habilitarSorteAzar(){
        txtTitleSorteAzar.text = card.name;
        txtCarta.text = card.questao;
        figura.sprite = card.imagem;
        panelSorteAzar.SetActive(true);
    }

    public void verificarResposta(int alternativa){
        int resposta = card.resposta;
        if (resposta == alternativa || resposta == 5 ) {
            Debug.Log("<color=green>Você Acertou!</color>");
            AudioManager.instance.tocarRespostaCorreta();
            acertos++;
            Jogador.proximaCasa();
        } else {
            Debug.Log("<color=red>Você Errou!</color>");
            AudioManager.instance.tocarRespostaErrada();
            erros++;
            Jogador.voltarCasa();
        }
        button3.GetComponent<Image>().enabled = true;
        StartCoroutine("proximaCarta");
    }

    public void verificarSorteAzar(){
        if(card.resposta > 0)
            AudioManager.instance.tocarRespostaCorreta();
        else
             AudioManager.instance.tocarRespostaErrada();
        Jogador.moverNumeroDeCasas(card.resposta);
        StartCoroutine("proximaCarta");
    }

    public void hoverColor(int color){
        this.GetComponent<SpriteChange>().atualizarPanel(color);
    }

    public void setColor(int color){
        this.GetComponent<SpriteChange>().atualizarSprites(color);
        StartCoroutine("proximaCarta");
    }

    public IEnumerator proximaCarta(){
        if(startGame){
            tabuleiro.SetActive(true);
            yield return new WaitForSeconds(timeWaitByCard*2f);
            startGame = false;
        } else {
            yield return new WaitForSeconds(timeWaitByCard);     
        }
        if(Jogador.voceVenceu)
            ativarVitoria();
        else 
            visualizarCarta();
    }

    public void sairDoJogo(){
       Application.Quit(0);
    }

    public void jogarNovamente(){
        winScreen.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void ativarVitoria(){
        scoreTxt.text = "Acertos: " + acertos + " | Erros: "+ erros;
        AudioManager.instance.tocarVitoria();
        winScreen.SetActive(true);
    }

    public void embaralhar(){
        Shuffle(listaAux);
        foreach(Carta carta in listaAux){
            cartas.Add(carta);
        }
        listaAux.Clear();
    }

    public void Shuffle(List<Carta> ts) {
        var count = ts.Count;
        var last = count - 1;
        for (var i = 0; i < last; ++i) {
            var r = Random.Range(i, count);
            var tmp = ts[i];
            ts[i] = ts[r];
            ts[r] = tmp;
        }
    }

    public Carta pop(List<Carta> ts) {
        Carta carta = cartas[cartas.Count-1];
        listaAux.Add(carta);
        cartas.Remove(carta);
        return carta;
    }
}
