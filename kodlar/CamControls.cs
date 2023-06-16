using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControls : MonoBehaviour
{
    [SerializeField] private Transform dalib;
    
    
    private void Update()
    {
        transform.position = new Vector3(dalib.position.x, dalib.position.y, transform.position.z);
    }
}
