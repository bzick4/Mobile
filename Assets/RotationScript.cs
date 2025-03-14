using System;
using UnityEngine;
// using UnityEngine.InputSystem;
//using UnityEngine.InputSystem.EnhancedTouch;

public class PinchZoom : MonoBehaviour
{
    public Camera camera;
    public float minZoom = 2f;
    public float maxZoom = 10f;

    private float rotationSpeed = 180f;
    private Vector2 _startTouchPosition, _currentTouchPosition;
    private Vector2 _touchStartPos1, _touchStartPos2;
    private float _initialDistance;
    private float pinchZoomSpeed = 0.1f;


    // private void OnEnable()
    // {
    //     EnhancedTouchSupport.Enable(); // Включаем систему тач-ввода

    // }

    // private void OnDisable()
    // {
    //     EnhancedTouchSupport.Disable();
    //     TouchSimulation.Disable();
    // }

    // private void Update()
    // {
    //     var activeTouches = UnityEngine.InputSystem.EnhancedTouch.Touch.activeTouches;

    //     if (activeTouches.Count == 2)
    //     {
    //         Touch touch1 = activeTouches[0];
    //         Touch touch2 = activeTouches[1];

    //         float prevDistance = (touch1.startScreenPosition - touch2.startScreenPosition).magnitude;
    //         float currentDistance = (touch1.screenPosition - touch2.screenPosition).magnitude;

    //         float difference = currentDistance - prevDistance;

    //         float newSize = camera.fieldOfView - difference * zoomSpeed;
    //        camera.fieldOfView = Mathf.Clamp(camera.fieldOfView - difference * zoomSpeed, minZoom, maxZoom);
    //     }
    // }


    void Update()
    {
        if(Input.touchCount>0)
        {
            SwipeRotateCube();
            SwipeZoom();
        }
    }

    private void SwipeRotateCube()
    {
        Touch _touch = Input.GetTouch(0);
        Vector2 swipeDelta = _currentTouchPosition -_startTouchPosition;
    

        if(_touch.phase == TouchPhase.Began)
        {
           _startTouchPosition = _touch.position;
        }

        if(_touch.phase == TouchPhase.Moved)
        {
            _currentTouchPosition = _touch.position;

               if(Mathf.Abs(swipeDelta.x) > Mathf.Abs(swipeDelta.y))
               {
                if(swipeDelta.x >= 100)
                transform.Rotate(Vector2.up * rotationSpeed * -Time.deltaTime);
                else
                transform.Rotate(Vector2.up * rotationSpeed * Time.deltaTime);
               }

               if(Mathf.Abs(swipeDelta.x) < Mathf.Abs(swipeDelta.y))
               {
                if(swipeDelta.y <= 50)
                transform.Rotate(Vector2.right * rotationSpeed * -Time.deltaTime);
                else
                transform.Rotate(Vector2.right * rotationSpeed * Time.deltaTime);
               }
        }

        
    }

private void SwipeZoom()
{
    if(Input.touchCount == 2)
    {
        Touch touch1 = Input.GetTouch(0);
        Touch touch2 = Input.GetTouch(1);

       if (touch1.phase == TouchPhase.Began || touch2.phase == TouchPhase.Began)
            {
                _touchStartPos1 = touch1.position;
                _touchStartPos2 = touch2.position;
                _initialDistance = Vector2.Distance(_touchStartPos1, _touchStartPos2);
            }
            else if (touch1.phase == TouchPhase.Moved || touch2.phase == TouchPhase.Moved)
            {
                float currentDistance = Vector2.Distance(touch1.position, touch2.position);
                float pinchAmount = currentDistance - _initialDistance;
                
                if (Mathf.Abs(pinchAmount) > pinchZoomSpeed)
                {
                    if (pinchAmount > 0)
                    {
                        Debug.Log($"pich {pinchAmount}");
                        Camera.main.fieldOfView = maxZoom;
                    }
                    else
                    {
                        Debug.Log($"pich {pinchAmount}");
                        Camera.main.fieldOfView = minZoom;
                    }

                    _initialDistance = currentDistance;
                }

            }
            else if (touch1.phase == TouchPhase.Ended || touch2.phase == TouchPhase.Ended)
            {
                Camera.main.fieldOfView = 100;
            }
    }
}
}
