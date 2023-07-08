using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SaveTropas", menuName = "ScriptableObjects/SaveTropas", order = 0)]
public class SaveTropas : ScriptableObject
{
    int faseSelecction = 1;
    MyQueue<Unid> myCola /*= new MyQueue<Unid>()*/;
    public List<Unid> prueba2;
    
    public void SaveTropasQueque(SimplyLinkList<Unid> list){
        myCola = new MyQueue<Unid>();
        prueba2= new List<Unid>();
        for (int i = 0; i < list.Count; i++)
        {
            prueba2.Add(list.GetNodeAtPosition(i));
            myCola.Enqueue(list.GetNodeAtPosition(i));
        }
    }
    public Unid ReturmTropas(){
        if(myCola.Count>0){
            return myCola.Dequeue();
        }else{
            return default(Unid);
        }
    }
}