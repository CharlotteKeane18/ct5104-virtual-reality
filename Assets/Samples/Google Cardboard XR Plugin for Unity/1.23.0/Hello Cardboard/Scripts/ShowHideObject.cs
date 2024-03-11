using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowHideObject : MonoBehaviour
{

    public GameObject objectToShowAndHide;

    private bool isShowHide = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

        // Update is called once per frame
    void Update()
    {

        if( isShowHide )
        {

            //if the boolean showhide is true - then do the following set of code

            objectToShowAndHide.SetActive(true);

        } else
        {

            //if the boolean showhide is false - then do the following set of code

            objectToShowAndHide.SetActive(false);

        }
        
    }

    public void ChangeActive()
    {

        isShowHide = !isShowHide;

    }

}
