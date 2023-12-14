using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    // speed variable and background renderer variable
    public float speed;
    [SerializeField]
    private Renderer bgRenderer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // In update we change the offset to make it look like its scrolling
    void Update()
    {
        bgRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0);
    }
}
