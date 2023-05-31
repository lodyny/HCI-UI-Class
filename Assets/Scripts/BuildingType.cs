using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBuildingType", menuName = "Building Type")]
public class BuildingType : ScriptableObject
{
    public string BuildingName;
    public int[] Costs;
    

    public void Teste()
    {
        Debug.Log("Okey");
    }
}
