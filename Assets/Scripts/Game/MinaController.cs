using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinaController : MonoBehaviour
{
    [SerializeField] ParticleSystem[] particulasBomba;
    [SerializeField] GameObject padre;

    void Start()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Tropa")){
            StartCoroutine(Confirmacion());
        }
    }
    IEnumerator Confirmacion(){
        particulasBomba[0].Play();
        yield return new WaitForSeconds(2);
        particulasBomba[1].Play();
        gameObject.SetActive(false);
        yield return new WaitForSeconds(2);
        Destroy(padre);
    }

}
