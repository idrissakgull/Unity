using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class elmassayısı : MonoBehaviour
{
public TextMeshProUGUI elmasskoryazı;
public TextMeshProUGUI engelçyazı;
public TextMeshProUGUI levelyazı;
public TextMeshProUGUI levelbuttonyazı;
public int elmassayisi=0;
public int engeleçsayisi=0;
public int levelno;
public int levelyzıno;
public int levelbuttonyzıno;


public void elmascollection(){
    elmassayisi++;
    elmasskoryazı.text="Coin : " + elmassayisi;
}
public void engelcollection(){
    engeleçsayisi++;
    engelçyazı.text="Error : " + engeleçsayisi;

}
public void levelcollection(){
    levelyzıno = PlayerPrefs.GetInt("levelyzıno",0);
    levelyazı.text="Level : " + (levelyzıno+1);
    PlayerPrefs.SetInt("levelyzıno",levelyzıno+1);


}
public void succespanel(){
    levelbuttonyzıno = PlayerPrefs.GetInt("levelbuttonyzıno",0);
    levelbuttonyazı.text="LEVEL " + (levelbuttonyzıno+2);
    PlayerPrefs.SetInt("levelbuttonyzıno",levelbuttonyzıno+1);
}



public void Nextlevel(){
levelno = PlayerPrefs.GetInt("levelno",0);
SceneManager.LoadScene(levelno+1);
    PlayerPrefs.SetInt("levelno",levelno + 1);

     
    }
public void dead(){

SceneManager.LoadScene("1");
  PlayerPrefs.DeleteAll();
    
    
    }


}
