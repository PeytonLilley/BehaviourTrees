using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    private CharacterController characterController;
    public float speed;

    public Transform resetPoint;

    void Start()
    {
     characterController = GetComponent<CharacterController>();   
    }

    void Update()
    {
        // get input for movement
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        characterController.Move(move * Time.deltaTime * speed);
    }

    // I attempted to have the player's position be reset if a guard touched them but it didn't end up working
    private void OnTriggerEnter(Collider other)
    {
        transform.position = resetPoint.position;
    }

}
