using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioProjetoHospedagem.Seguranca
{
    public class Usuario
    {
        private string User { get; set; }
        private int Senha { get; set; }

        public static bool VerificaUsuarioESenha(string usuario, int senha){
            if(usuario == "usu" && senha == 1234)
                return true;
            else
                return false; 
        }
    }
}