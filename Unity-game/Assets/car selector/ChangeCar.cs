using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeCar : MonoBehaviour
{
    public GameObject[] Cars;
    public int selectedCar = 0;
    public string car_name = "";

    private void Awake()
    {
        DontDestroyOnLoad(this);
    }
    public void NextCar()
    {
       
        Cars[selectedCar].SetActive(false);
        selectedCar = (selectedCar + 1) % Cars.Length;
        Cars[selectedCar].SetActive(true);
       
    }
    public void PreviousCar()
    {
       
        Cars[selectedCar].SetActive(false);
        selectedCar--;
        if(selectedCar < 0)
        {
            selectedCar += Cars.Length;
        }
        Cars[selectedCar].SetActive(true);
        
    }


    public void SelectCar()
    {

        car_name = Cars[selectedCar].name;
        Debug.Log(car_name);
        SceneManager.LoadScene("Level");
    }
   
}
