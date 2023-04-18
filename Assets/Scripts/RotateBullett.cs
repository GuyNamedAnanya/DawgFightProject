using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class RotateBullett : MonoBehaviour
{
    void Update()
    {
        transform.rotation = Quaternion.Euler(0, 0, 180);
    }


}
