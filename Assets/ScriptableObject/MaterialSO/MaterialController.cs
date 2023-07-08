using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[CreateAssetMenu(fileName = "MaterialController", menuName = "ScriptableObjects/MaterialController", order = 0)]
public class MaterialController : ScriptableObject
{
    [SerializeField] private Material material;
    [SerializeField] private Color[] emissionsColors;
    
    public void ChangeEmissionColor(MaterialChange typeChange){
        switch (typeChange)
        {
            case MaterialChange.OnGoOut:
            material.SetColor("_EmissionColor", emissionsColors[0]);
            material.SetColor("_Color", emissionsColors[0]);
            break;
            case MaterialChange.OnEntry:
            material.SetColor("_EmissionColor", emissionsColors[1]);
            material.SetColor("_Color", emissionsColors[1]);
            break;
            case MaterialChange.Onhit:
            material.SetColor("_EmissionColor", emissionsColors[2]);
            material.SetColor("_Color", emissionsColors[2]);
            break;
            default:
            material.SetColor("_EmissionColor", emissionsColors[3]);
            material.SetColor("_Color", emissionsColors[3]);
            break;
        }
    }
}
public enum MaterialChange
{
    Normal,OnGoOut, OnEntry, Onhit
}

