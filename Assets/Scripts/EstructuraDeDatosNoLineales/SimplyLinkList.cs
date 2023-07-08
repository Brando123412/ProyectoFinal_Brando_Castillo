using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplyLinkList<T>
{
    class Node{
            public T Value{get;set;}
            public Node Next {get;set;}
            public Node(T value){
                Value = value;
                Next = null;
            }
        }
        Node Head{get;set;}
        public int Count =0;
        public void AddNodeAtStart(T value){
            Node newnodo= new Node(value);
            if(Head == null)
            {
                Head = newnodo;
                Count++;
            }else{
                Node tmp = Head;
                Head = newnodo;
                Head.Next = tmp;
                Count++;
            }
        }
        public void AddNodeAtEnd(T value){
            if(Head == null)
            {
                AddNodeAtStart(value);
            }else{
                Node tmp = Head;
                while(tmp.Next!=null){
                    tmp = tmp.Next;
                }
                Node newnodo= new Node(value);
                tmp.Next = newnodo;
                Count++;
            }
        }
        public void AddNodeAtPosition(T value, int position){
            if(position == 0)
            {
                AddNodeAtStart(value);
            }else if(position == Count-1){
                AddNodeAtEnd(value);
            }else if(position>Count){
                Debug.Log("No se puede hacer esta operacion");
                //Console.WriteLine("No se puede hacer esta operacion");
            }else{
                int currentPosition=0;
                Node tmp = Head;
                while(currentPosition < position-1){
                    tmp=tmp.Next;
                    currentPosition++;  
                }
                Node nodoAddPosition =  tmp.Next;
                Node newnodo= new Node(value);
                tmp.Next = nodoAddPosition;
                Count++;
            }
        }
        public void ModifyAtStart(T value)
        {
            if(Head == null){
                Debug.Log("No se puede hacer esta operacion");
                //Console.WriteLine("No se puede realizar esta operacion");
            }else{
                Head.Value= value;
            }
        }
        public void ModifyAtEnd(T value)
        {
            if(Head == null){
                Debug.Log("No se puede hacer esta operacion");
                //Console.WriteLine("No se puede realizar esta operacion");
            }else{
                Node tmp = Head;
                while(tmp.Next != null)
                {
                    tmp = tmp.Next;
                }
                tmp.Value = value;
            }
        }
        public void ModifyAtPosition(T value, int position)
        {
            if(position==0){
                ModifyAtStart(value);
            }else if(position==Count-1){
                ModifyAtEnd(value);
            }else if(position>Count){
                Debug.Log("No se puede hacer esta operacion");
                //Console.WriteLine("Esta operacion no se puede realizar");
            }else{
                Node tmp = Head;
                int currentPosition=0;
                while( currentPosition < position-1)
                {
                    tmp = tmp.Next;
                    currentPosition++;
                }
                tmp.Value = value;
            }
        }

        public T GetNodeAtStart()
        {
            if (Head == null)
            {
                return default(T);
            }
            else
            {
                return Head.Value;
            }
        }

        public T GetNodeAtEnd()
        {
            if (Head == null)
            {
                return default(T);
                //throw new Exception();
            }
            else
            {
                Node tmp = Head;
                while (tmp.Next != null)
                {
                    tmp = tmp.Next;
                }
                return tmp.Value;
            }
        }
        public T GetNodeAtPosition(int position)
        {
            if (position == 0)
            {
                return GetNodeAtStart();
            }
            else if (position == Count - 1)
            {
                return GetNodeAtEnd();
            }
            else if (position > Count || position<0)
            {
                return default(T);
                //throw new Exception();
            }
            else
            {
                int iterator = 0;
                Node tmp = Head;
                while (iterator < position)
                {
                    tmp = tmp.Next;
                    iterator = iterator + 1;
                }
                return tmp.Value;
            }
        }
        public void RemoveAtStart()
        {
            if (Head == null)
            {
                Debug.Log("Eso no se puede hacer");
                //Console.WriteLine("Eso no se puede hacer");
            }
            else
            {
                Node newHead = Head.Next;
                Head.Next = null;
                Head = null;
                Head = newHead;
                Count = Count - 1;
            }
        }
        public void RemoveAtEnd()
        {
            Node tmp = Head;
            int iterator =0;
            while (iterator < Count -2)
            {
                tmp = tmp.Next;
                iterator++;
            }
            tmp.Next=null;
            Count = Count - 1;
        }
        public void RemoveNodeAtPosition(int position)
        {
            if (position == 0)
            {
                RemoveAtStart();
            }else if (position == Count - 1){
                RemoveAtEnd();
            }else if (position > Count){
                Debug.Log("Eso no se puede hacer");
            }else{
                int iterator = 0;
                Node previousNode = Head;
                while (iterator < position - 1)
                {
                    previousNode = previousNode.Next;
                    iterator = iterator + 1;
                }
                Node currentNode = previousNode.Next;
                Node nextNode = currentNode.Next;
                currentNode.Next = null;
                currentNode = null;
                previousNode.Next = null;
                previousNode.Next = nextNode;
                Count = Count - 1;
            }
        }
        public void PrintAllNodes(){
            Node tmp = Head;
            while(tmp!=null)
            {
                Debug.Log(tmp.Value);
                tmp=tmp.Next;
            }
        }
}
