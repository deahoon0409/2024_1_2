using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

//�߻� Ŭ����
public abstract class Vehicle : MonoBehaviour
{
    public float speed = 10f;      //�̵� �ӵ� ���� ����
    
    public virtual void Move()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);     //������ �ش� �ӵ���ŭ �����δ�
    }

    public abstract void Horn();              //���� �Լ��� ���� �Ѵ�.
}
