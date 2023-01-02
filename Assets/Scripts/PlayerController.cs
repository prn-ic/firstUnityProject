using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private float speed = 10.0f;
    private float turnSpeed = 45.0f;
    private float firstHorisontalInput;
    private float firstForwardInput;
    private float secondHorisontalInput;
    private float secondForwardInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move the vehicle forward
        // transform.Translate(0, 0, 1);
        firstHorisontalInput = Input.GetAxis("Horizontal");
        firstForwardInput = Input.GetAxis("Vertical");

        GameObject.Find("Vehicle").transform.Translate(Vector3.forward * Time.deltaTime * speed * firstForwardInput);
        GameObject.Find("Vehicle").transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * firstHorisontalInput);

        secondHorisontalInput = Input.GetAxis("Horizontal2");
        secondForwardInput = Input.GetAxis("Vertical2");

        GameObject.Find("SecondVehicle").transform.Translate(Vector3.forward * Time.deltaTime * speed * secondForwardInput);
        GameObject.Find("SecondVehicle").transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * secondHorisontalInput);

    }
}
