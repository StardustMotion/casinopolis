using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureScroller : MonoBehaviour
{
    static float NeonHorizontal = -3.0f;
    static int NeonHorizontalTics = 8;
    static float RedLightGate = 3.0f; // also take care of blue light ; also in playplaces
    static int RedLightGateTics = 8;

    float u,v;
    float scrollSpeed; int ticsSpeed; int tic = 0;
    public int type;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer> ();
        if (type == 1) { scrollSpeed = NeonHorizontal; ticsSpeed = NeonHorizontalTics; u = 1.0f; v = 0.0f; }
        else if (type == 2) { scrollSpeed = RedLightGate; ticsSpeed = RedLightGateTics; v = 1.0f; u=0.0f; }
        else if (type == 3) { scrollSpeed = RedLightGate; ticsSpeed = RedLightGateTics; v = 0.0f; u=1.0f; }
    }

    void Update()
    {
        if (tic == 0) {
            float offset = Time.time * scrollSpeed;
            rend.material.SetTextureOffset("_MainTex", new Vector2(offset * u, offset * v));
            rend.material.SetTextureOffset("_EmissionMap", new Vector2(offset * u, offset * v));
            tic = ticsSpeed;
        }
        else { tic--; }
    }
}
