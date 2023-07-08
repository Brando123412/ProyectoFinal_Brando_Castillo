using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererTropaDerecha : MonoBehaviour
{
    LineRenderer lineRenderer;
    [SerializeField] MyGrafo myGrafo;
    void Awake(){
        lineRenderer= GetComponent<LineRenderer>();
    }
    void Start()
    {
        LineDerechaEtapa3();
        //LineDerechaEtapa2();
        //LineDerechaEtapa1();
    }

    void LineDerechaEtapa3(){
        lineRenderer.positionCount = 3;
        lineRenderer.SetPosition(0 , myGrafo.allNode.GetNodeAtPosition(0).transform.position); 
        lineRenderer.SetPosition(1 , myGrafo.allNode.GetNodeAtPosition(2).transform.position); 
        lineRenderer.SetPosition(2 , myGrafo.allNode.GetNodeAtPosition(3).transform.position); 
    }
    void LineDerechaEtapa2(){
        lineRenderer.positionCount = 3;
        lineRenderer.SetPosition(0 , myGrafo.allNode.GetNodeAtPosition(9).transform.position); 
        lineRenderer.SetPosition(1 , myGrafo.allNode.GetNodeAtPosition(10).transform.position); 
        lineRenderer.SetPosition(2 , myGrafo.allNode.GetNodeAtPosition(12).transform.position);
    }
    void LineDerechaEtapa1(){
        lineRenderer.positionCount = 8;
        lineRenderer.SetPosition(0 , myGrafo.allNode.GetNodeAtPosition(23).transform.position); 
        lineRenderer.SetPosition(1 , myGrafo.allNode.GetNodeAtPosition(25).transform.position); 
        lineRenderer.SetPosition(2 , myGrafo.allNode.GetNodeAtPosition(26).transform.position);
        lineRenderer.SetPosition(3 , myGrafo.allNode.GetNodeAtPosition(27).transform.position);
        lineRenderer.SetPosition(4 , myGrafo.allNode.GetNodeAtPosition(28).transform.position);
        lineRenderer.SetPosition(5 , myGrafo.allNode.GetNodeAtPosition(29).transform.position);
        lineRenderer.SetPosition(6 , myGrafo.allNode.GetNodeAtPosition(30).transform.position);
        lineRenderer.SetPosition(7 , myGrafo.allNode.GetNodeAtPosition(32).transform.position);
    }
}
