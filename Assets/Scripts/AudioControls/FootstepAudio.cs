using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepAudio : HandleFeetNoises
{
   [SerializeField] public PlayerControllerFreeform _playerMovement;

    public floorType floorType;
    [Space]
    public AudioClip jumpDesertClip;
    public List<AudioClip> desertWalkClips;
    public List<AudioClip> desertRunClips;
    [Space]
    public AudioClip jumpGrassClip;
    public List<AudioClip> grassWalkClips;
    public List<AudioClip> grassRunClips;
    [Space]
    public AudioClip jumpWaterClip;
    public List<AudioClip> waterWalkClips;
    public List<AudioClip> waterRunClips;
    [Space]
    public AudioClip jumpMetalClip;
    public List<AudioClip> metalWalkClips;
    public List<AudioClip> metalRunClips;

    public void SetFloorType(int detectedType){
        switch (detectedType){
            case 1: 
                floorType = floorType.Desert;
                break;
            case 2:
                floorType = floorType.Metal;
                break;
            case 3:
                floorType = floorType.Grass;
                break;
            case 4:
                floorType = floorType.Water;
                break;
            default:
                break;
        }
    }

    private new void OnEnable(){
        base.OnEnable();
        FootCollisions.OnFootContact += PlayAudio;
        _playerMovement.OnJump += PlayJumpSound;
    }

    private void OnDisable(){
        FootCollisions.OnFootContact -= PlayAudio;
        _playerMovement.OnJump -= PlayJumpSound;
    }

    private void Start() {
        audioClip = desertWalkClips[0];
    }

    private void PlayJumpSound(){
        switch (floorType) {
            case floorType.Desert:
                audioClip = jumpDesertClip;
                break;
            case floorType.Metal:
                audioClip = jumpMetalClip;
                break;
            case floorType.Grass:
                audioClip = jumpGrassClip;
                break;
            case floorType.Water:
                audioClip = jumpWaterClip;
                break;
        }

        audioSource.PlayOneShot(audioClip);
    }

    private new void PlayAudio(){
        switch(floorType){
            case floorType.Desert:
                audioClip = _playerMovement.isSprinting ? desertRunClips[Random.Range(0, desertRunClips.Count)] : desertWalkClips[Random.Range(0, desertWalkClips.Count)];
                break;
            case floorType.Metal:
                audioClip = _playerMovement.isSprinting ? metalRunClips[Random.Range(0, metalRunClips.Count)] : metalWalkClips[Random.Range(0, metalWalkClips.Count)];
                break;
            case floorType.Grass:
                audioClip = _playerMovement.isSprinting ? grassRunClips[Random.Range(0, grassRunClips.Count)] : grassWalkClips[Random.Range(0, grassWalkClips.Count)];
                break;
            case floorType.Water:
                audioClip = _playerMovement.isSprinting ? waterRunClips[Random.Range(0, waterRunClips.Count)] : waterWalkClips[Random.Range(0, waterWalkClips.Count)];
                break;
        }

        audioSource.PlayOneShot(audioClip);
    }

}

public enum floorType {
    Desert,
    Metal, 
    Grass,
    Water
}
