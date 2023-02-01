using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    public float MotorForce, SteerForce, BrakeForce;
    public WheelCollider Wheel_FR_L, Wheel_FR_R, RE_L, RE_R;

    // Update is called once per frame
    void Update()
    {
        //Pegando os gatilhos do teclado.
        float vertical = Input.GetAxis("Vertical") * MotorForce;
        float horizontal = Input.GetAxis("Horizontal") * SteerForce;

        RE_L.motorTorque = vertical;
        RE_R.motorTorque = vertical;

        Wheel_FR_L.steerAngle = horizontal;
        Wheel_FR_R.steerAngle = horizontal;

        // Freiar o carro.
        if(Input.GetKey(KeyCode.Space))
        {
            RE_L.brakeTorque = BrakeForce;
            RE_R.brakeTorque = BrakeForce;
            
        }// Zera a força do carro apos soltar o botão pressionado.
        else if(Input.GetKeyDown(KeyCode.Space))
        {
            RE_L.brakeTorque = 0;
            RE_R.brakeTorque = 0;
        }

        // Freia o carro se não estiver pressionando nenhuma tecla de aceleração(cima ou baixo).
        if(Input.GetAxis("Vertical") == 0)
        {
            RE_L.brakeTorque = BrakeForce;
            RE_R.brakeTorque = BrakeForce;
        }else
        {
            RE_L.brakeTorque = 0;
            RE_R.brakeTorque = 0;
        }
    }
}
