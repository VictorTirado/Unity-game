using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarUI : MonoBehaviour
{
    GameObject text;
    GameObject s_text;
    Text lap_time_text;
    Text speed_text;

    CheckpointCheck check_point_check;
    UnityStandardAssets.Vehicles.Car.CarController car_controller;

    GameObject car_variant;

    public float lap_time;
    public float current_speed;

    // Start is called before the first frame update
    void Start()
    {
        car_variant = GameObject.Find("Car Variant");
        text = GameObject.Find("LapTimeText");
        s_text = GameObject.Find("SpeedText");

        lap_time_text = text.GetComponent<Text>();
        speed_text = s_text.GetComponent<Text>();
        check_point_check = car_variant.GetComponent<CheckpointCheck>();
        car_controller = car_variant.GetComponent<UnityStandardAssets.Vehicles.Car.CarController>();

        current_speed = car_controller.CurrentSpeed;
        speed_text.text = current_speed.ToString();

        lap_time = check_point_check.lap_time;
        lap_time_text.text = "LAP TIME: ";
    }

    // Update is called once per frame
    void Update()
    {
        lap_time = check_point_check.lap_time;
        lap_time_text.text = "LAP TIME: " + lap_time.ToString();

        current_speed = car_controller.CurrentSpeed;
        speed_text.text = ((int)current_speed).ToString() + " km/h";
    }
}
