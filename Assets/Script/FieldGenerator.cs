using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldGenerator : MonoBehaviour
{
    public GameObject FieldUnit;

    private void Awake()
    {
        for (int k = 0; k < 10; k++)
        {
            for (int i = 0; i < 10; i++)
            {
                GameObject newFieldUnit = Instantiate(FieldUnit);
                newFieldUnit.transform.position = new Vector3(k, 0, i);
            }

        }
       
        
    }
}
