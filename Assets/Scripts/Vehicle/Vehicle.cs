using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

//추상 클래스
public abstract class Vehicle : MonoBehaviour
{
    public float speed = 10f;      //이동 속도 변수 선언
    
    public virtual void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);     //앞으로 해당 속도만큼 움직인다
    }

    public abstract void Horn();              //경적 함수는 선언만 한다.
}
