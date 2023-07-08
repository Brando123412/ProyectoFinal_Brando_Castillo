using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyataqueAngular : MonoBehaviour
{
    [SerializeField] BulletAtaqueAngular bullet;
    [SerializeField]GameObject saveBullet;
    [SerializeField]GameObject currenttropaPosition;
    GameObject currenttropaPositionAddDate;
    Vector3 prueba;
    [SerializeField]Soundscriptableobjects SoundBala;
    private bool canShoot = false;
    void Awake(){
        saveBullet=Instantiate(saveBullet,new Vector3(0,0,0),Quaternion.identity);
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
            canShoot =false;
            StartCoroutine(ShootBullet());
        }
        if(currenttropaPosition!=null){
            transform.LookAt(currenttropaPosition.transform);
        }
        
    }

    IEnumerator ShootBullet(){
        if(currenttropaPosition != null){
            ///prueba = (currenttropaPosition.transform.position-transform.position).normalized*2;
            Instantiate(bullet, transform.position, transform.rotation,saveBullet.transform).Launch(currenttropaPosition.transform.position,SoundBala);
            yield return new WaitForSecondsRealtime(0.5f);
            canShoot = true;
        }
    }
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Tropa")){
            currenttropaPositionAddDate = other.gameObject;
            canShoot = true;
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
