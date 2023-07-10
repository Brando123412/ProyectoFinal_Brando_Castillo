using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeController : MonoBehaviour
{
    SimplyLinkList<NodeController> allAdjacentesNodes;
    float positionx,positiony;
    public int nodeTag;
    void Awake(){
        allAdjacentesNodes = new SimplyLinkList<NodeController>();
    }
    void Update()
    {
        
    }
    public void SetInitialValues(float positionx, float positiony, int nodeTag){
        this.positionx = positionx;
        this.positiony = positiony;
        transform.position = new Vector3(positionx,0.15f,positiony);
        this.nodeTag=nodeTag;

    }
    public void AddNodeAdjacent(NodeController nodo){
        allAdjacentesNodes.AddNodeAtStart(nodo);
    }

    public NodeController SelectNextNode(){
        int nodeSelect = Random.Range(0,allAdjacentesNodes.Count);
        return allAdjacentesNodes.GetNodeAtPosition(nodeSelect);
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Tropa" ){
            other.GetComponent<PlayerController>().ChangeMovePosition(SelectNextNode().gameObject.transform.position);
        }
    }
}
