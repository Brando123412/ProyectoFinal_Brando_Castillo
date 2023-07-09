using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerMultipleAtaque : MonoBehaviour
{
    [SerializeField] BulletEnemy1 bullet;
    [SerializeField] GameObject saveBullet;
    GameObject[] currenttropaPosition = new GameObject[10];
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
            for (int i = 0; i < currenttropaPosition.Length; i++)
            {
                if(currenttropaPosition[i] != null){
                    StartCoroutine(ShootBullet(i));
                }
            }
        }
        
    }

    IEnumerator ShootBullet(int i){
        
        if(currenttropaPosition[i] != null){
            prueba = (currenttropaPosition[i].gameObject.transform.position-transform.position).normalized*2;
            Instantiate(bullet, transform.position, transform.rotation,saveBullet.transform).SetUpVelocity(prueba,SoundBala,velocityBala);
        }    
        yield return new WaitForSecondsRealtime(velocityShoot);
        canShoot = true;
        
    }
    private void OnTriggerEnter(Collider other){
        if(other.CompareTag("Tropa")){
            for (int i = 0; i < currenttropaPosition.Length; i++)
            {
                if(currenttropaPosition[i] == null){
                    currenttropaPosition[i] = other.gameObject;
                    break;
                }
            }
            if(condition ==false){
                canShoot = true;
            }
            condition=true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Tropa")){
            for (int i = 0; i < currenttropaPosition.Length; i++)
            {
                if (currenttropaPosition[i] != null && other.gameObject == currenttropaPosition[i].gameObject)
                {
                    currenttropaPosition[i] = null;
                    break;
                }
            }
        }
    }
}
