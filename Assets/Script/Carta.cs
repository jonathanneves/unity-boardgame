using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Carta Nova", menuName = "Carta")]
public class Carta : ScriptableObject 
{
    public int numero;
    public string questao;
    public string[] alternativas;
    public int resposta;
    public bool ehQuestao = true;
    public Sprite imagem = null;
}
