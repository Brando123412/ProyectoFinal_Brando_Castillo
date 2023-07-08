using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyQueue<T>
{
    class Node{
        public T Value{get; set;}
        public Node Next{get; set;}
        public Node Previous{get; set;}
        public Node(T value){
            Value=value;
            Next=null;
            Previous=null;
        }
    }
    Node Head;
    Node Tail;
    public int Count=0;
    public void Enqueue(T value){
        Node newNode= new Node(value);
        if(Head==null){
            Head = newNode;
            Tail = newNode;
            Count++;
        }else{
            Tail.Next = newNode;
            newNode.Previous = Tail;
            Tail = newNode;
            Count++;
        }
        Debug.Log(Head.Value);
    }
    public T Dequeue(){
        T tmp= Head.Value;
        Debug.Log(tmp);
        if(Count >0){
            Head = Head.Next;
            if(Count !=1){
                Head.Previous=null;
            }
            Count--;
        }else{
            Tail = null;
            Head=null;
        }
        Debug.Log(tmp);
        return tmp;
    }
}
