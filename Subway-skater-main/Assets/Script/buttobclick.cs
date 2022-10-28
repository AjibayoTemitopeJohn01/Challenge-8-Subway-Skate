using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class buttobclick : MonoBehaviour
{
    public Button btn;


    public InputField field;
    public Text myText;

    List<string> texts ;
    // Start is called before the first frame update
    void Start()
    {

        
       
        btn.onClick.AddListener(GetInput);

    }

    string display = "";
    private void GetInput()
    {
       
        display = field.text +" \n";
        
        myText.text += display;   
    }

    
}
