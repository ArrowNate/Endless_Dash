using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private Material background;
    [SerializeField] private float scrollSpeed = 0.1f;

    private void Start()
    {
        background.mainTexture.wrapMode = TextureWrapMode.Repeat;
    }

    // Update is called once per frame
    void Update()
    {
        float offset = Time.time * scrollSpeed;
        background.SetTextureOffset("_MainTex", new Vector2(offset, 0.0f));
    }
}