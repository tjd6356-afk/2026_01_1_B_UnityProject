using UnityEngine;
using UnityEngine.UI;

public class myjump : MonoBehaviour
{
    public Rigidbody rigidbody;
    public float power = 200f;
    public float timer = 0;
    public Text TextUi;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer + Time.deltaTime;
        TextUi.text = timer.ToString();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            power = power + Random.Range(-100, 200);
            rigidbody.AddForce(transform.up * power);
        }

        if (this.gameObject.transform.position.y >5 || this.gameObject.transform.position.y < -3)
        {
            Destroy(this.gameObject);
        }
    }
}
