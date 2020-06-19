using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpriteChange : MonoBehaviour
{
    [Header("Config.")]
    public SpriteRenderer playerSprite;
    public Image[] panel;   
    public Image[] button;

    public Color[] colors;
    private int currentColor; 

    [Header("UI")]
    public Sprite[] panelList;

    public void atualizarSprites(int escolha){
        panel[0].sprite = panelList[escolha];
        panel[1].sprite = panelList[escolha];
        panel[2].sprite = panelList[escolha];
        panel[3].sprite = panelList[escolha];
        button[0].color = colors[escolha];
        button[1].color = colors[escolha];
        button[2].color = colors[escolha];
        button[3].color = colors[escolha];
        button[4].color = colors[escolha];
        button[5].color = colors[escolha];
        playerSprite.color = colors[escolha];
    }

    public void atualizarPanel(int escolha){
        panel[0].sprite = panelList[escolha];
    }
}
