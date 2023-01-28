using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class DropdownController : MonoBehaviour
{
    [SerializeField]
    TMP_Dropdown dp;
    void Start()
    {
        dp.ClearOptions();
        List<TMP_Dropdown.OptionData> list = new List<TMP_Dropdown.OptionData>();
        for (int i = 0; i < Enum.GetValues(typeof(DropdownValues)).Length; i++)
        {
            TMPro.TMP_Dropdown.OptionData data = new TMP_Dropdown.OptionData();
            data.text = ((DropdownValues)i).ToString();
            list.Add(data);
        }
        dp.AddOptions(list);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public enum DropdownValues 
    {
        Pipe1=0,
        Pipe2=1,
        Pipe3=2,
        Pipe4=3
    }
}
