using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class hero1Controller : MonoBehaviour
{
    public TextMeshProUGUI gameoverText;
    public Animator heroAnimator;
    public Button attackButton;
    public healthManager healthManager;
    float HeroCurrentHealth = 1f;
    public float heroAttackDuration = 1.5f;
    public bool hasAttacked = false;
    private bool isAttacking = false;
    public enemyControl enemyDamageReference;
    private enemyControl selectedEnemy; // Store the currently selected enemy
    private float enemyDamage;
    float hero1Damage = 0.2f;


    public void Start()
    {
        enemyDamage = enemyDamageReference.GetEnemyDamage();
    }
    public void Update()
    {
        if (!isAttacking)
        {
            heroAnimator.Play("heroIdle");
        }
    }
    public float GetHeroDamage()
    {
        return hero1Damage;
    }

    public void selectEnemyOnClick(enemyControl enemy)
    {
        // Store the selected enemya
        Debug.Log("select enemy tes");
        selectedEnemy = enemy;
        if (selectedEnemy != null)
        {
            Debug.Log("Selected Enemy: " + selectedEnemy.gameObject.name);
        }
        else
        {
            Debug.Log("No enemy selected.");
        }
    }

    public void attack()
    {
        if (selectedEnemy != null && !isAttacking)
        {
            // Play the attack animation
            heroAnimator.Play("heroAttack");
            selectedEnemy.takeDamage();

            // Set a flag to prevent repeated attacks
            isAttacking = true;

            // Start a coroutine to stop attacking after the attackDuration
            StartCoroutine(StopAttack());
        }
    }

    private IEnumerator StopAttack()
    {
        // Wait for the attack duration
        yield return new WaitForSeconds(heroAttackDuration);

        // Reset the flag and play the idle animation
        isAttacking = false;
        hasAttacked = true;
        selectedEnemy = null;
    }

    public void takeDamage()
    {
        healthManager.DecreaseLife(enemyDamage);
        HeroCurrentHealth -= enemyDamage;

        // Display game over text
        if (HeroCurrentHealth < enemyDamage)
        {
            gameoverText.SetText("You Lose");
            gameoverText.gameObject.SetActive(true);

            // Pause the game
            Time.timeScale = 0;
        }
    }
}