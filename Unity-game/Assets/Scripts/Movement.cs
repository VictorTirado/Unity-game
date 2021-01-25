using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class Movement : MonoBehaviourPun
{
    public float Movespeed = 3.5f;
    public float Turnspeed = 120f;
    private TextMesh Caption = null;

    public GameObject[] wheelMesh = new GameObject[4];

    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<this.transform.childCount;i++ )
        {
            if(this.transform.GetChild(i).name == "Caption")
            {
                
                Caption = this.transform.GetChild(i).gameObject.GetComponent<TextMesh>();
                Caption.text = string.Format("Car{0}", photonView.ViewID); 
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if(photonView.IsMine == true )
        {
            Controls();
        }
    }

    private void Controls()
    {
        animateWheels();
        float vert = Input.GetAxis("Vertical");
        float horz = Input.GetAxis("Horizontal");
        this.transform.Translate(Vector3.forward * vert * Movespeed * Time.deltaTime);
        this.transform.localRotation *= Quaternion.AngleAxis(horz * Turnspeed * Time.deltaTime, Vector3.up);
    }

    void animateWheels()
    {
        Vector3 wheelPosition = Vector3.zero;
        Quaternion wheelRotation = Quaternion.identity;

        for(int i=0;i<4;i++)
        {
            //wheelMesh[i].transform.position = wheelPosition;
            wheelMesh[i].transform.rotation = wheelRotation;
        }
    }
}
