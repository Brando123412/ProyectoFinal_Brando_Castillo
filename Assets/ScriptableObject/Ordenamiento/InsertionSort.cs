using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ordenamiento", menuName = "ScriptableObjects/Ordenamiento", order = 0)]
public class InsertionSort : ScriptableObject
{
    int[] puntajes = new int[10];
    public int j=0;
    public void SavePuntaje(int puntajeValue){
        if(j < 10){
            for (int i = 0; i < puntajes.Length; i++)
            {
                if(puntajes[i] == 0){
                    puntajes[i]=puntajeValue;
                    break;
                }
                j++;
            } 
        }else{
            if(puntajeValue>puntajes[0]){
                puntajes[0]=puntajeValue;
            }
            j=10;
        }
        InsertionSortOrder();
    }
    void InsertionSortOrder(){
        int tmp;
        for(int i =1; i< puntajes.Length;i++){
            tmp = puntajes[i];
            int j = i-1;
            while(j >= 0 && puntajes[j]>tmp){
                puntajes[j + 1] = puntajes[j];
                j--;
            }
            puntajes[j+1]=tmp;
        }
    }
    public int[] ReturmArray(){
        return puntajes;
    }
}
