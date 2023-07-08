using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySingleAttack : MonoBehaviour
{
    public GameObject bullet;
    bool canShoot = true;
    bool deteccionTropa=false;
    [SerializeField]float tiempoAttack;
    void Update()
    {
        if(deteccionTropa==true && canShoot){
            StartCoroutine(ShootBullet());
            canShoot = false;
        }
    }
    IEnumerator ShootBullet(){
        Instantiate(bullet, transform.position, Quaternion.identity,gameObject.transform);/*.SetUpVelocity(ogreRB2D.velocity, "Enemy",SoundBala);*/
        yield return new WaitForSeconds(tiempoAttack);
        canShoot=true;
    }
    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Tropa"))
        {
            deteccionTropa = true;
        }
    }
    void OnTriggerExit(Collider other){
        if(other.CompareTag("Tropa"))
        {
            deteccionTropa = false;
        }
    }
}
