using UnityEngine;

public class Personagem
{

    public string nome;
    public int saude;
    public int forca;

    public Personagem(string nome, int saude, int forca)
    {
        this.nome = nome;
        this.saude = saude;
        this.forca = forca;
    }

    public void Atacar()
    {
        Debug.Log($"{nome} está atacando com força: {forca}");
    }

    public void ReceberDano(int dano)
    {
        saude -= dano;
        Debug.Log($"{nome} recebeu {dano} de dano. Saude restante: {saude}");
    }
}