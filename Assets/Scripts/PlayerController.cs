using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 vectorToMove;
    [SerializeField] float speed;
    Rigidbody rb;
    [SerializeField] MaterialPlayer materialPlayer;

    void Awake()
    {
        rb=GetComponent<Rigidbody>();
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
    }
    void FixedUpdate(){
        rb.velocity = (vectorToMove-transform.position).normalized*speed;
    }
    public void ChangeMovePosition(Vector3 destiny){
        vectorToMove = destiny;
    }
    void OnTriggerExit(Collider other){
        if(other.CompareTag("OnGoOut"))
        { 
            materialPlayer.OnGoOut();
        }
        if(other.CompareTag("OnEntry"))
        { 
            materialPlayer.OnEntry();
        }
        if(other.CompareTag("Enemy"))
        { 
            materialPlayer.Enemy();
            Destroy(other.gameObject);
        }
    }
}
