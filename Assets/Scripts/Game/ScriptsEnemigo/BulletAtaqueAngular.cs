using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAtaqueAngular : MonoBehaviour
{
    Rigidbody rb;
    private Transform target;//Transform de la t
    [SerializeField]  int damage;
    //Prueba
    [SerializeField] private float max_H ;
	[SerializeField] private float custom_Gravity ;
    
    void Awake()
    {
        rb=GetComponent<Rigidbody>();
    }
    void Start(){
        StartCoroutine(OndestroyBullet());
    }

    ////////////////////
    public void Launch(Vector3 tropaPosition,Soundscriptableobjects soundSO){
        GameObject targetObject = new GameObject("Target"); 
        target = targetObject.transform; 
        target.position = tropaPosition;
        soundSO.CreateSound();
		Physics.gravity = Vector3.up * custom_Gravity;
		rb.useGravity = true;
		rb.velocity = CalculateLaunchData().initialVelocity;
	}

	LaunchData CalculateLaunchData() {
		float displacementY = target.position.y - rb.position.y;
		Vector3 displacementXZ = new Vector3 (target.position.x - rb.position.x, 0, target.position.z - rb.position.z);
		float time = Mathf.Sqrt(-2*max_H/custom_Gravity) + Mathf.Sqrt(2*(displacementY - max_H)/custom_Gravity);
		Vector3 velocityY = Vector3.up * Mathf.Sqrt (-2 * custom_Gravity * max_H);
		Vector3 velocityXZ = displacementXZ / time;

		return new LaunchData(velocityXZ + velocityY * -Mathf.Sign(custom_Gravity), time);
	}
	struct LaunchData {
		public readonly Vector3 initialVelocity;
		public readonly float timeToTarget;

		public LaunchData (Vector3 initialVelocity, float timeToTarget)
		{
			this.initialVelocity = initialVelocity;
			this.timeToTarget = timeToTarget;
		}
		
	}
    IEnumerator OndestroyBullet(){
        yield return new WaitForSecondsRealtime(10f);
        if(gameObject != null){
            Destroy(gameObject);
        }
    }
}