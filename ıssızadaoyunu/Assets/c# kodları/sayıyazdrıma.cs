using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class sayıyazdrıma : MonoBehaviour
{
  public TextMeshProUGUI coinyazısı;
 public TextMeshProUGUI keyyazısı;
 public TextMeshProUGUI levelyazı;
public TextMeshProUGUI levelbuttonyazı;
public int coinsayısı=0;
public int keysayısı=0;
public int levelno;
public int levelyzıno;
public int levelbuttonyzıno;




public void coinfonk(){
    coinsayısı++;
    coinyazısı.text="Coin : " + coinsayısı;
}
public void keyfonk(){
    keysayısı++;
     keyyazısı.text="Key : " + keysayısı;


}

public void succespanel(){
    levelbuttonyzıno = PlayerPrefs.GetInt("levelbuttonyzıno",0);
    levelbuttonyazı.text="Evren  " + (levelbuttonyzıno+2);
    PlayerPrefs.SetInt("levelbuttonyzıno",levelbuttonyzıno+1);
}
   public void Nextlevel(){
levelno = PlayerPrefs.GetInt("levelno",0);
SceneManager.LoadScene(levelno+1);
    PlayerPrefs.SetInt("levelno",levelno + 1);

     
    }
    public void evrencollection(){
    levelyzıno = PlayerPrefs.GetInt("levelyzıno",0);
    levelyazı.text="Evren : " + (levelyzıno+1);
    PlayerPrefs.SetInt("levelyzıno",levelyzıno+1);


}
public void dead(){

SceneManager.LoadScene("1");
  PlayerPrefs.DeleteAll();
    
    
    }

}
