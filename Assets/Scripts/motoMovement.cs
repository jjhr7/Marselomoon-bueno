using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class motoMovement : MonoBehaviour
{
    public GameObject[] contactoSuelo;
    public float gravityForce = 12f;
    public float alturaMuelle = 0.65f;
    Rigidbody body;
    int layerMask;
    float avance;
    public float coefAvance = 5.0f;
    float giro;
    public float coefGiro = 2.0f;

    void Start()
    {
        body = this.GetComponent<Rigidbody>();
        layerMask = 1 << LayerMask.NameToLayer("Vehicle");
        layerMask = ~layerMask;
        body.centerOfMass = new Vector3(0, -0.5f, 0);
    }
    private void FixedUpdate()
    {
        RaycastHit hit;
        for (int i = 0; i < contactoSuelo.Length; i++)
        {
            if (Physics.Raycast(contactoSuelo[i].transform.position, -Vector3.up, out hit, alturaMuelle, layerMask))
            {
                body.AddForceAtPosition(contactoSuelo[i].transform.up * gravityForce * (((alturaMuelle - hit.distance) / alturaMuelle)), contactoSuelo[i].transform.position);
                contactoSuelo[i].GetComponent<LineRenderer>().SetPosition(0, contactoSuelo[i].transform.position);
                contactoSuelo[i].GetComponent<LineRenderer>().SetPosition(1, hit.transform.position);
            }
            else
            {
                body.AddForceAtPosition(contactoSuelo[i].transform.up * -gravityForce, contactoSuelo[i].transform.position);
            }
        }
        body.AddForce(transform.forward * avance * coefAvance);
        body.AddRelativeTorque(Vector3.up * giro * coefGiro);


    }

    private void Update()
    {
        Gamepad gamepad = Gamepad.current;
        if (gamepad == null)
            return; // No gamepad connected.
        Vector2 move = gamepad.rightStick.ReadValue();
        Vector2 move2 = gamepad.leftStick.ReadValue();

        avance = move.y * coefAvance;
        giro = move2.x * coefGiro;
    }

    void OnDrawGizmos()
    {
        RaycastHit hit;
        for (int i = 0; i < contactoSuelo.Length; i++)
        {
            if (Physics.Raycast(contactoSuelo[i].transform.position, -Vector3.up, out hit, alturaMuelle, layerMask))
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawLine(contactoSuelo[i].transform.position, hit.point);
                Gizmos.DrawSphere(hit.point, 0.05f);
            }
            else
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(contactoSuelo[i].transform.position, contactoSuelo[i].transform.position - Vector3.up * alturaMuelle);
            }
        }
    }

    public void tomas_turbin()
    {

    }

    public void resetCar()
    {
        body.transform.position = new Vector3(0, 1, 0);
        body.transform.rotation = Quaternion.identity;
    }
}
