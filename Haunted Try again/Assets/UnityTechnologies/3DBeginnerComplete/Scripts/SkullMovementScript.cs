using UnityEngine;

public class SkullMovementScript : MonoBehaviour
{
    public GameObject player;

    private const float INV_PERIOD_SECONDS = 1.0f/5.0f;
    private const float MIN_ANG_VEL_DEG = 245.0f;
    private const float MAX_ANG_VEL_DEG = 1000.0f;

//     private Vector3 _angles = new Vector3(0.0f, 0.0f, 0.0f);
    private float _alpha = 0.0f; // normalized to [0.0, 1.0] scale

    void FixedUpdate() { 
//        _alpha += Time.fixedDeltaTime * INV_PERIOD_SECONDS;
//        if (_alpha > 1.0f) {
//            _alpha -= 1.0f;
        
//        }

        float interpAngVelDeg = 
            (1.0f - _alpha) * MIN_ANG_VEL_DEG +
             _alpha * MAX_ANG_VEL_DEG;

        print("alpha " + _alpha + " interpAngVelDeg " + interpAngVelDeg);

        transform.Rotate(Vector3.up * interpAngVelDeg * Time.deltaTime);
    }
}
