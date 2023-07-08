using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy1 : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField]  float velocityMultiplier;
    [SerializeField]  int damage;
    
    void Awake()
    {
        rb=GetComponent<Rigidbody>();
    }
    void Start(){
        StartCoroutine(OndestroyBullet());
    }
    public void SetUpVelocity(Vector3 velocity,Soundscriptableobjects myAudioSO){
        rb.velocity = velocity * velocityMultiplier;
        myAudioSO.CreateSound();
        //DamageManager.instance.SubscribeFunction(this);
    }
    IEnumerator OndestroyBullet(){
        yield return new WaitForSecondsRealtime(10f);
        if(gameObject != null){
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Tropa")){
            Destroy(gameObject);
            Debug.Log("Me destruyo solo");
        }
    }

        
}
