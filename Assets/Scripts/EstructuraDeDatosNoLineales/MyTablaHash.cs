using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTablaHash <T>
{
  class Node
    {
        public string keyCode { get; set;}
        public T objeto { get; set; }
        public Node(string keyCode, T objeto)
        {
            this.keyCode = keyCode;
            this.objeto = objeto;
        }
    }
    Node [] almacen =new Node [101];
    int repeatquantity=0;
    char [] characterCode=new char[27];
    public void HashFunction(){
        int j=97;
        for (int i = 1; i < characterCode.Length; i++)
        {
            characterCode[i]=((char)j);
            j++;
        }
    }
    public void Insertar(string keyCode, T objeto)
    {
        keyCode=keyCode.ToLower();
        Node newkeyCode = new Node(keyCode, objeto);
        int b=GenerateKey(keyCode);
        int repeat=0;
        int h1=b%101;
        int c1=0;
        int c2=1;
        int i=0;
        int llave=h1;
        //Debug.Log(llave+" Inicial"+ keyCode);
        while(almacen[llave]!=null){
            //Debug.Log(llave+" Inicial"+ keyCode+" repeticion "+i);
            llave=(h1+c1*i+c2*i*i)%103;
            i++;
            repeat++;
        }
        //Debug.Log(llave+" Guardado");
        if(repeat>=repeatquantity){
            repeatquantity=repeat;
        }
        //Debug.Log(repeatquantity);
        almacen[llave]=newkeyCode;
    }

    public T Buscar(string keyCode){
        keyCode=keyCode.ToLower();
        int repeat=0;
        int b=GenerateKey(keyCode);
        int h1=b%101;
        int c1=0;
        int c2=1;
        int i=0;
        int llave=h1;
        Debug.Log("Llave"+llave);
        
        if(almacen[llave] != null){
            //Debug.Log("Entra");
            while(almacen[llave] != null &&(almacen[llave].keyCode != keyCode)){
                llave=(h1+c1*i+c2*i*i)%103;
                i++;
                repeat++;
            }
            if(repeat>= repeatquantity){
                T encontrado = almacen[llave].objeto;
                return encontrado;
            }else{
                return default(T);
            }
        }else{
            return default(T);
        }
    }
    int GenerateKey(string keyCode){
        
        char[] codigo = new char[keyCode.Length];
        codigo = keyCode.ToCharArray();
        int valueCode=keyCode.Length;
        int a=0;
        int b=0;
        for (int  k= 0; k < codigo.Length; k++)
        {
            for (int j = 0; j < characterCode.Length; j++)
            {
                if(codigo[k]==characterCode[j]){
                    a=j;
                    break;
                }
            }
            int tmp=1;
            for (int j = 0; j < valueCode-1; j++)
            {
                tmp=tmp*26;
            }
            b= b+ a*tmp;
            valueCode--;
        }
        return b;
    }
    public void PrintAllDate()
        {
            for(int i = 0; i < almacen.Length; i++)
            {
                if(almacen[i] != null)
                {
                    Debug.Log("En la posicion " + i + " guarda el codigo: " + almacen[i].keyCode);
                }
            }
        }
}
