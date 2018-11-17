using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderingAI : MonoBehaviour {
    public float speed = 3f;
    public float obstacleRange = 5f;
    private bool _alive;
    [SerializeField] private GameObject FireBallPrefab;
    private GameObject _fireball;
	// Use this for initialization
	void Start () {
        _alive = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (_alive)
        {
            transform.Translate(0, 0, speed * Time.deltaTime);
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                GameObject HitObject = hit.transform.gameObject; 
                if(HitObject.GetComponent<PlayerCharacter>()){
                    if (_fireball == null){
                        _fireball = Instantiate(FireBallPrefab) as GameObject;
                        _fireball.transform.position = transform.TransformPoint(Vector3.forward * 1.5f);
                        _fireball.transform.rotation = transform.rotation;
                    }
                }
                else if (hit.distance < obstacleRange)
                {
                    float angle = Random.Range(-110, 110);
                    transform.Rotate(0, angle, 0);
                }
            }
        }
	}
    public void SetAlive(bool alive){
        _alive = alive;
    }
}
