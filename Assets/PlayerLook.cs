using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerLook : MonoBehaviour
{
    [SerializeField] private float m_damping = 1f;
    [SerializeField] private float m_lookSenitivity = 2.5f;
    [SerializeField] private VariableJoystick m_variableJoystick;

    private float xRotation;
    private float yRotation;
    private float xRotationV;
    private float yRotationV;
    private float currentXRotation;
    private float currentYRotation;

    private void Start()
    {
        m_variableJoystick.OnPress += Press;
        m_variableJoystick.OnRelease += Released;

    }

    private void OnDestroy()
    {
        m_variableJoystick.OnPress -= Press;
        m_variableJoystick.OnRelease -= Released;
    }


    void FixedUpdate()
    {
        //FirstAttempt();

        xRotation += (m_variableJoystick.Vertical * -1) * m_lookSenitivity;
        yRotation += m_variableJoystick.Horizontal * m_lookSenitivity;

            xRotation = Mathf.Clamp(xRotation, -90, 90);

            currentXRotation = Mathf.SmoothDamp(currentXRotation, xRotation, ref xRotationV, m_damping);
            currentYRotation = Mathf.SmoothDamp(currentYRotation, yRotation, ref yRotationV, m_damping);

            transform.rotation = Quaternion.Euler(xRotation, yRotation, 0f);
    }

    private void FirstAttempt()
    {
        var rot = Camera.main.transform.rotation;
        Camera.main.transform.Rotate(
            rot.x + m_variableJoystick.Vertical,
            rot.y + m_variableJoystick.Horizontal,
            rot.z
        );
    }

    private void Press(PointerEventData eventData)
    {
        Debug.Log("PRESS!");    
        Debug.Log(eventData.position); 
    }

    private void Released(PointerEventData eventData)
    {
        Debug.Log(eventData.position); 
        Debug.Log("Released!");
    }
}
