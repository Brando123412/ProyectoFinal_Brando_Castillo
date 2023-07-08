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
    private bool canShoot = false;//Condicion para disparar
    void Awake(){
        saveBullet=Instantiate(saveBullet,new Vector3(0,0,0),transform.rotation);
    }
    void Start()
    {
        
    }
    void Update()
    {
        if(canShoot == true){
            if(currenttropaPosition==null){
                currenttropaPosition = currenttropaPositionAddDate;
            }
            StartCoroutine(ShootBullet());
            canShoot =false;
        }
        if(currenttropaPosition!=null){
            transform.LookAt(currenttropaPosition.transform);
        }
        
    }

    IEnumerator ShootBullet(){
        if(currenttropaPosition != null){
            prueba = (currenttropaPosition.gameObject.transform.position-transform.position).normalized*2;
            Instantiate(bullet, transform.position, transform.rotation,saveBullet.transform).SetUpVelocity(prueba,SoundBala);
            yield return new WaitForSecondsRealtime(0.5f);
            canShoot = true;
        }
        /*prueba = (currenttropaPosition.gameObject.transform.position-transform.position).normalized*2;
        Instantiate(bullet, transform.position, transform.rotation,saveBullet.transform).SetUpVelocity(prueba,SoundBala);
        yield return new WaitForSecondsRealtime(0.1f);
        canShoot = true;*/
    }
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Tropa")){
            currenttropaPositionAddDate = other.gameObject;
            canShoot = true;
            /*if(currenttropaPosition==null){
                currenttropaPosition = other.gameObject;
                canShoot = true;
            }*/

            //currenttropaPosition = other.gameObject;
            //canShoot = true;
            //prueba = (currenttropaPosition.gameObject.transform.position-transform.position).normalized*2;
            //Instantiate(bullet,transform.position,transform.rotation,saveBullet.transform).SetUpVelocity(prueba,SoundBala);;
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
