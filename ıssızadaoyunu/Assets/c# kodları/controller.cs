using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;


public class controller : MonoBehaviour
{
 public float hız;
 public float solsağhızı;
 public float dönmehızı;
 public bool isrunning=false;
  public Animator Animator;
   public sayıyazdrıma sayıyazdırmacs;
   public RectTransform panel;
   public RectTransform panel2;
   public float dakika,saniye;
   public Text ölümsüresi;
   public AudioSource ses;
   

private void Start() {
     sayıyazdırmacs.evrencollection();
      Invoke("deadanimasyon", 146f);
     Invoke("ölümyakındır", 150f);
     dakika=2;
     saniye=30;
       AudioSource ses = gameObject.GetComponent<AudioSource>();
  
 
}

 private void Update()
 {
    saniye -=Time.deltaTime;
   ölümsüresi.text="Ölüm'e"+" "+"0"+dakika+":"+(int)saniye+" "+"Kaldı";

   if(saniye<=0) {
        dakika--;
       saniye=59;
   }
   if(dakika==0 && saniye==0) {
     ölümsüresi.text="Ölüm'e"+" "+"00"+":"+"00"+" "+"Kaldı";
   }
    if(isrunning == true ){
transform.position += transform.forward * hız * Time.deltaTime;
    }

if(Input.GetKeyDown("up"))
{     
        startrunning();
}
if(Input.GetKeyUp("up"))
{
        stoprunning();
}
if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
{
  
 transform.Rotate(Vector3.down);//dönderme sola
    
}
if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
{
 transform.Rotate(Vector3.up);//dönderme sağa
 
  
}
  if (Input.GetMouseButtonDown(0))
        {
            Animator.SetTrigger("bokstrigger");
        }
 }

private void startrunning(){
isrunning = true;
Animator.SetTrigger("runtrigger");

}

private void stoprunning() {
    isrunning = false;
Animator.SetTrigger("stoptrigger");
}
void OnTriggerEnter(Collider other)
{
if (other.CompareTag("dağ"))

    {
       
       
         
        float z = transform.position.z - 4F;

 transform.DOJump(new Vector3(transform.position.x, transform.position.y, z),1F,1,0.5F);
       
    }
    if (other.CompareTag("coin"))

    {
         sayıyazdırmacs.coinfonk();
  other.transform.DOScale(new Vector3(0,0,0),0.5F);
       Destroy(other.gameObject,0.3F);
           

        }   
           if (other.CompareTag("key"))

    {
           sayıyazdırmacs.keyfonk();
  other.transform.DOScale(new Vector3(0,0,0),0.5F);
       Destroy(other.gameObject,0.3F);
           

        }  
           if (other.CompareTag("finish"))

    {
          isrunning=false;
          
           if(sayıyazdırmacs.keysayısı==0 && sayıyazdırmacs.coinsayısı>=10) {
             panel.DOScale(new Vector3(1,1,1),1F); 
             sayıyazdırmacs.succespanel();   
            }
            
          
            
           

        } 
                   if (other.CompareTag("gfinish"))

    {
          isrunning=false;
          
           if(sayıyazdırmacs.keysayısı==0 && sayıyazdırmacs.coinsayısı>=10) {
             panel2.DOScale(new Vector3(1,1,1),1F); 
          
            }
            
          
            
           

        } 
 
}
      void ölümyakındır()
    {
           
SceneManager.LoadScene("1");
  PlayerPrefs.DeleteAll();
  
    }
    void deadanimasyon(){
        Animator.SetTrigger("deadtrigger");
          ses.Play();
    }
}







