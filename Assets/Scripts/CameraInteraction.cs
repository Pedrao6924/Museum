using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CameraInteraction : MonoBehaviour
{

    public Camera camera;
           RaycastHit hit;

    public GameObject retical;
    //PAINTING INFO VARIABLES
    public GameObject paintingUIgroup;
    public GameObject backGround;
    public TMP_Text paintingInfo;
           PaintingDetails PaintingDetails;

    //Gate Details
    GateDetails gateDetails;

    //Interaction Bubbles
    public GameObject bubbleGroup;
    public TMP_Text bubbleText;

    void SetPaintingInfo(string text){
        paintingInfo.text = text;
    }

    void addWatchTime(){
        PaintingDetails.watchTime++;
    }

    void TurnOffUI(){
        paintingUIgroup.SetActive(false);
    }   

    void NextRoom(GateDetails roomInfo){
        roomInfo.nextRoom.SetActive(true);
        roomInfo.currentRoom.SetActive(false);
    }

    void GrowReticalSize(bool i){
        float scale = retical.transform.localScale.x;
        if(i && scale < 0.1f){
            retical.transform.localScale += new Vector3(0.0001f,0.0001f,0.0001f);
        } else {
           if(scale > 0.02f){
             retical.transform.localScale -= new Vector3(0.0005f,0.0005f,0.0005f);
           }
        }
    }


    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        if(Physics.Raycast(ray, out hit)) {
            Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * 100.0f, Color.green);
            
            //CASE PAINTINGS
            if(hit.transform.tag == "Painting"){
                PaintingDetails = hit.transform.gameObject.GetComponent<PaintingDetails>();//Get Painting Details from PaintingDetails[ScriptabelObject]
                SetPaintingInfo(PaintingDetails.infoText);                                 //Send the info the the UI
                addWatchTime();                                                            //meta data on how long people have looked at the painting
                paintingUIgroup.SetActive(true);                                           //Show the UI

            } else {
                paintingUIgroup.SetActive(false);
            }

            //CASE GATES
            if(hit.transform.tag == "Gate"){
                GrowReticalSize(true);
                gateDetails = hit.transform.gameObject.GetComponent<GateDetails>();
                if(retical.transform.localScale.x >=0.1f){
                    NextRoom(gateDetails);
                    retical.transform.localScale = new Vector3(0.02f,0.02f,0.02f);
                }
            }

            //CASE ADD TO CART
            if(hit.transform.tag == "AddToCart"){
                GrowReticalSize(true);
                if(retical.transform.localScale.x >=0.1f){
                    bubbleText.text = "Added to cart.";
                    bubbleGroup.SetActive(true);
                } 
            }

            //CASE SEND EMAIL
            if(hit.transform.tag == "Email"){
                GrowReticalSize(true);
                if(retical.transform.localScale.x >=0.1f){
                    bubbleText.text = "Email Sent";
                    bubbleGroup.SetActive(true);
                } 
            }

        }else{
            GrowReticalSize(false);
            TurnOffUI();
            
            if(retical.transform.localScale.x <= 0.02f){
                bubbleGroup.SetActive(false);
            }
        }
    }
}
