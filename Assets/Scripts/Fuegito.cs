using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuegito : MonoBehaviour
{
    [SerializeField] ParticleSystem particula1;
    [SerializeField] ParticleSystem particula2;
    
    void OnTriggerExit(Collider other){
        if(other.CompareTag("Ground")){
            gameObject.SetActive(false);
            particula1.Play();
            Invoke("ExpacionFuego",2);
            Destroy(gameObject,3);
        }
    }
    void ExpacionFuego(){
        particula2.Play();
    }
}
