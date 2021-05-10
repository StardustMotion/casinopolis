using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinMeRightRound : MonoBehaviour
{
    public float xSpin, ySpin, zSpin;
    public bool worldValue;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      if (worldValue) { transform.Rotate(xSpin, ySpin, zSpin, Space.World); }
      else { transform.Rotate(xSpin, ySpin, zSpin); }
    }
}
