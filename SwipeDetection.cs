using System;
using UnityEngine;

public class SwipeDetection : MonoBehaviour
{
    public Action<Vector2> SwipeEvent;

    private Rigidbody2D _rigidbody;
    private Vector2 _tapPosition;
    private Vector2 _swipeDelta;

    private float _threshhold = 10;
    private float _speed = 200;

    private bool _isSwiping;
    private bool _isMobile;

    void Start()
    {
        _isMobile = Application.isMobilePlatform;

        _rigidbody = GetComponent<Rigidbody2D>();
        SwipeEvent += OnSwipe;
    }

    void Update()
    {
        if (!_isMobile)
        {
            MouseInput();
        }
        else
        {
            MobileInput();
        }

        CheckSwipe();
    }

    private void CheckSwipe()
    {
        _swipeDelta = Vector2.zero;

        if (_isSwiping)
        {
            if (!_isMobile && Input.GetMouseButton(0))
                _swipeDelta = (Vector2)Input.mousePosition - _tapPosition;
            else if (Input.touchCount > 0)
                _swipeDelta = Input.GetTouch(0).position - _tapPosition;
        }

        if (_swipeDelta.magnitude > _threshhold)
        {
            
            if (Mathf.Abs(_swipeDelta.x) > Mathf.Abs(_swipeDelta.y))
               SwipeEvent?.Invoke(_swipeDelta.x > 0 ? Vector2.right : Vector2.left);
            else
               SwipeEvent?.Invoke(_swipeDelta.y > 0 ? Vector2.up : Vector2.down);
            
            ResetSwipe();
        }
    }

    private void ResetSwipe()
    {
        _isSwiping = false;
        _tapPosition = Vector2.zero;
        _swipeDelta = Vector2.zero;
    }

    private void OnSwipe(Vector2 direction)
    {
        var dir = direction;
        _rigidbody.AddForce(dir * _speed);
    }

    private void MobileInput()
    {
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                _isSwiping = true;
                _tapPosition = Input.GetTouch(0).position;
            }
            else if (Input.GetTouch(0).phase == TouchPhase.Canceled || Input.GetTouch(0).phase == TouchPhase.Ended)
            {
                ResetSwipe();
            }
        }
    }

    private void MouseInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isSwiping = true;
            _tapPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButtonUp(0))
            ResetSwipe();
    }
}
