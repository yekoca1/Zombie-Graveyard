using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

enum ZombieState {
    Idle = 0,
    Walk = 1,
    Die = 2,
    Attack = 3
}

public class zombieAI : MonoBehaviour
{
    ZombieState zombieState;

    GameObject playerObject;   // inspector sayfasında olmayan bir objemizi tanımlıyoruz

    Animator animator;
    NavMeshAgent agent;
    zombieHealth _zHealth;
    
    playerHealth pHealth;
    void Start()
    {
        _zHealth = GetComponent<zombieHealth>();
        playerObject = GameObject.FindWithTag("Player");
        pHealth = playerObject.GetComponent<playerHealth>();
        zombieState = ZombieState.Idle; // default durumuz idle
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>(); 
    }

    
    void Update()  // ilk koşul sağlanıyosa diğerleri kontrol edilmez
    {
        if(_zHealth.getHealth()<=0)
        {
            SetState(ZombieState.Die);
        }
        switch (zombieState)    
        {
            case ZombieState.Die:
            KillZombie();
            break;

            case ZombieState .Attack:
            attack();
            break;

            case ZombieState.Walk:
            LookTarget();  // oyuncuya soğru yürürken de bir yandan hedef araması yapması lazım
            break;

            case ZombieState.Idle:
            LookTarget();
            break;                

            default:
            break; 
        }
    }

    private void attack()
    {
        SetState(ZombieState.Attack);
        agent.isStopped = true;  //saldırı mesafesinden çıkınca yine saldıracak
    }

    private void makeAttack()
    {
        Debug.Log("saldırı yapıldı");
        pHealth.deductHealth(10);
        LookTarget();
    }

    private void LookTarget()
    {
        float distance = Vector3.Distance(transform.position, playerObject.transform.position);  // player objesi ile kendi objemizin mesafesi
        if(distance <2f)
        {
            attack();
        }
        else if(distance <= 10)
        {
            moveToPlayer();
        }
        else
        {
            SetState(ZombieState.Idle);
            agent.isStopped = true; // görüş alanından çıktığım anda dur
        }
    }

    private void SetState(ZombieState state)
    {
        zombieState = state;
        animator.SetInteger("State", (int)state); // animatörün de statei state değişkenine göre tanımlanır.
    }

    private void moveToPlayer()
    {
        agent.isStopped = false;
        agent.SetDestination(playerObject.transform.position); //hedefi belirler...!
        SetState(ZombieState.Walk);
    }

    private void KillZombie()
    {
        SetState(ZombieState.Die);
        agent.isStopped = true;
        Destroy(gameObject, 5);
    }
}
