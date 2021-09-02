using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
// using Photon.Realtime;
using UnityEngine.UI;

public class MyPlayer : MonoBehaviourPunCallbacks
{
    public float Movespeed = 3.5f;
    public float Turnspeed = 120f;
    private TextMesh Caption = null;
    public PhotonView pv;
    public Camera camera;


    //private Text PlayerName = null;

    // Start is called before the first frame update
    private void Start()
    {
        if(!pv.IsMine)
        camera.enabled = false; //if photon view not belong to us, kita turn off camera

        for(int i=0; i < this.transform.childCount; i++) //looping all the children
        {
            if(this.transform.GetChild(i).name == "Caption")
            {
                Caption = this.transform.GetChild(i).gameObject.GetComponent<TextMesh>();
                Caption.text = string.Format("player {0}", photonView.ViewID); //id for the object
                //PlayerName.text = string.Format("player {0}", photonView.ViewID);
            }
        }

    }

    // Update is called once per frame
    private void Update()
    {
        if(pv.IsMine) //belong to invidual
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
