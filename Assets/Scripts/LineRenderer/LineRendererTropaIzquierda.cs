using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineRendererTropaIzquierda : MonoBehaviour
{
    LineRenderer lineRenderer;
    [SerializeField] MyGrafo myGrafo;
    int x=0;
    void Awake(){
        lineRenderer= GetComponent<LineRenderer>();
    }
    void Start()
    {
        
    }
    public void LineIzquierdaEtapa3(){
        lineRenderer.positionCount = 3;
        lineRenderer.SetPosition(0 , new Vector3(myGrafo.allNode.GetNodeAtPosition(0).transform.position.x,-0.25f,myGrafo.allNode.GetNodeAtPosition(0).transform.position.z)); 
        lineRenderer.SetPosition(1 , new Vector3(myGrafo.allNode.GetNodeAtPosition(1).transform.position.x,-0.25f,myGrafo.allNode.GetNodeAtPosition(1).transform.position.z)); 
        lineRenderer.SetPosition(2 , new Vector3(myGrafo.allNode.GetNodeAtPosition(3).transform.position.x,-0.25f,myGrafo.allNode.GetNodeAtPosition(3).transform.position.z)); 
    }
    public void LineIzquierdaEtapa2(){
        lineRenderer.positionCount = 9;
        x=0;
        for (int i = 4; i < 13; i++)
        {
            if(i==10){
                x--;
            }
            lineRenderer.SetPosition(i-4 , new Vector3(myGrafo.allNode.GetNodeAtPosition(i-x).transform.position.x,-0.25f,myGrafo.allNode.GetNodeAtPosition(i-x).transform.position.z)); 
        }
    }
    public void LineIzquierdaEtapa1(){
        lineRenderer.positionCount = 18;
        x=0;
        for (int i = 14; i < 32; i++)
        {
            if(i==25 || i==30){
                x--;
            }
            lineRenderer.SetPosition(i-14 , new Vector3(myGrafo.allNode.GetNodeAtPosition(i-x).transform.position.x,-0.25f,myGrafo.allNode.GetNodeAtPosition(i-x).transform.position.z)); 
        }
    }
}