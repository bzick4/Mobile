
using UnityEngine;

public class MovementHandler : MonoBehaviour
{
    [SerializeField] private MoveScript _moveScript;
    [SerializeField] private float _BallSpeed;
    

    // private void Awake()
    // {
        
    // }
    void Start()
    {
    
      if(_moveScript== null)
      Debug.Log("Input Ne naiden");  
    }

    private void MoveBall()
    {
        if(_moveScript.IsThereTouch())
        {
        Vector2 _currDelPos = _moveScript.GetTouchDelta();
        _currDelPos = _currDelPos * _BallSpeed;
        Vector3 _newGravityVector = new Vector3(_currDelPos.x, Physics.gravity.y, _currDelPos.y);
        Physics.gravity = _newGravityVector;
        }
 
    }

    // Update is called once per frame
    void Update()
    {
        MoveBall();
    }
}
