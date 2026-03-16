using UnityEngine;
using UnityEngine.InputSystem;

public class PrometeoDynamicJoystick : MonoBehaviour
{
    private Vector2 ptA;
    private Vector2 ptB;
    private Vector2 offset;
    private Vector2 direction;
    private bool isTouched = false;
    [SerializeField] private Transform joystickCircle;
    [SerializeField] private Transform joystickOuterCircle;
    private SpriteRenderer joystickCircleSpriteRenderer;
    private SpriteRenderer joystickOuterCircleSpriteRenderer;

    private void Start()
    {
        joystickCircleSpriteRenderer = joystickCircle.GetComponent<SpriteRenderer>();
        joystickOuterCircleSpriteRenderer = joystickOuterCircle.GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Touchscreen.current.primaryTouch.press.wasPressedThisFrame)
        {
            ptA = Camera.main.ScreenToWorldPoint(new Vector3(Touchscreen.current.primaryTouch.position.ReadValue().x, Touchscreen.current.primaryTouch.position.ReadValue().y, Camera.main.transform.position.z));
            joystickCircle.position = ptA * (-1);
            joystickOuterCircle.position = ptA * (-1);
            joystickCircleSpriteRenderer.enabled = true;
            joystickOuterCircleSpriteRenderer.enabled = true;
        }

        if (Touchscreen.current.primaryTouch.press.isPressed)
        {
            isTouched = true;
            ptB = Camera.main.ScreenToWorldPoint(new Vector3(Touchscreen.current.primaryTouch.position.ReadValue().x, Touchscreen.current.primaryTouch.position.ReadValue().y, Camera.main.transform.position.z));
        }
        else
        {
            isTouched = false;
            joystickCircleSpriteRenderer.enabled = false;
            joystickOuterCircleSpriteRenderer.enabled = false;
        }
    }

    private void FixedUpdate()
    {
        if (isTouched)
        {
            offset = ptB - ptA;
            direction = Vector2.ClampMagnitude(offset, 1.0f);

            joystickCircle.position = new Vector3(ptA.x + direction.x, ptA.y + direction.y, joystickCircle.position.z);
        }
        
    }
}
