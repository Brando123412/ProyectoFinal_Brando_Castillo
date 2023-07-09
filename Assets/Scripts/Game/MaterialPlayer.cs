using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialPlayer : MonoBehaviour
{
    [SerializeField] private MaterialController material;
    public void OnGoOut(){
        material.ChangeEmissionColor(MaterialChange.OnGoOut);
        StartCoroutine(ColorEmision());
    }
    public void OnEntry(){
        material.ChangeEmissionColor(MaterialChange.OnEntry);
        StartCoroutine(ColorEmision());
    }
    public void Enemy(){
        material.ChangeEmissionColor(MaterialChange.Onhit);
        StartCoroutine(ColorEmision());
    }

    IEnumerator ColorEmision(){
        yield return new WaitForSeconds(0.2f);
        material.ChangeEmissionColor(MaterialChange.Normal);
    }
}
