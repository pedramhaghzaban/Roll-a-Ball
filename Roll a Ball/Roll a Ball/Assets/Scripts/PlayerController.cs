using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {
    public float speed;
    private Rigidbody rb;
    private int count;
    public Text countText;
    public Text winText;
    public AudioSource soundEffect;
    public AudioClip collectSound;


     void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winText.text = "";
            
    }
     void FixedUpdate()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");


        Vector3 movement = new Vector3(moveHorizontal ,0.0f, moveVertical );
        rb.AddForce(movement*speed );
        if (Input.GetKeyDown ("space") && GetComponent<Rigidbody>().transform.position.y <= 0.5f) {
            Vector3 jump = new Vector3 (0.0f, 300.0f, 0.0f);
            
            GetComponent<Rigidbody>().AddForce (jump);
            
        }
    }
    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag ("Pickup"))
        {
            other.gameObject.SetActive(false);
            soundEffect.clip = collectSound;
            count += 1;
            SetCountText();
        }
    }
    public void ResetPosition ()
    {
        //transform.position.y = 0.5f;
        //transform.position.z = 0.5f;
        //transform.position.x = 0.5f;
    }    void SetCountText ()
    {
        countText.text = "Count:" + count.ToString();
        if (count >= 9)
            winText.text = "You Win";
    }
    
}
