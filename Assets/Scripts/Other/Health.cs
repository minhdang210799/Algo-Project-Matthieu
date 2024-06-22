using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health = 100;

    public GameObject[] loot;

    private void Update()
    {
        if (gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                health = 100;
            }
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        if (loot.Length > 0)
        {
            SpawnLoot();
        }

        if (gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (gameObject.CompareTag("Enemy"))
        {
            int ran = Random.Range(1, 5);
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Sound>().Play(gameObject, ran);

            Destroy(gameObject, 0.2f);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void SpawnLoot()
    {
        foreach(GameObject lootObject in loot)
        {
            Instantiate(lootObject, new Vector3(transform.position.x, 1, transform.position.z), transform.rotation);
        }
    }
}
