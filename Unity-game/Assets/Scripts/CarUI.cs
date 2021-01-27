using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CarUI : MonoBehaviour
{
    GameObject text;
    GameObject s_text;
    GameObject fast_lap;
    Text lap_time_text;
    Text speed_text;
    Text fast_lap_text;

    CheckpointCheck check_point_check;
    UnityStandardAssets.Vehicles.Car.CarController car_controller;

    GameObject car_variant;

    public float lap_time;
    public float current_speed;
    public float fastest_lap = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        car_variant = transform.parent.gameObject;
        text = GameObject.Find("LapTimeText");
        s_text = GameObject.Find("SpeedText");
        fast_lap = GameObject.Find("FastLapText");

        lap_time_text = text.GetComponent<Text>();
        speed_text = s_text.GetComponent<Text>();
        fast_lap_text = fast_lap.GetComponent<Text>();
        check_point_check = car_variant.GetComponent<CheckpointCheck>();
        car_controller = car_variant.GetComponent<UnityStandardAssets.Vehicles.Car.CarController>();

        current_speed = car_controller.CurrentSpeed;
        speed_text.text = current_speed.ToString();

        lap_time = check_point_check.lap_time;
        lap_time_text.text = "LAP TIME: ";

        fastest_lap = check_point_check.fast_lap;
        fast_lap_text.text = "FAST LAP: ";
    }

    // Update is called once per frame
    void Update()
    {
        lap_time = check_point_check.lap_time;
        lap_time_text.text = "LAP TIME: " + lap_time.ToString("f2");

        current_speed = car_controller.CurrentSpeed;
        speed_text.text = ((int)current_speed).ToString() + " km/h";

        fastest_lap = check_point_check.fast_lap;
        fast_lap_text.text = "FAST LAP: " + fastest_lap.ToString("f2");
    }
}
