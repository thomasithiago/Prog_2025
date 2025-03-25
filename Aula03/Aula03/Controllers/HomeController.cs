using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Aula03.Models;

namespace Aula03.Controllers;

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
        return View();
    }
    [HttpGet]
    public string GetIf(int x)
    {
        /*
           Estrutura sint�tica do if
        if(express�o booleana)
        {
        senten�a de c�digo a ser executada se a express�o for verdadeira
        
        }

         Caso o if tenha apenas uma linha de comando a ser executada na condicional, n�o h� 
         necessidade de utilizar chaves
         if(express�o booleana)
            Apenas um comando 

         */

        string retorno = string.Empty;
        //int x = 10;
        if (x < 9)
            retorno = "x � maior que 9";

        x = 8;
        if (x > 9)
            retorno = "x � maior que 9";
        else
            retorno = "x � menor que 9";
        x = 11;
        if (x == 10)
        {
            retorno = "Ora ora";
            retorno += " x � igual a 10";
        }
        else if (x == 9)
        {
            retorno = "Ora ora";
            retorno += " x � igual a 9";
        }
        else if (x == 8)
        {
            retorno = "Hmmmmm";
            retorno += " x � igual a 9";
        }
        else if (x == 8)
        {
            retorno = "Bahhhh";
            retorno += " x � igual a 8 tch�";
        }
        else
        {
            retorno = "Sei l� que n�mero � x";
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
                retorno = "x � um n�mero imprevisto";
                break;


               
        }
        return retorno;
    }

    [HttpGet]

    public string GetFor()
    {
        /*
           O Comando de repeti��o possui a seguinte sintaxe
           for(<inicializador>; <express�o condicional>; <express�o de repeti��o)
          {
          Comenados a serem executados;
          }

          inicializador: elemento contador
           express�o condicional:especifica o teste a ser verificado quando o loop estiver executado
           o n�mero definido de intera��es;]

           *express�o de repeti��o: especifica a a��o a ser executada com a variavel contadora.
           *Geralmente um acumulo ou decr�cimo (acumulador);

         */
        string retorno = string.Empty;

        for(int i = 0; i<10; i++)
        {
            retorno += $"{i};";
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
