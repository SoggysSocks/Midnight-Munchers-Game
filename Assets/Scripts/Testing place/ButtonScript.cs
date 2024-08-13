    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class ButtonScript : MonoBehaviour //NOT MY SCRIPT /NOT MY SCRIPT /NOT MY SCRIPT
{
        public float buttonExt = 0.05f;
        public float timer = 0.8f; // Time before the button returns to its original position
        public GameObject InstantiateObject; // Object to instantiate when the button is pressed
        public Transform instantiatePosition; // Position where the object will be instantiated
        public AudioClip pressSound; // Sound to play when the button is pressed

        private Vector3 ogPosition;
        private AudioSource audioSource;
        private bool isPressed = false;

        void Start()
        {
            ogPosition = transform.localPosition;
            audioSource = GetComponent<AudioSource>();
        }

        void Update()
        {
            if (!isPressed && (Input.GetKeyDown(KeyCode.E) || Input.GetMouseButtonDown(0)) && IsPlayerLookingAtButton())
            {
                StartCoroutine(PressButton());
            }
        }

        IEnumerator PressButton()
        {
            isPressed = true;
            transform.localPosition = ogPosition + Vector3.down * buttonExt;
        
            if (pressSound != null) audioSource.PlayOneShot(pressSound);
            if (InstantiateObject != null && instantiatePosition != null)
                Instantiate(InstantiateObject, instantiatePosition.position, instantiatePosition.rotation);

            yield return new WaitForSeconds(timer);
        
            transform.localPosition = ogPosition;
            isPressed = false;
        }

        bool IsPlayerLookingAtButton()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            return Physics.Raycast(ray, out RaycastHit hit, 2f) && hit.transform == transform;
        }
    }
