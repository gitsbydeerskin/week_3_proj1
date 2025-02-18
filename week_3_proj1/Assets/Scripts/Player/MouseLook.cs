namespace Player
{
    // Script breakdown starts on Slide 19 of Class 3 Powerpoint "First Person Movement and Mouse look set up"

    using UnityEngine;

    public class MouseLook : MonoBehaviour
    {

        [Header("Sensitivity Settings")]
        // Controls how fast the camera rotates
        public float sensitivity = 8;
        // Toggles inverted vertical movement
        public bool invert = false;

        [Header("Rotation Clamping")]
        // Limites vertical rotation
        [SerializeField] Vector2 _verticalRotationClamp = new Vector2(-60, 60);

        [Header("Camera Setup")]
        // Reference to the player object (for horizontal rotation)
        [SerializeField] Transform _player;
        // Reference to the camera obj (for vertical rotation) 
        [SerializeField] Transform _camera;
        // Stores the temp vertical rotation
        [SerializeField] float _tempRotation;
        // Final vertical rotation value
        [SerializeField] float _verticalRotation;
        // Applies to the camera for up vertical rotation

        // Update is called once per frame
        void Update()
        {
            // READ mouse X inpute and ROTATE player on Y-axis using (mouse X * sensitivy) 
            _player.Rotate(0, Input.GetAxis("Mouse X") * sensitivity, 0);
            //READ mouse Y input and ADD(Mouse Y * sensitivity) to temporary rotation value
            _tempRotation += Input.GetAxis("Mouse Y") * sensitivity;
            //CLAMP temp rotation between min and max rotation limites
            _tempRotation = Mathf.Clamp(_tempRotation, _verticalRotationClamp.x, _verticalRotationClamp.y);
            //IF invert is enabled
            if (invert)
            {
                //SET vertical rotation to temp rotation
                _verticalRotation = _tempRotation;

            }
            // ELSE
            else
            {
                // SET vertical rotattion to negative temp rotation
                _verticalRotation = -_tempRotation;

            }
            //ENDIF

            //APPLY vertical roation to the camera's local X-axis */
            _camera.localEulerAngles = new Vector3(_verticalRotation, 0, 0);

        }





            
    }
}