using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class planet_slector : MonoBehaviour
{
    public string pln_name = "";
    public Text txt;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        txt.text = "Selected object: " + pln_name;
    }
}
