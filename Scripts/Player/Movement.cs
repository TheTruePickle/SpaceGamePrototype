    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    public class Movement : MonoBehaviour
    {
        private TrailRenderer tR;
        private ParticleSystem pS;
        private PolygonCollider2D pC2D;
        private float DashInternalTimer;
        private float canDash;
        private bool canRotate;
        private bool isAlive;
        private Vector3 movement;
        // Start is called before the first frame update
        void Start()
        {
            Cursor.visible = false;
            isAlive = true;
            DashInternalTimer = 0;
            canDash = 1;
            canRotate = true;
            tR = gameObject.GetComponent<TrailRenderer>();
            pS = gameObject.GetComponent<ParticleSystem>();
            pC2D = gameObject.GetComponent<PolygonCollider2D>();
            movement = new Vector3(0.1f, 0, 0);
        }
        void OnDestroy()
        {    

        }
        IEnumerator Dash()
        {
            movement = new Vector3(0, 0, 0);
            pS.enableEmission = false;
            tR.emitting = true;
            canRotate = false;
            pC2D.enabled = false;
            DashInternalTimer = 0.125f;
            Vector3 original = transform.position;
            Vector3 dest = transform.position +transform.right*10f;
            float counter = 0f;
            while(counter < DashInternalTimer)
            {
                gameObject.transform.position = Vector3.Lerp(original, dest, counter/DashInternalTimer);
                counter+=Time.deltaTime;
                yield return null;
            }
            counter = 0;
            canRotate = true;
            tR.emitting = false;
            movement = transform.right*24;
            pS.enableEmission = true;
            yield return new WaitForSeconds(0.5f);
            pC2D.enabled = true;
        }
        // Update is called once per frame
        void Update()
        {
            canDash+=Time.deltaTime;
            if(Input.GetKeyDown(KeyCode.LeftShift) && canDash >= 0.5f){
                StartCoroutine(Dash());
                canDash = 0;
            }
            if(movement.magnitude >= 24f){
                
                movement.x = movement.x*0.90f;
                movement.y = movement.y*0.90f;
            }
            if(isAlive)
                transform.position += movement*Time.deltaTime;
            if(Input.GetAxis("Vertical") <= 0){
                pS.Stop();
            }
            else{
                pS.playOnAwake |= pS.loop;
                pS.Play();
            }
            if(canRotate){
                Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 10 * Time.deltaTime); 
            }
        }
        void FixedUpdate()
        {
            movement += transform.right*(Input.GetAxis("Vertical"));
        }
}

