using System.Text.RegularExpressions;

namespace DesafioProjetoHospedagem.Models;

public class Pessoa
{
    public Pessoa() { }

    /*public Pessoa(string nome)
    {
        Nome = nome;
    }*/

    public Pessoa(string nome, string sobrenome)
    {
        Nome = nome;
        Sobrenome = sobrenome;
    }
    public Pessoa(string nomeCompleto)
    {
        NomeCompleto = nomeCompleto;
    }

    private string _nome;
    private string _sobrenome;

    public string Nome 
    {
        get
        {
            return this._nome;
        } 
        set
        {
            string padraoNome = "^[a-zA-Z]$";
            bool nomeNoPadrao = Regex.IsMatch(value, padraoNome, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(2));
            if(nomeNoPadrao)   
                this._nome = value;
            else
                throw new Exception("Pessoa.Set.Nome: Nome no Formato Inválido");
        } 
    }
    public string Sobrenome 
    {   
        get
        {
            return this._sobrenome;
        } 
        set
        {
            string padraoSobrenome = "^[a-zA-Z]$";
            bool sobrenomeNoPadrao = Regex.IsMatch(value, padraoSobrenome, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(2));
            if(sobrenomeNoPadrao)   
                this._sobrenome = value;
            else
                throw new Exception("Pessoa.Set.Sobrenome: Sobrenome no Formato Inválido");
        }
    }
    public string NomeCompleto
    {
        get
        {
            return $"{Nome} {Sobrenome}".ToUpper();
        }
        set
        {
            string padraoNome1 = "[a-zA-Z]{2,}";
            string padraoNome2 = "^[a-zA-Z]{2,}?(/s[a-zA-Z]{2,})??(/s[a-zA-Z]{2,})??(/s[a-zA-Z]{2,})?$";

            bool nomeNoPadrao1 = Regex.IsMatch(value, padraoNome1, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(2));
            bool nomeNoPadrao2 = Regex.IsMatch(value, padraoNome2, RegexOptions.IgnoreCase, TimeSpan.FromSeconds(2));

            string[] nomeESobrenome = value.Split(" ");

            if(nomeNoPadrao1){
                Nome = nomeESobrenome[0];
            }
            else if (nomeNoPadrao2){
                Nome = nomeESobrenome[0];
                Sobrenome = nomeESobrenome[^1];
            }
            else {
                throw new Exception("Nome deve estar no formato padrão! \n" + 
                                    "-- Formatos aceitos: 'nome', 'nome sobrenome', 'nome SegundoNome UltimoNome' --");
            }
        }
    } 
}