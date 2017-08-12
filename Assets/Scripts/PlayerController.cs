using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	public float speed;
    public Text countText;
    public Text winText;
    public Camera cam;

    public float jumpForce;

    private float airMovementMultiplier = 0.15f;

    private Rigidbody rb;
    private int count;

    private bool isGrounded;

	void Start ()
	{
		rb = GetComponent<Rigidbody> ();
        count = 0;
        winText.text = "";
        setCountText();
    }

	void Update(){
	}

	void FixedUpdate () 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
        movement = cam.transform.TransformDirection(movement);
        movement.y = 0.0f;
        isGrounded = Physics.Raycast(transform.position, -Vector3.up, 1f);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            //movement = new Vector3(moveHorizontal, jumpForce, moveVertical);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        rb.AddForce(movement * (!isGrounded ? speed * airMovementMultiplier : speed));
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pickup"))
        {
            other.gameObject.SetActive(false);
            count++;
            setCountText();
        }
        if (other.gameObject.CompareTag("Floor"))
        {
            setWasteText();
        }
        if (other.gameObject.CompareTag("Enemy")) { }

    }

    void setWasteText()
    {
        winText.text = "Waste of sugar!!!";
    }

    void restart()
    {
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
    }

    void setCountText()
    {
        countText.text = "Sugars: " + count.ToString();
        if (count==9)
        {
            winText.text = "DEVÄŤ";
        }
        if (count >= 12)
        {
            winText.text = "You're so sweet!";
            restart();
        }
    }
}

