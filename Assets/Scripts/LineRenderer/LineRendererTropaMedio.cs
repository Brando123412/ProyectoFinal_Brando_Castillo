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
        //LineMedioEtapa3();
    }
    public void LineMedioEtapa3(){
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0 , new Vector3(myGrafo.allNode.GetNodeAtPosition(0).transform.position.x,-0.25f,myGrafo.allNode.GetNodeAtPosition(0).transform.position.z)); 
        lineRenderer.SetPosition(1 , new Vector3(myGrafo.allNode.GetNodeAtPosition(3).transform.position.x,-0.25f,myGrafo.allNode.GetNodeAtPosition(3).transform.position.z)); 
    }
    
}
