using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartAppScript : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void StartAppPress() 
    {
        SceneManager.LoadScene("SampleScene");
    }
}
