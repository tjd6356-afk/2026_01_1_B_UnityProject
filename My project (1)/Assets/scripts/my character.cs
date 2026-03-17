using UnityEngine;

public class mycharacter : MonoBehaviour
{
    public int Health = 100;                         //체력을 선언 한다. (변수)
    public float Timer = 1.0f;                       //타이머를 설정 한다. (변수 실수 표현)

    void Start()
    {
        Health = Health + 100;                      //첫 시작 할떄 100의 체력 추가 한다.
    }

    // Update is called once per frame
    void Update()
    {
        Timer = Timer - Time.deltaTime;             //시간을 매 프래임 마다 감소한다.

        if (Timer <= 0)
        {
            Timer = 1.0f;
            Health = Health - 20;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Health = Health + 2;
        }

        if (Health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
