using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] float moveSpeed = 0.5f;
    Material material;
    Vector2 offset;
    void Start()
    {
        material = GetComponent<Renderer>().material;
        offset = new Vector2(0f, moveSpeed * Time.deltaTime);

    }

    void Update()
    {
        material.mainTextureOffset += offset;
    }
}
