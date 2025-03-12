using System;
using System.Collections;
using UnityEngine;

public class RotationScript : MonoBehaviour
{

    [SerializeField] private float _ZoomMax, _ZoomMin;

    private float rotationSpeed = 180f;
     private Vector2 _startTouchPosition, _currentTouchPosition;



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
    if(Input.touchCount ==2)
    {
        Touch _touchZero = Input.GetTouch(0);
        Touch _touchOne = Input.GetTouch(1);

        Vector2 _touchZeroPos = _touchZero.position - _touchZero.deltaPosition;
        Vector2 _touchOnePos = _touchOne.position - _touchOne.deltaPosition;

        float _distouch = (_touchZeroPos - _touchOnePos).magnitude;
        float _currrentDisTouch = (_touchZero.position - _touchOne.position).magnitude;

        float _difference = _currrentDisTouch - _distouch;

        Zoom(_difference * 0.1f);
    
    }
}

private void Zoom(float increment)
{
    Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize-increment, _ZoomMin, _ZoomMax);
}

}
