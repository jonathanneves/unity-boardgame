using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening; 

public class ColorPanelManager : MonoBehaviour
{
   public void OnEnable() {
      this.transform.localScale = new Vector3(0,0,0);
      this.transform.DOScale(new Vector3(1,1,1), 0.75f);
   }

   public void OnClose(){
      this.transform.DOScale(new Vector3(0,0,0), 1f).OnComplete(DestroyMe);
   }

   void DestroyMe(){
      Destroy(gameObject.transform.parent.gameObject);
   }
}
