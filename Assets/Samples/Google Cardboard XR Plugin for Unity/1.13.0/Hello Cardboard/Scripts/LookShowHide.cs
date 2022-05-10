using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookShowHide : MonoBehaviour
{

    private const float _maxDistance = 20;

    private RaycastHit _hit;

    public string nameOfGameObjectToShowHide;

    public bool isInvisibleOnStart;

    
    GameObject oldObject;

    // Start is called before the first frame update
    void Start()
    {

        oldObject = new GameObject();

        oldObject.AddComponent<UnityEngine.MeshRenderer>();
        
        if( isInvisibleOnStart )
        {

            this.GetComponent<MeshRenderer>().enabled = false;

        }
        
    }


    // Update is called once per frame
    void Update()
    {

        Ray ray = Camera.main.ViewportPointToRay( new Vector3( 0.5f, 0.5f, 0f ) );
        

        if( Physics.Raycast( ray, out _hit, _maxDistance ) )
        {

            GameObject o = _hit.transform.gameObject;

            if( o.name == nameOfGameObjectToShowHide )
            {

                
                if ( isInvisibleOnStart ) {

                    o.GetComponent<MeshRenderer>().enabled = true;

                } else {
                    
                    o.GetComponent<MeshRenderer>().enabled = false;

                }



                oldObject = o;

            } else {


                if ( isInvisibleOnStart ) {

                    oldObject.GetComponent<MeshRenderer>().enabled = false;

                } else {
                    
                    oldObject.GetComponent<MeshRenderer>().enabled = true;
                    
                }
                

                //oldObject = null;

            }

        }

    }
}
