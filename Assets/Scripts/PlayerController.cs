using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float moveSpeed;
    private Rigidbody myRigidbody;

    private Vector3 moveInput;
    private Vector3 moveVelocity;

    private Camera mainCamera;

    public GunController theGun;
    public GameObject BasicGun;
    public GameObject Juggernaut;
    public GameObject machineGun;
    public GameObject shotgun;
    public GameObject sniper;
    public GameObject currentGun;

	// Use this for initialization
	void Start () {
        myRigidbody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
        currentGun = BasicGun;
        currentGun.SetActive(true);
	}
	
	// Update is called once per frame
	void Update () {
        moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        moveVelocity = moveInput * moveSpeed;

        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength)) {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.red);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }

        if (Input.GetMouseButtonDown(0))
        {
            currentGun.GetComponent<GunController>().isFiring = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            currentGun.GetComponent<GunController>().isFiring = false;
        }
	}

    void FixedUpdate () {
        myRigidbody.velocity = moveVelocity;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Weapon 1")) {
            other.gameObject.SetActive(false);
            currentGun.SetActive(false);
            currentGun = Juggernaut;
            currentGun.SetActive(true);
        } else if (other.gameObject.CompareTag("Weapon 2"))
        {
            other.gameObject.SetActive(false);
            currentGun.SetActive(false);
            currentGun = machineGun;
            currentGun.SetActive(true);
        } else if (other.gameObject.CompareTag("Weapon 3"))
        {
            other.gameObject.SetActive(false);
            currentGun.SetActive(false);
            currentGun = sniper;
            currentGun.SetActive(true);
        } else if (other.gameObject.CompareTag("Weapon 4"))
        {
            other.gameObject.SetActive(false);
            currentGun.SetActive(false);
            currentGun = shotgun;
            currentGun.SetActive(true);
        }
    }
}
