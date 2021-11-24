using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RaycastSelection : MonoBehaviour
{
    public float rayLength;
    public LayerMask layermask;

    public GameObject textDisplay;
    public int secondsLeft = 5;
    public bool takingAway = false;

    void Start()
    {
        textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
    }

    private void Update()
    {     
        if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {   

            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray,out hit, rayLength, layermask))
            {                
        
                if (hit.transform.name == "Cube_1")
                {
                    if(takingAway == false && secondsLeft > 0)
                    {
                        StartCoroutine(TimerTake());
                        
                    }
                    Debug.Log(hit.collider.name);
                    SceneManager.LoadScene("Scene1 1");             

                }

                if (hit.transform.name == "Cube_2")
                {
                    Debug.Log(hit.collider.name);
                    SceneManager.LoadScene("Scene1 2");
                }

                if (hit.transform.name == "Sphere_3")
                {
                    Debug.Log(hit.collider.name);
                    SceneManager.LoadScene("Scene1 3");
                    
                }   
            }
        }
    }

    IEnumerator TimerTake()
    {
        takingAway = true;
        yield return new WaitForSeconds(1);
        secondsLeft -= 1;
        if(secondsLeft < 10)
        {
            textDisplay.GetComponent<Text>().text = "00:0" + secondsLeft;
        }
        else
        {
             textDisplay.GetComponent<Text>().text = "00:" + secondsLeft;
        }
        takingAway = false;       
    }
}