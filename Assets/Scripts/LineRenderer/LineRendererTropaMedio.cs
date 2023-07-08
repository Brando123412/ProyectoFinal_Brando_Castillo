using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererTropaMedio : MonoBehaviour
{
    LineRenderer lineRenderer;
    [SerializeField] MyGrafo myGrafo;
    void Awake(){
        lineRenderer= GetComponent<LineRenderer>();
    }
    void Start()
    {
        LineMedioEtapa3();
    }
    void LineMedioEtapa3(){
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0 , myGrafo.allNode.GetNodeAtPosition(0).transform.position); 
        lineRenderer.SetPosition(1 , myGrafo.allNode.GetNodeAtPosition(3).transform.position); 
    }
    
}
