using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jogo : MonoBehaviour
{
    Personagem mario = new Personagem("Mario", 40, 40);

    Personagem carlos = new Personagem("Carlos", 60, 20);
    // Start is called before the first frame update
    void Start()
    {
        carlos.Atacar();
        mario.ReceberDano(carlos.forca);
        mario.Atacar();
        carlos.ReceberDano(mario.forca);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
