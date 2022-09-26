using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApocalypseHandler : ProcessingLite.GP21
{
    [SerializeField] List<Character> characters;
    [SerializeField] List<Zombie> zombies;

    [SerializeField] int charsToSpawn;
    [SerializeField] int zombiesToSpawn;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < charsToSpawn; i++) { characters.Add(new Character(Random.Range(0, Width), Random.Range(0, Height), 0.5f)); }
        for (int i = 0; i < zombiesToSpawn; i++) { zombies.Add(new Zombie(Random.Range(0, Width), Random.Range(0, Height), 0.5f)); }
    }

    // Update is called once per frame
    void Update()
    {
        Background(0);

        for (int i = 0; i < charsToSpawn; i++)
        {
            characters[i].Draw(0, 0, 255);
            characters[i].UpdateCharacters();
        }
        for (int i = 0; i < zombiesToSpawn; i++)
        {
            zombies[i].Draw(0, 255, 0);
            zombies[i].UpdateCharacters();
        }
    }
}
