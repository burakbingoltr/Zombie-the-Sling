using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SlingShotHandler : MonoBehaviour
{

    [SerializeField] private LineRenderer _LeftLineRenderer;
    [SerializeField] private LineRenderer _RightLineRenderer;


    [SerializeField] private Transform _leftStartPosition;
    [SerializeField] private Transform _RightStartPosition;
    [SerializeField] private Transform _CenterPosition;
    [SerializeField] private Transform _IdlePosition;


    [SerializeField] private float _MaxDistance = 3.5f;

    private Vector2 _SlingShotPosition;

    void Start()
    {

    } // Start End Here

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            DrawSlingShot();
        }
        else
        {
            return;
        }
    }   //Update End Here

    private void DrawSlingShot()
    {
        Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        _SlingShotPosition = _CenterPosition.position + Vector3.ClampMagnitude(touchPosition - _CenterPosition.position, _MaxDistance);

        SetLines(_SlingShotPosition);


    }

    private void SetLines(Vector2 position)
    {
        _LeftLineRenderer.SetPosition(0, position);
        _LeftLineRenderer.SetPosition(1, _leftStartPosition.position);

        _RightLineRenderer.SetPosition(0, position);
        _RightLineRenderer.SetPosition(1, _RightStartPosition.position);
    }
}

