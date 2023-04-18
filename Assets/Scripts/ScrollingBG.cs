using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBG : MonoBehaviour
{
    [SerializeField] Vector2 moveSpeed;

    Vector2 offset;

    Material backgroundMaterial;

    void Awake()
    {
       backgroundMaterial = GetComponent<SpriteRenderer>().material; 
    }
    // Update is called once per frame
    void Update()
    {
        offset = moveSpeed * Time.deltaTime;
        backgroundMaterial.mainTextureOffset += offset;
    }
}
