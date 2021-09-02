using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
// using Photon.Realtime;
// using UnityEngine.UI;

public class MyPlayer : MonoBehaviourPun
{
    public float Movespeed = 3.5f;
    public float Turnspeed = 120f;
    private TextMesh Caption = null;

    public int points = 0;

    // Start is called before the first frame update
    private void Start()
    {
        for(int i=0; i < this.transform.childCount; i++) //looping all the children
        {
            if(this.transform.GetChild(i).name == "Caption")
            {
                Caption = this.transform.GetChild(i).gameObject.GetComponent<TextMesh>();
                Caption.text = string.Format("player {0}", photonView.ViewID); //id for the object
            }
        }

    }

    // Update is called once per frame
    private void Update()
    {
        if(photonView.IsMine == true)
        {
            Controls();
        }

    }

    private void Controls()
    {
        float vert = Input.GetAxis("Vertical");
        float horz = Input.GetAxis("Horizontal");
        this.transform.Translate(Vector3.forward * vert * Movespeed * Time.deltaTime);
        this.transform.localRotation *= Quaternion.AngleAxis(horz * Turnspeed * Time.deltaTime, Vector3.up);
    }
}
