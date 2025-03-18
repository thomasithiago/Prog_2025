namespace Aula02.Models
{
    public class DataType
    {
        public char myVar = 'a';    
        public char myConst = 'b';

        public char myChar1 = 'f';
        public char myChar2 = ':';
        public char myChar3 = 'x';

        //Podemos também atribuir refência
        //de caracteres Unicode

        public char myChar4 = '\u2726';

        //Podemos aainda mesclar caracteres especiais 
        //Como, nova linha, tabulação e etc.
        public string textLine = "Esta é uma linha de texto.\n\n\n";

        /*
          \e =Caracter de escape
           \n =Nova Linha
            \r =Retorno
             \t =Tabulação Horizontal 
              \"=Aspas duplas,usado para exibir dentro de string
               \'=Aspas simples, usado para exibir aaspas simples dentro de string  
         */

       
        private int count = 10;
        public string message;
        public DataType()
        {    // Interpolação de Strings 
             // Combinando string de diferente maneiras no C#
            message = $"o contador está em {count}";

            string username = "Thiago";
            int inboxCount = 10;
            int maxCount = 100;

            message += $"\n o usuario {username} tem {inboxCount } Mensagens";
            message += $"\nespaço restante na sua caixa {maxCount - inboxCount}";
        }
      
    }
}
