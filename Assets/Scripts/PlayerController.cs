using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Vector3 vectorToMove;
    [SerializeField] int speed;
    [SerializeField] private MaterialController material;
    Rigidbody rb;
    //MyGrafo mygrafo;
    void Awake()
    {
        rb=GetComponent<Rigidbody>();
    }
    /*void Start(){
        mygrafo.SeleccionCamino1(gameObject);
    }*/
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
    IEnumerator ColorEmision(){
        yield return new WaitForSeconds(1);
        material.ChangeEmissionColor(MaterialChange.Normal);
    }
    void OnTriggerExit(Collider other){
        if(other.CompareTag("OnGoOut"))
        { 
            material.ChangeEmissionColor(MaterialChange.OnGoOut);
            StartCoroutine(ColorEmision());
        }
        if(other.CompareTag("OnEntry"))
        { 
            material.ChangeEmissionColor(MaterialChange.OnEntry);
            StartCoroutine(ColorEmision());
        }
        if(other.CompareTag("Enemy"))
        { 
            material.ChangeEmissionColor(MaterialChange.Onhit);
            StartCoroutine(ColorEmision());
        }
    }
}
