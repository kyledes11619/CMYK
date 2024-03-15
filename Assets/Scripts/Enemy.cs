using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : InkInteraction
{
    public int color = 3, maxHealth = 4, damage = 1;
    public float damageCooldown = 2, damageRange = 1.5f;
    public Transform target;
    int health;
    float damageCooldownTimer = 0;
    Transform player;
    NavMeshAgent nav;
    public float playerTargetRadius = 10;
    public GameObject damageText;
    

    private void Start()
    {
        health = maxHealth;
        player = FindObjectOfType<CharacterMovement>().gameObject.transform;
        nav = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (inkTimer > 0)
            inkTimer -= Time.deltaTime;
        if (damageCooldownTimer > 0)
            damageCooldownTimer -= Time.deltaTime;
        if (target != null)
        {
            if (target.GetComponent<Torch>() != null)
            {
                if (Vector3.Distance(transform.position, target.position) < damageRange)
                    target.GetComponent<Torch>().Snuff();
                if (!target.GetComponent<Torch>().lit)
                    target = null;
            }
            if(target != null)
                nav.SetDestination(target.position);
        }
        else if (Vector3.Distance(player.position, transform.position) <= playerTargetRadius)
        {
            nav.SetDestination(player.position);
            if (Vector3.Distance(player.position, transform.position) <= damageRange && damageCooldownTimer <= 0)
            {
                damageCooldownTimer += damageCooldown;
                PlayerHealth.Instance.TakeDamage(damage);
            }
        }
    }

    public override void Ink(int color)
    {
        inkTimer += inkCooldown;
        int dmg;
        //If the ink is the same color, enemy is blacK, or ink is blacK, default damage
        if (this.color == color || this.color == 3 || color == 3)
            dmg = 2;
        //If Cyan, Yellow deals more damage and Magenta does less
        else if (this.color == 0)
            dmg = color == 2 ? 4 : 1;
        //If Yellow, Magenta deals more damage and Cyan does less
        else if (this.color == 1)
            dmg = color == 0 ? 4 : 1;
        //If Magenta, Cyan deals more damage and Yellow does less
        else
            dmg = color == 1 ? 4 : 1;
        health -= dmg;
        GameObject text = Instantiate(damageText, transform.position, Quaternion.identity);
        text.GetComponent<TextMesh>().text = "" + dmg;
        Destroy(text, 1);
        if(health <= 0) {
            Destroy(gameObject);
        }
    }

    public float maxAttractRange = 15;

    public void AttractToTarget(Transform target)
    {
        if(Vector3.Distance(target.position, transform.position) <= maxAttractRange)
            this.target = target;
    }
}
