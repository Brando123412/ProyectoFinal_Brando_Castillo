using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControler : MonoBehaviour
{
    [SerializeField] BulletEnemy1 bullet;
    [SerializeField] GameObject saveBullet;
    GameObject currenttropaPosition;
    GameObject currenttropaPositionAddDate;
    Vector3 prueba;
    [SerializeField]Soundscriptableobjects SoundBala;
    bool canShoot;
    bool condition;
    [SerializeField] float velocityShoot;
    [SerializeField] float velocityBala;
    void Awake(){
        saveBullet=Instantiate(saveBullet,new Vector3(0,0,0),transform.rotation);
        canShoot=false;
        condition=false;
    }
    void Start()
    {
        
    }
    void Update()
    {
        if(canShoot == true){
            canShoot =false;
            if(currenttropaPosition==null){
                currenttropaPosition = currenttropaPositionAddDate;
            }
            StartCoroutine(ShootBullet());
        }
        if(currenttropaPosition!=null){
            transform.LookAt(currenttropaPosition.transform);
        }
        
    }

    IEnumerator ShootBullet(){
        if(currenttropaPosition != null){
            prueba = (currenttropaPosition.gameObject.transform.position-transform.position).normalized*2;
            Instantiate(bullet, transform.position, transform.rotation,saveBullet.transform).SetUpVelocity(prueba,SoundBala,velocityBala);
        }
        yield return new WaitForSecondsRealtime(velocityShoot);
        canShoot = true;
    }
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Tropa")){
            currenttropaPositionAddDate = other.gameObject;
            if(condition ==false){
                canShoot = true;
            }
            condition=true;
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == currenttropaPosition?.gameObject)
        {
            currenttropaPosition = null;
        }
        if (other.gameObject == currenttropaPositionAddDate?.gameObject)
        {
            currenttropaPositionAddDate = null;
        }
    }
    
}
