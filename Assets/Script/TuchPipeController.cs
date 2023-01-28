using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngineInternal;
using static UnityEngine.ParticleSystem;

public class TuchPipeController : MonoBehaviour
{
    [SerializeField]
    GameObject pipePrefab;
    [SerializeField]
    TMP_Dropdown dp;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                if (Physics.Raycast(ray,out RaycastHit hit))
                {
                    if (hit.transform.gameObject.tag=="Pipe")
                    {
                        Transform pipeLocation = hit.transform;
                        Color colorChoice = SetWantedColor();
                        if (hit.transform.rotation.x > 0)
                        {
                            Vector3 wantedSpawnLocation = new Vector3(pipeLocation.position.x, pipeLocation.position.y, pipeLocation.position.z + pipeLocation.localScale.y + pipePrefab.transform.localScale.y / 2);
                            GameObject copy = pipePrefab.gameObject;
                            copy.GetComponent<Renderer>().sharedMaterial = Instantiate(Resources.Load("Materials") as Material);
                            copy.GetComponent<Renderer>().sharedMaterial.color = colorChoice;
                            Instantiate(copy, wantedSpawnLocation, hit.transform.rotation);
                            Debug.Log("Rotacija je 90 stupnjeva");
                        }
                        else 
                        {
                            Vector3 wantedSpawnLocation = new Vector3(pipeLocation.position.x + pipeLocation.localScale.y+pipePrefab.transform.localScale.y/2, pipeLocation.position.y, pipeLocation.position.z);
                            Instantiate(pipePrefab, wantedSpawnLocation, hit.transform.rotation);
                            Debug.Log(hit.transform.rotation.x);
                        }
                        
                    }
                }
            }
        }
    }

    private Color SetWantedColor()
    {
        /*switch (dp.value)
        {
            case 0:
                pipePrefab.GetComponent<Renderer>().sharedMaterial.color = Color.red;
                break;
            case 1:
                pipePrefab.GetComponent<Renderer>().sharedMaterial.color = Color.blue;
                break;
            case 2:
                pipePrefab.GetComponent<Renderer>().sharedMaterial.color = Color.yellow;
                break;
            case 3:
                pipePrefab.GetComponent<Renderer>().sharedMaterial.color = Color.green;
                break;
        }*/

        switch (dp.value)
        {
            case 0:
                return Color.red;
            case 1:
                return Color.blue;
            case 2:
                return Color.yellow;
            case 3:
                return Color.green;
        }
        return Color.white;
    }
}
