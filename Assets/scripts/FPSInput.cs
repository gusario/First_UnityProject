using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour {

    public float speed = 6.0f;
    public float gravity = -9.8f;
    public float jump = 50;
    private CharacterController _charController;
	// Use this for initialization
	void Start () {
      _charController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(deltaX, 0, deltaZ); //создание вектора движения, который будет изменяться по оси X и Z
        movement = Vector3.ClampMagnitude(movement, speed); //ограничение скорости, если идет движение по диагонали
        //if (Input.GetKeyDown(KeyCode.Space) && (Physics.Raycast(transform.position, Vector3.down, 1.5f))) 
            //rigidbody.
        movement.y = gravity; //добавление гравитации
        movement *= Time.deltaTime; //отвязка от FPS
        movement = transform.TransformDirection(movement); // перевод координат, чтобы нормально двигаться
        _charController.Move(movement); // само движение 

	}
}
