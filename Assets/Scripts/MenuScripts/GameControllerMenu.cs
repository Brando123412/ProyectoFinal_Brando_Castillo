using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameControllerMenu : MonoBehaviour
{
    [SerializeField] TMP_Text[] textScore;
    [SerializeField] InsertionSort SOCore;
    int[] curretValue;
    void Awake(){
        curretValue=SOCore.ReturmArray();
    }
    void Start()
    {
        for (int i = curretValue.Length-1; i >=0; i--)
        {
            textScore[i].text = curretValue[i].ToString();
        }
    }
    
}
