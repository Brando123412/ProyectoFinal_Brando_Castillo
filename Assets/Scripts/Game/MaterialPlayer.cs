using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialPlayer : MonoBehaviour
{
    Material mymaterial;
    [SerializeField] private MaterialController material;
    void Awake(){
        mymaterial = GetComponent<MeshRenderer>().material;
    }
    public void OnGoOut(){
        material.ChangeEmissionColor(MaterialChange.OnGoOut,mymaterial);
        StartCoroutine(ColorEmision());
    }
    public void OnEntry(){
        material.ChangeEmissionColor(MaterialChange.OnEntry,mymaterial);
        StartCoroutine(ColorEmision());
    }
    public void Enemy(){
        material.ChangeEmissionColor(MaterialChange.Onhit,mymaterial);
        StartCoroutine(ColorEmision());
    }

    IEnumerator ColorEmision(){
        yield return new WaitForSeconds(0.2f);
        material.ChangeEmissionColor(MaterialChange.Normal,mymaterial);
    }
}
