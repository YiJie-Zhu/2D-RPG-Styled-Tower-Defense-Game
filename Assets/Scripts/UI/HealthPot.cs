using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HealthPot : MonoBehaviour
{
    public static int numPot;
    private TextMeshProUGUI potText;
    public static float heal = 20f;
   
    // Start is called before the first frame update
    void Start()
    {
        potText = GetComponent<TextMeshProUGUI>();
        numPot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        potText.text = numPot.ToString();
    }
}
