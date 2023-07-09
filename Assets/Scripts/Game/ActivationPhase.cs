using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationPhase : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Tropa")){
            Destroy(other.gameObject);
            GameController.Instance.SumarTropas();
        }
    }
}
