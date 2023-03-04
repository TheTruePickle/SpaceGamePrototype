    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class Movement : MonoBehaviour
    {
        private Rigidbody2D body;
        private ParticleSystem pS;
        private Vector3 vel;
        private Vector3 velocity = Vector3.zero;
        private float input;
        private float velocitation;
        // Start is called before the first frame update
        void Start()
        {
            pS = gameObject.GetComponent<ParticleSystem>();
            body = gameObject.GetComponent<Rigidbody2D>();
            pS.Stop();
        }

        // Update is called once per frame
        void Update()
        {
            velocitation = body.velocity.magnitude;
            input += Input.GetAxis("Vertical");
            input = Mathf.Clamp(input, -8, 16);
            Debug.Log(velocitation);
            //if(Input.GetAxis("Vertical") != 0f && body.velocity.magnitude < GameConstants.PlayerMaxSpeed)
                body.AddForce(transform.right * Time.deltaTime * input * 10f, ForceMode2D.Force);
            //vel = body.velocity;
            /*if(Input.GetAxis("Vertical") != 0){
                input += Input.GetAxis("Vertical");
                input = Mathf.Clamp(input, -8, 16);
                gameObject.transform.position +=(transform.right * Time.deltaTime * input);
                vel = body.velocity;  
            }
            else{
                gameObject.transform.position = Vector3.SmoothDamp(transform.position, transform.position+vel, ref velocity, 0.9999f);
                input = 0;
            }*/
            if(Input.GetAxis("Vertical") <= 0){
                pS.Stop();
            }
            else{
                pS.playOnAwake |= pS.loop;
                pS.Play();
            }
            Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 32/input * Time.deltaTime);           
        }
    }
