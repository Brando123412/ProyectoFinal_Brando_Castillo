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

    public void LineDerechaEtapa3(){
        lineRenderer.positionCount = 3;
        lineRenderer.SetPosition(0 , new Vector3(myGrafo.allNode.GetNodeAtPosition(0).transform.position.x,-0.25f,myGrafo.allNode.GetNodeAtPosition(0).transform.position.z)); 
        lineRenderer.SetPosition(1 , new Vector3(myGrafo.allNode.GetNodeAtPosition(2).transform.position.x,-0.25f,myGrafo.allNode.GetNodeAtPosition(2).transform.position.z)); 
        lineRenderer.SetPosition(2 , new Vector3(myGrafo.allNode.GetNodeAtPosition(3).transform.position.x,-0.25f,myGrafo.allNode.GetNodeAtPosition(3).transform.position.z)); 
    }
    public void LineDerechaEtapa2(){
        lineRenderer.positionCount = 3;
        lineRenderer.SetPosition(0 , new Vector3(myGrafo.allNode.GetNodeAtPosition(9).transform.position.x,-0.25f,myGrafo.allNode.GetNodeAtPosition(9).transform.position.z)); 
        lineRenderer.SetPosition(1 , new Vector3(myGrafo.allNode.GetNodeAtPosition(10).transform.position.x,-0.25f,myGrafo.allNode.GetNodeAtPosition(10).transform.position.z)); 
        lineRenderer.SetPosition(2 , new Vector3(myGrafo.allNode.GetNodeAtPosition(12).transform.position.x,-0.25f,myGrafo.allNode.GetNodeAtPosition(12).transform.position.z));
    }
    public void LineDerechaEtapa1(){
        lineRenderer.positionCount = 8;
        lineRenderer.SetPosition(0 , new Vector3(myGrafo.allNode.GetNodeAtPosition(23).transform.position.x,-0.25f,myGrafo.allNode.GetNodeAtPosition(23).transform.position.z)); 
        lineRenderer.SetPosition(1 , new Vector3(myGrafo.allNode.GetNodeAtPosition(25).transform.position.x,-0.25f,myGrafo.allNode.GetNodeAtPosition(25).transform.position.z)); 
        lineRenderer.SetPosition(2 , new Vector3(myGrafo.allNode.GetNodeAtPosition(26).transform.position.x,-0.25f,myGrafo.allNode.GetNodeAtPosition(26).transform.position.z));
        lineRenderer.SetPosition(3 , new Vector3(myGrafo.allNode.GetNodeAtPosition(27).transform.position.x,-0.25f,myGrafo.allNode.GetNodeAtPosition(27).transform.position.z));
        lineRenderer.SetPosition(4 , new Vector3(myGrafo.allNode.GetNodeAtPosition(28).transform.position.x,-0.25f,myGrafo.allNode.GetNodeAtPosition(28).transform.position.z));
        lineRenderer.SetPosition(5 , new Vector3(myGrafo.allNode.GetNodeAtPosition(29).transform.position.x,-0.25f,myGrafo.allNode.GetNodeAtPosition(29).transform.position.z));
        lineRenderer.SetPosition(6 , new Vector3(myGrafo.allNode.GetNodeAtPosition(31).transform.position.x,-0.25f,myGrafo.allNode.GetNodeAtPosition(31).transform.position.z));
        lineRenderer.SetPosition(7 , new Vector3(myGrafo.allNode.GetNodeAtPosition(32).transform.position.x,-0.25f,myGrafo.allNode.GetNodeAtPosition(32).transform.position.z));
    }
}


