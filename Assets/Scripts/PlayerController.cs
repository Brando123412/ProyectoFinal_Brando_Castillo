using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    Vector3 vectorToMove;
    [SerializeField] float speed;
    Rigidbody rb;
    [SerializeField] MaterialPlayer materialPlayer;
    Transform myCamara;
    [SerializeField] Transform canvasVida;

    [SerializeField] int life;
    [SerializeField] TMP_Text currentLife;

    void Awake()
    {
        rb=GetComponent<Rigidbody>();
        myCamara = Camera.main.transform;
    }
    void Start(){
        currentLife.text = life.ToString();
    }
    public void GoToNode(MyGrafo mygrafo, SaveTropas value){
        if(value.faseSelecction==0){
            mygrafo.SeleccionCamino1(gameObject);
        }else if(value.faseSelecction==1){
            mygrafo.SeleccionCamino2(gameObject);
        }else if(value.faseSelecction==2){
            mygrafo.SeleccionCamino3(gameObject);
        }
        
    }
    void Update(){
        transform.LookAt(vectorToMove, Vector3.zero);
        canvasVida.transform.LookAt(myCamara.transform);
    }
    void FixedUpdate(){
        rb.velocity = (vectorToMove-transform.position).normalized*speed;
    }
    public void ChangeMovePosition(Vector3 destiny){
        vectorToMove = destiny;
    }
    void lifeVida(){
        currentLife.text = life.ToString();
        if(life<=0)
        {
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter(Collider other){
        /*if(other.CompareTag("OnGoOut"))
        { 
            materialPlayer.OnGoOut();
        }
        if(other.CompareTag("OnEntry"))
        { 
            materialPlayer.OnEntry();
        }*/
        if(other.CompareTag("Enemy"))
        { 
            materialPlayer.Enemy();
            Destroy(other.gameObject);
            life=life-20;
            lifeVida();
        }
        if(other.CompareTag("Enemy2"))
        { 
            materialPlayer.Enemy();
            Destroy(other.gameObject);
            life=life-50;
            lifeVida();
        }
        if(other.CompareTag("Mina"))
        { 
            if(gameObject.name=="Tropa2" ||gameObject.name=="Tropa3"||gameObject.name=="Tropa6"){
                materialPlayer.Enemy();
                life=life-150;
                lifeVida();
            }
            if(gameObject.name=="Tropa1" ||gameObject.name=="Tropa4"||gameObject.name=="Tropa5"){
                materialPlayer.Enemy();
                life=life-75;
                lifeVida();
            }
        }
    }
}
