using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class control : MonoBehaviour
{
    public float dönmehızı;
 public float hız;
 public float solsağhızı;
 public Animator Animator;
 public bool isrunning = false;
  public bool isjump = false;
 public elmassayısı elmasadet;
 public RectTransform panel;
 public RectTransform panel1;
 public RectTransform panel2;
 public AudioSource ses;
  public AudioSource ses1;
  public AudioSource ses2;
   public AudioSource ses3;
 
  

 private void Start() {
     startrunning();
     elmasadet.levelcollection();
     
    
  AudioSource ses = gameObject.GetComponent<AudioSource>();
    AudioSource ses1 =gameObject.GetComponent<AudioSource>();  
      AudioSource ses2 =gameObject.GetComponent<AudioSource>();  
            AudioSource ses3 =gameObject.GetComponent<AudioSource>();  
 }


 private void Update() {
    clampcharachter();
      
    if(isrunning == true ){
transform.position += transform.forward * hız * Time.deltaTime;
    }

if(Input.GetKeyDown(KeyCode.Space))
{
    if (isrunning == false)
    {
        startrunning();
    }
    else if (isrunning == true)
    {
        stoprunning();
    }

      
}
if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey("a"))
{
    transform.position += -transform.right * solsağhızı * Time.deltaTime;
    transform.rotation = Quaternion.Lerp( transform.rotation,Quaternion.Euler(0,-13,0),dönmehızı*Time.deltaTime);
    
    
}
if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey("d"))
{
    transform.position += transform.right * solsağhızı * Time.deltaTime;
      transform.rotation = Quaternion.Lerp( transform.rotation,Quaternion.Euler(0,13,0),dönmehızı*Time.deltaTime);
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
private void clampcharachter() {
    
float x = Mathf.Clamp(transform.position.x,-3.0f,3.0f);
transform.position= new Vector3(x,transform.position.y,transform.position.z);
}

void OnTriggerEnter(Collider other)
{
     ses.Play();
    if (other.CompareTag("diamand"))

    {
         elmasadet.elmascollection();
  other.transform.DOScale(new Vector3(0,0,0),0.5F);
       Destroy(other.gameObject,0.3F);
           

        }   







if (other.CompareTag("engel"))

    {
        ses1.Play();
       
        float z = transform.position.z - 4F;

 transform.DOJump(new Vector3(transform.position.x, transform.position.y, z),1F,1,0.5F);
       
     

         elmasadet.engelcollection();
         if(elmasadet.engeleçsayisi == 3) {
   Animator.SetTrigger("dead");
   ses2.Play();
   isrunning=false;
     panel1.DOScale(new Vector3(1,1,1),1F);
     
}

        } 







if (other.CompareTag("finish"))

    {
      
      isrunning =false;
      Animator.SetTrigger("dancetrigger");
      panel.DOScale(new Vector3(1,1,1),1F);
ses3.Play();
   elmasadet.succespanel();


        } 
    
if (other.CompareTag("gfinish"))

    {
     
   
     
    isrunning =false;
      Animator.SetTrigger("dancetrigger");
      panel2.DOScale(new Vector3(1,1,1),1F);

        } 

    
}

}
