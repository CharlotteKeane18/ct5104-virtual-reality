//-----------------------------------------------------------------------
// <copyright file="CameraPointer.cs" company="Google LLC">
// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using UnityEngine;

/// <summary>
/// Sends messages to gazed GameObject.
/// </summary>
public class CameraPointer : MonoBehaviour
{
    private const float _maxDistance = 20;
    private GameObject _gazedAtObject = null;

    private RaycastHit _hit;

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    public void Update()
    {

        Ray ray = Camera.main.ViewportPointToRay( new Vector3( 0.5f, 0.5f, 0f ) );

        if( Physics.Raycast( ray, out _hit, _maxDistance ) )
        {

            if( Input.GetButton( "Fire1" ) && _hit.transform.CompareTag( "Rotatable" ) )
            {

                _hit.transform.gameObject.GetComponent<RotateObject>().ChangeSpin();

            }

        }

        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance))
        {
            // GameObject detected in front of the camera.
            if (_gazedAtObject != hit.transform.gameObject)
            {
                // New GameObject.
                _gazedAtObject = hit.transform.gameObject;

                print( _gazedAtObject.name );
            }
        }
        else
        {
            // No GameObject detected in front of the camera.
            _gazedAtObject = null;
        }

        // Checks for screen touches.
        if (Google.XR.Cardboard.Api.IsTriggerPressed)
        {

        }

    }

}
