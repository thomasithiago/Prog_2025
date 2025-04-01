using System.Diagnostics;
using Aula03.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aula03.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View("./JogoVelha/JogoVelha");
        }

        [HttpGet]
        public string GetIf(int x)
        {
            /*
             
             Estrutura Sint�tica do IF:

                if(express�o booleana)
                {
                    sente�a de c�digo a ser
                    executada caso a condi��o
                    seja atinjida como verdadeira;
                }
                
             Caso o IF tenha apenas uma linha de comando a ser executada
             na condicional, n�o h� necessidade do uso de chaves{};
                
                if(express�o booleana)
                    apenas um comando;

             */

            // int x = 10;
            string retorno = string.Empty;

            if (x < 9)
            {
                retorno = "x � maior que 9";
            }

            // x = 8;

            if (x > 9)
            {
                retorno = "x � maior que 9";
            }

            else
            {
                retorno = "x � menor que 9";
            }

            // x = 11;

            if (x == 10)
            {
                retorno = "ora ora";
                retorno += "x � igual a 10";
            }

            else if (x == 9)
            {
                retorno = "hmmmmmmmm";
                retorno += "x � igual a 9";
            }

            else if (x == 8)
            {
                retorno = "bahhhhhhhh";
                retorno += "x � igual a 8";
            }

            else
            {
                retorno = "sei l� que n�mero � x";
            }

            return retorno;
        }

        [HttpGet]
        public string GetSwitch(int x)
        {
            string retorno = string.Empty;

            switch (x)
            {
                case 0:
                    retorno = "x � zero";
                    break;
                case 1:
                    retorno = "x � um";
                    break;
                case 2:
                    retorno = "x � dois";
                    break;
                case 3:
                    retorno = "x � tr�s";
                    break;
                default:
                    retorno = "x � algum n�mero imprevisto";
                    break;
            }

            return retorno;
        }

        [HttpGet]
        public string GetFor()
        {
            /*
             
                O comando de repeti��o FOR possui a seguinte sintaxe:
                
                for(<inicializador>; <express�o condicional>; <express�o de repeti��o>)
                {
                    comandos a serem executados;
                }
                
               * inicializador: elemento contador utilizado o "i";

               * express�o condicional: especifica o teste a ser verificado quando o loop
                estiver executando o n�mero definido de itera��es;
  
               * express�o de repeti��o: especifica a a��o a ser executada com a vari�vel
                contadora. Geralmente um ac�mulo ou decr�scimo;

             */

            string retorno = string.Empty;

            for (int i = 0; i < 10; i++)
            {    if (i > 50)
                
                    break; //interrompe o la�o
                
                
               if ((i % 2) != 0)
            
                retorno += $"{i}; ";
            }

            return retorno;
        }

        [HttpGet]

        public string GetForeach(string color)
        {
            /*
             * O Comando Foreach() (para cada) �
             * utilizado para iterar �pr uma sequencia de
             * itens em uma cole��o,
             * e servir como uma op��o simples de repetic��o
             */
            string[] colors = ["Vermelho", "Preto", "Azul", "Verde", "Branco", "Azul-Marinho", "Rosa", "Roxo", "Cinza"];

            string retorno = string.Empty ;

            if (colors.Contains(char.ToUpper(color[0]) + color.Substring(1)))
            {
                retorno = "A cor escolhida � valida";
            }

            else
            {
                retorno = "Cor escolhida inv�lida";
            }
            foreach (string s in colors)
            {
                retorno += $" [{s};]"; 
            }

            return retorno;

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}