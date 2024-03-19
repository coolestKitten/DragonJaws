using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootCollisions : MonoBehaviour
{
    public FootstepAudio _footstepAudio;
    public delegate void FootContact();
    public static event FootContact OnFootContact;
    private string Name;

    // public FootstepAudio FootstepAudio
    // {
    //     get { return _footstepAudio; }
    //     set { _footstepAudio = value; }
    // }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Ground")){
            OnFootContact(); 
            Name = other.gameObject.name;

            switch (Name){
                case "Desert":
                    _footstepAudio.SetFloorType(1);
                    Debug.Log("Sand");
                    break;
            case "Metal":
                    _footstepAudio.SetFloorType(2);
                    Debug.Log("Metal");
                    break;
            case "Grass":
                    _footstepAudio.SetFloorType(3);
                    Debug.Log("Grass");
                    break;
            case "Water":
                    _footstepAudio.SetFloorType(4);
                    Debug.Log("Water");
                    break;
            }

        }
    }

}
