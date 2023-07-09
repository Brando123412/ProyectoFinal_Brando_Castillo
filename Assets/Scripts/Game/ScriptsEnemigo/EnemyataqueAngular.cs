using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyataqueAngular : MonoBehaviour
{
    [SerializeField] BulletAtaqueAngular bullet;
    [SerializeField]GameObject saveBullet;
    [SerializeField]GameObject currenttropaPosition;
    GameObject currenttropaPositionAddDate;
    [SerializeField]Soundscriptableobjects SoundBala;
    [SerializeField] Transform puntodisparo;
    bool canShoot;
    bool condition;
    [SerializeField] float velocityShoot;
    void Awake(){
        saveBullet=Instantiate(saveBullet,new Vector3(0,0,0),Quaternion.identity);
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
            Instantiate(bullet, puntodisparo.position, transform.rotation,saveBullet.transform).Launch(currenttropaPosition.transform.position,SoundBala);
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
