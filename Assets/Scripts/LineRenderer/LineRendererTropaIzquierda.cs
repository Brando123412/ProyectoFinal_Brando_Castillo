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
        LineIzquierdaEtapa3();
        //LineIzquierdaEtapa2();
        //LineIzquierdaEtapa1();
        
    }
    void LineIzquierdaEtapa3(){
        lineRenderer.positionCount = 3;
        lineRenderer.SetPosition(0 , myGrafo.allNode.GetNodeAtPosition(0).transform.position); 
        lineRenderer.SetPosition(1 , myGrafo.allNode.GetNodeAtPosition(1).transform.position); 
        lineRenderer.SetPosition(2 , myGrafo.allNode.GetNodeAtPosition(3).transform.position); 
    }
    void LineIzquierdaEtapa2(){
        lineRenderer.positionCount = 9;
        x=0;
        for (int i = 4; i < 13; i++)
        {
            if(i==10){
                x--;
            }
            lineRenderer.SetPosition(i-4 , myGrafo.allNode.GetNodeAtPosition(i-x).transform.position); 
        }
    }
    void LineIzquierdaEtapa1(){
        lineRenderer.positionCount = 18;
        x=0;
        for (int i = 14; i < 32; i++)
        {
            if(i==25 || i==30){
                x--;
            }
            lineRenderer.SetPosition(i-14 , myGrafo.allNode.GetNodeAtPosition(i-x).transform.position); 
        }
    }
}
