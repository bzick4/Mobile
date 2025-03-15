
using UnityEngine;

public class MoveScript : MonoBehaviour
{
    public Vector2 GetTouchDelta()
    {
        if(Input.touchCount>0)
        {
            return Input.GetTouch(0).deltaPosition;
        }
        return Vector2.zero;
    }

public bool IsThereTouch()
{
    if(Input.touchCount>0) {return true;}
    else {return false;}
}

private void Update()
{
    Debug.Log(GetTouchDelta());
    //Debug.Log(IsThereTouchOnScreen());
}
}