using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GazeObject : ObjectController
{

    public float totalTime = 2;

    public float timer;

    public UnityEvent activate;

    public GameObject gameObjectToActivate;

    private bool gazeStatus;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if (gazeStatus)
        {

            timer += Time.deltaTime;

        }

        if (timer > totalTime)
        {

            activate.Invoke();

        }

    }

    public void OnPointerEnter()
    {

        gazeStatus = true;

    }

    public void OnPointerExit()
    {

        gazeStatus = false;

        timer = 0;

    }
}
