using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundController : MonoBehaviour
{
    public float speed = 0.1f;
    public Renderer rend;
    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float y = Mathf.Repeat(Time.time * speed, 1);
        rend.material.mainTextureOffset = new Vector2(0, y);
    }
}
