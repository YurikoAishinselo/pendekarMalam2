using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class enemyControl : MonoBehaviour
{
    public healthManager healthManager;
    public TextMeshProUGUI gameoverText;
    public Animator enemyAnimator;
    public hero1Controller hero1;
    //public hero2Controller hero2;
    public float enemyAttackDuration = 3f;

    float enemyCurrentHealth = 1f;
    public enemyControl enemy1;
    public enemyControl enemy2;
    public bool enemyOneisAttack = true;
    public bool enemyTwoisAttack;
    public hero1Controller heroDamageReference;
    float enemyDamage = 0.2f;
    float heroDamage;

    public void Start()
    {
        heroDamage = heroDamageReference.GetHeroDamage();
    }
    public void Update()
    {
        if (hero1.hasAttacked)
        {
            StartCoroutine(EnemyAttack());
            hero1.hasAttacked = false;
        }
    }

    public float GetEnemyDamage()
    {
        return enemyDamage;
    }

    public void takeDamage()
    {
        healthManager.DecreaseLife(heroDamage);
        enemyCurrentHealth -= heroDamage;

        // Display text when the enemy's health is below the damage
        if (enemyCurrentHealth < heroDamage)
        {
            gameoverText.SetText("You win");
            gameoverText.gameObject.SetActive(true);

            // Pause the game
            Time.timeScale = 0;
        }
    }

    private IEnumerator EnemyAttack()
    {
        enemy1.GetComponent<Animator>().Play("enemyAttack");
        hero1.takeDamage();
        yield return new WaitForSeconds(enemyAttackDuration);
        enemy2.GetComponent<Animator>().Play("enemyAttack");
        hero1.takeDamage();

    }
}