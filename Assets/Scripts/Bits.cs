using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Bits : MonoBehaviour
{
    public TextMeshProUGUI bitText;
    public static float bits;
    public static float maxBits;

    // Start is called before the first frame update
    void Start()
    {
        maxBits = 0;
        bits = 0;
    }

    // Update is called once per frame
    void Update()
    {
        bitText.text = "BITS: " + Mathf.Round(bits);

        if (bits > maxBits)
        {
            maxBits = bits;

        }
    }
}
