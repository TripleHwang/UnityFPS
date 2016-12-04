using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
    public float Speed, Hp;
    float timer;
    Transform Tf;
    public Animator ani;
    void Start()
    {
        timer = 0;
        Tf = GetComponent<Transform>();
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 TargetPos = GameObject.Find("Player").transform.position;

        var lookPos = TargetPos - transform.position;
        lookPos.y = 0;
        var rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime *Speed);

        if (Vector3.Distance(TargetPos, Tf.position) >= 2f)
            Tf.position = Vector3.MoveTowards(transform.position, new Vector3(TargetPos.x, 0f, TargetPos.z), Speed * Time.deltaTime);
    }

    void Attacked()
    {
        Hp -= 10;
        print(Hp);
        if (Hp <= 0)
            Dead();
    }
    void Dead()
    {
        Destroy(gameObject);
    }
    void OnTriggerStay(Collider other)
    {
        if(other)
        {
            if (other.gameObject.tag == "Player")
            {
                ani.SetBool("Collision", true);
                timer += Time.deltaTime;
                if(timer>0.5f)
                {
                    other.gameObject.SendMessage("Hit");
                    timer = 0;
                }
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
          ani.SetBool("Collision", false);
    }
    void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
          ani.SetBool("Collision", false);
    }
}
