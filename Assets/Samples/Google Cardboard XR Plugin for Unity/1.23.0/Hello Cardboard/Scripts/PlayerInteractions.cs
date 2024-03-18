using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{

    private int distanceOfRaycast = 10;
    
    private RaycastHit _hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));

        if (Physics.Raycast(ray, out _hit, distanceOfRaycast))
        {

            if (Input.GetButtonDown("Fire1") && _hit.transform.CompareTag("Rotatable"))
            {

                _hit.transform.gameObject.GetComponent<RotateObject>().ChangeSpin();

            }

            if (Input.GetButtonDown("Fire1") && _hit.transform.CompareTag("ShowHideTrigger"))
            {

                _hit.transform.gameObject.GetComponent<ShowHideObject>().ChangeActive();

            }

            if (Input.GetButton("Fire1") && _hit.transform.CompareTag("TeleportSpot"))
            {

                Debug.Log(_hit.transform.position);

                GameObject.FindWithTag("Player").transform.position = _hit.transform.position;

            }

        }

    }
}
