using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarUI : MonoBehaviour
{
    GameObject text;
    Text lap_time_text;

    CheckpointCheck check_point_check;

    GameObject car_variant;

    public float lap_time;

    // Start is called before the first frame update
    void Start()
    {
        car_variant = GameObject.Find("Car Variant");
        text = GameObject.Find("LapTimeText");
        lap_time_text = text.GetComponent<Text>();
        check_point_check = car_variant.GetComponent<CheckpointCheck>();
        lap_time = check_point_check.lap_time;
        lap_time_text.text = "LAP TIME: ";
    }

    // Update is called once per frame
    void Update()
    {
        lap_time = check_point_check.lap_time;
        lap_time_text.text = "LAP TIME: " + lap_time.ToString();
    }
}
