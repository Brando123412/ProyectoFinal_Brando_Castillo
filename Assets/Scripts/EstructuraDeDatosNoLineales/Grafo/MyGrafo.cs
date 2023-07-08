using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGrafo : MonoBehaviour
{
    public SimplyLinkList<NodeController> allNode;
    public GameObject nodePrefab;
    GameObject currentNode;
    public NodeController currentNodeControl;
    //public PlayerController player;
    void Awake(){
        allNode =  new SimplyLinkList<NodeController>();
        GenerateCamino();
    }
    void Start(){
        /*currentNodeControl= allNode.GetNodeAtPosition(33);
        player.ChangeMovePosition(currentNodeControl.gameObject.transform.position);*/
    }
    void AddNode(float positionx, float positiony, int nodeTag){
        currentNode = Instantiate(nodePrefab, transform.position, transform.rotation);
        currentNode.transform.SetParent(transform);
        currentNode.GetComponent<NodeController>().SetInitialValues(positionx, positiony,nodeTag);
        allNode.AddNodeAtStart(currentNode.GetComponent<NodeController>());
    }

    void AddNodeAdjacent(int nodeTag,int[] allAdjacentTags){
        NodeController selectedNode = SearchNode(nodeTag);

        for (int i = 0; i < allAdjacentTags.Length; i++)
        {
            selectedNode.AddNodeAdjacent(SearchNode(allAdjacentTags[i]));
        }
    }
    NodeController SearchNode(int nodeTag){
        int position=0;
        for (int i = 0; i < allNode.Count; i++)
        {
            if(allNode.GetNodeAtPosition(i).nodeTag == nodeTag){
                position =i;
                break;
            }
        }
        return allNode.GetNodeAtPosition(position);
    }
    public void GraphOne(){
        AddNodeAdjacent(0,new int[]{1});
        AddNodeAdjacent(1,new int[]{2,3});
        AddNodeAdjacent(2,new int[]{4});
        AddNodeAdjacent(3,new int[]{4});
        AddNodeAdjacent(4,new int[]{5});
        AddNodeAdjacent(5,new int[]{6});
        AddNodeAdjacent(6,new int[]{7});
        AddNodeAdjacent(7,new int[]{8,9});
        AddNodeAdjacent(8,new int[]{10});
        AddNodeAdjacent(9,new int[]{10});
        AddNodeAdjacent(10,new int[]{11});
        AddNodeAdjacent(11,new int[]{12});
        AddNodeAdjacent(12,new int[]{13});
        AddNodeAdjacent(13,new int[]{14});
        AddNodeAdjacent(14,new int[]{15});
        AddNodeAdjacent(15,new int[]{16});
        AddNodeAdjacent(16,new int[]{17});
        AddNodeAdjacent(17,new int[]{18});
        AddNodeAdjacent(18,new int[]{19});
        AddNodeAdjacent(19,new int[]{19});

        /*currentNodeControl= allNode.GetNodeAtPosition(33);
        player.ChangeMovePosition(currentNodeControl.gameObject.transform.position);*/
    }
    public void GraphTwo(){
        AddNodeAdjacent(20,new int[]{21});
        AddNodeAdjacent(21,new int[]{22,23});
        AddNodeAdjacent(22,new int[]{24});
        AddNodeAdjacent(23,new int[]{24});
        AddNodeAdjacent(24,new int[]{25});
        AddNodeAdjacent(25,new int[]{26});
        AddNodeAdjacent(26,new int[]{27});
        AddNodeAdjacent(27,new int[]{28});
        AddNodeAdjacent(28,new int[]{29});
        AddNodeAdjacent(29,new int[]{29});
        /*currentNodeControl= allNode.GetNodeAtPosition(13);
        player.ChangeMovePosition(currentNodeControl.gameObject.transform.position);*/
    }
    public void GraphThree(){
        AddNodeAdjacent(30,new int[]{31,32,33});
        AddNodeAdjacent(31,new int[]{33});
        AddNodeAdjacent(32,new int[]{33});
        AddNodeAdjacent(33,new int[]{33});
        /*currentNodeControl= allNode.GetNodeAtPosition(3);
        player.ChangeMovePosition(currentNodeControl.gameObject.transform.position);*/
    }
    public void SeleccionCamino1(GameObject player){
        currentNodeControl= allNode.GetNodeAtPosition(33);
        player.GetComponent<PlayerController>().ChangeMovePosition(currentNodeControl.gameObject.transform.position);
    }
    public void SeleccionCamino2(GameObject player){
        currentNodeControl= allNode.GetNodeAtPosition(13);
        player.GetComponent<PlayerController>().ChangeMovePosition(currentNodeControl.gameObject.transform.position);
    }
    public void SeleccionCamino3(GameObject player){
        currentNodeControl= allNode.GetNodeAtPosition(3);
        player.GetComponent<PlayerController>().ChangeMovePosition(currentNodeControl.gameObject.transform.position);
    }
    void GenerateCamino(){
        //Camino 1
        AddNode(24,3.5f,0);
        AddNode(11,3.5f,1);
        AddNode(8.35f,0.7f,2);
        AddNode(8.35f,6.6f,3);
        AddNode(5.5f,3.5f,4);
        AddNode(-7.7f,3.5f,5);
        AddNode(-7.7f,-7.7f,6);
        AddNode(10.11f,-7.7f,7);
        AddNode(12.7f,-5.3f,8);
        AddNode(12.7f,-10.4f,9);
        AddNode(15.6f,-7.7f,10);
        AddNode(23.9f,-7.7f,11);
        AddNode(23.9f,-45.2f,12);
        AddNode(4,-45.2f,13);
        AddNode(4,-34,14);
        AddNode(15,-34,15);
        AddNode(15,-18.9f,16);
        AddNode(3.9f,-18.9f,17);
        AddNode(3.9f,-25.4f,18);
        AddNode(-12.6f,-25.4f,19);
        
        //Camino 2
        AddNode(-16.7f,-25.4f,20);
        AddNode(-35,-25.4f,21);
        AddNode(-48.7f,-38.8f,22);
        AddNode(-48.7f,-11.6f,23);
        AddNode(-62.1f,-25.4f,24);
        AddNode(-76.2f,-25.4f,25);
        AddNode(-76.2f,1,26);
        AddNode(-90.1f,1,27);
        AddNode(-90.1f,-42.9f,28);
        AddNode(-107.5f,-42.9f,29);
        
        //Camino 3
        AddNode(-110.2f,-42.8f,30);
        AddNode(-110.2f,1,31);
        AddNode(-154.6f,-42.8f,32);
        AddNode(-154.6f,1,33);
    }
}
