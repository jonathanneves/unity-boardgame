using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening; 

public class UIManager : MonoBehaviour
{
   public float duration;
   public float delay;
   public float scale = 1f;

   public void OnEnable() {
      this.transform.localScale = new Vector3(0,0,0);
      this.transform.DOScale(new Vector3(scale,scale,scale), duration).SetDelay(delay);
   }

   public void OnClose(){
      this.transform.DOScale(new Vector3(0,0,0), duration).OnComplete(DisableMe);
   }

   void DisableMe(){
      this.transform.parent.gameObject.SetActive(false);
   }
}
