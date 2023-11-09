using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class hero2Controller : MonoBehaviour
{
    public TextMeshProUGUI gameoverText;
    public Animator heroAnimator;
    public Button attackButton;
    public healthManager healthManager;
    float HeroCurrentHealth = 1f;
    public float heroAttackDuration = 1.5f;
    private bool isAttacking = false;
    private float heroDamage = 0.2f;
    public bool hasAttacked { get; private set; } = false;
    private enemyControl selectedEnemy;

    public void Start()
    {
        // Initialize any necessary components or variables
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
        return heroDamage;
    }

    public void selectEnemyOnClick(enemyControl enemy)
    {
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
            heroAnimator.Play("heroAttack");
            selectedEnemy.takeDamage();
            isAttacking = true;
            StartCoroutine(StopAttack());
        }
    }

    private IEnumerator StopAttack()
    {
        yield return new WaitForSeconds(heroAttackDuration);
        isAttacking = false;
        hasAttacked = true;
        selectedEnemy = null;
    }

    public void takeDamage()
    {
        healthManager.DecreaseLife(heroDamage);
        HeroCurrentHealth -= heroDamage;

        if (HeroCurrentHealth < heroDamage)
        {
            gameoverText.SetText("You Lose");
            gameoverText.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void StartTurn()
    {
        // Additional logic for the start of hero1's turn
        attackButton.interactable = true;
    }

    public void EndTurn()
    {
        // Additional logic for the end of hero1's turn
        attackButton.interactable = false;
        hasAttacked = false;
    }
}
