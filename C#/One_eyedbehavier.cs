using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class One_eyedbehavier : MonoBehaviour
{
    #region Public Variables
    public Transform raycast;
    public LayerMask raycastMask;
    public float raycastLength;
    public float attackDistance;
    public float movespeed;
    public float timer;
    public Transform Enemy_Left_Limit;
    public Transform Enemy_Right_Limit;
    public int damage;
    #endregion

    #region Private Variables
    private RaycastHit2D hit;
    private Transform target;
    private Animator anim;
    private float distance;
    private bool attackMode;
    private bool inRange;
    private bool cooling;
    private bool outrange;
    private float intTimer;
    private int cool;
    #endregion
    // Update is called once per frame
    private PlayerHP playerhp;

    void Awake()
    {
        playerhp = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHP>();
        intTimer = timer;
        anim = GetComponent<Animator>();
        SelectTarget();
    }

    void Update()
    {
        if (inRange)
        {
            hit = Physics2D.Raycast(raycast.position, transform.right, raycastLength, raycastMask);
            RaycastDebugger();
        }

        if (!InsideofLimits() && !inRange && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        {
            SelectTarget();
        }

        if (inRange)
        {
            EnemyLogic();
        }

        if (outrange)
        {
            inRange = false;
        }

        if (outrange)
        {
            anim.SetBool("canWalk", false);
            StopAttack();
            outrange = false;
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {

        if (trig.gameObject.tag == "Player")
        {
            target = trig.transform;
            inRange = true;
            outrange=false;
            Flip();
        }

    }
    void OnTriggerExit2D(Collider2D trig)
    {

        if (trig.gameObject.tag == "Player")
        {
            //target = trig.gameObject;
            outrange = true;
        }

    }

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        target = other.gameObject;
    //        inRange = true;
    //        Debug.Log("TriggerPlayer");
    //    }
    //    Debug.Log("Trigger");
    //}

    void RaycastDebugger()
    {
        if (distance > attackDistance)
        {
            Debug.DrawRay(raycast.position, transform.right * raycastLength, Color.red);
        }
        else if (distance < attackDistance)
        {
            Debug.DrawRay(raycast.position, transform.right * raycastLength, Color.green);
        }
        //Debug.Log("work");
    }

    void EnemyLogic()
    {

        if (playerhp != null)
        {
            distance = Vector2.Distance(transform.position, target.position);
        }
        else
        {
            target = Enemy_Right_Limit;
            distance = Vector2.Distance(transform.position, target.position);
            StopAttack();
            //distance = Vector2.Distance(transform.position, Enemy_Right_Limit.position);
        }
        //distance = Vector2.Distance(transform.position, target.position);

        //if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        //{
        //    Debug.Log("2");
        //    Move();
        //}



        if (distance > attackDistance) ;
        {
            if (cooling == false)
            {
                Move();
            }
            ////Move();

            StopAttack();
        }

        //if (!InsideofLimits() && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack"))
        //{
        //    SelectTarget();
        //}

        if (distance <= attackDistance && cooling == false)
        {

            //if (attackDistance >= distance && cooling == false)
            //{
            Attack();
            //}
        }
        //else if (attackDistance >= distance && cooling == false)
        //{
        //    Attack();
        //}

        if (cool == 1) 
        {
            //cooling = false;
            Invoke("Cooldown", timer);
            //Cooldown();
            anim.SetBool("canWalk", false);
            anim.SetBool("Attack", false);
            cool = 0;
        }
        //Debug.Log("EnemyLogic");
    }

    void Move()
    {
        anim.SetBool("canWalk", true);
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Attack")) 
        {
            Vector2 targetPos = new Vector2(target.position.x, transform.position.y);
            transform.position = Vector2.MoveTowards(transform.position, targetPos, movespeed * Time.deltaTime);
        }
    }

    void Attack()
    {
        Debug.Log("Starts");
        timer = intTimer;
        attackMode = true;
        //Debug.Log("attack");
        anim.SetBool("canWalk", false);
        anim.SetBool("Attack", true);
        if (distance <= attackDistance && playerhp != null && !anim.GetCurrentAnimatorStateInfo(0).IsName("Attack")) 
        {

            playerhp.DamegePlayer(damage);
        }

    }

    void StopAttack()
    {
 
            //cooling = false;
            attackMode = false;
            anim.SetBool("Attack", false);
        
    }

    void Cooldown()
    {
        cooling = false;
        //timer -= Time.deltaTime;
        //Debug.Log(timer);
        ////Debug.Log(timer);
        ////²î¸öcooling == false;
        //if (timer <= 0 && cooling && attackMode)
        //{
        //    cooling = false;
        //    timer = intTimer;
        //    Debug.Log("if");
        //}
    }

    public void TriggerCooling()
    {
        cooling = true;
        cool = 1;
    }

    private bool InsideofLimits()
    {
        return transform.position.x > Enemy_Left_Limit.position.x && transform.position.x < Enemy_Right_Limit.position.x;
    }

    private void SelectTarget()
    {
        float distanceToLeft = Vector2.Distance(transform.position, Enemy_Left_Limit.position);
        float distanceToRight = Vector2.Distance(transform.position, Enemy_Right_Limit.position);

        if (distanceToLeft > distanceToRight)
        {
            target = Enemy_Left_Limit;
        }
        if (distanceToLeft < distanceToRight)
        {
            target = Enemy_Right_Limit;
        }

        Flip();
    }

    private void Flip()
    {
        Vector3 rotation = transform.eulerAngles;
        if (transform.position.x > target.position.x)
        {
            rotation.y = 0f;
        }
        else
        {
            rotation.y = 180f;
        }

        transform.eulerAngles = rotation;
    }

}
