using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CarUI : MonoBehaviour
{
    GameObject text;
    GameObject s_text;
    GameObject finish;

    Text lap_time_text;
    Text speed_text;

    CheckpointCheck check_point_check;
    UnityStandardAssets.Vehicles.Car.CarController car_controller;
    UnityStandardAssets.Vehicles.Car.CarUserControl car_user_control;

    GameObject car_variant;

    public float lap_time;
    public float current_speed;
    public bool victory;

    Rigidbody car_body;

    // Start is called before the first frame update
    void Start()
    {
        car_variant = GameObject.FindGameObjectWithTag("Player");
        text = GameObject.Find("LapTimeText");
        s_text = GameObject.Find("SpeedText");
        finish = GameObject.Find("FinalText");

        car_body = car_variant.GetComponent<Rigidbody>();

        finish.SetActive(false);

        lap_time_text = text.GetComponent<Text>();
        speed_text = s_text.GetComponent<Text>();

        check_point_check = car_variant.GetComponent<CheckpointCheck>();
        car_controller = car_variant.GetComponent<UnityStandardAssets.Vehicles.Car.CarController>();
        car_user_control = car_variant.GetComponent<UnityStandardAssets.Vehicles.Car.CarUserControl>();

        current_speed = car_controller.CurrentSpeed;
        speed_text.text = current_speed.ToString();

        lap_time = check_point_check.lap_time;
        lap_time_text.text = "LAP TIME: ";

        victory = check_point_check.victory;
    }

    // Update is called once per frame
    void Update()
    {
        lap_time = check_point_check.lap_time;
        lap_time_text.text = "LAP TIME: " + lap_time.ToString("f2") + " s";

        current_speed = car_controller.CurrentSpeed;
        speed_text.text = ((int)current_speed).ToString() + " km/h";

        victory = check_point_check.victory;

        if(victory == true)
        {
            finish.SetActive(true);
            text.SetActive(false);
            s_text.SetActive(false);
            car_controller.enabled = false;
            car_user_control.enabled = false;
            car_body.velocity = car_body.velocity * 0.99f;
        }
    }
}
