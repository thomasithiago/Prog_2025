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
           Estrutura sintática do if
        if(expressão booleana)
        {
        sentença de código a ser executada se a expressão for verdadeira
        
        }

         Caso o if tenha apenas uma linha de comando a ser executada na condicional, não há 
         necessidade de utilizar chaves
         if(expressão booleana)
            Apenas um comando 

         */

        string retorno = string.Empty;
        //int x = 10;
        if (x < 9)
            retorno = "x é maior que 9";

        x = 8;
        if (x > 9)
            retorno = "x é maior que 9";
        else
            retorno = "x é menor que 9";
        x = 11;
        if (x == 10)
        {
            retorno = "Ora ora";
            retorno += " x é igual a 10";
        }
        else if (x == 9)
        {
            retorno = "Ora ora";
            retorno += " x é igual a 9";
        }
        else if (x == 8)
        {
            retorno = "Hmmmmm";
            retorno += " x é igual a 9";
        }
        else if (x == 8)
        {
            retorno = "Bahhhh";
            retorno += " x é igual a 8 tchê";
        }
        else
        {
            retorno = "Sei lá que número é x";
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
                retorno = "x é zero";
                break;

            case 1:
                retorno = "x é um";
                break;

            case 2:
                retorno = "x é dois";
                break;

            case 3:
                retorno = "x é três";
                break;
            default:
                retorno = "x é um número imprevisto";
                break;


               
        }
        return retorno;
    }

    [HttpGet]

    public string GetFor()
    {
        /*
           O Comando de repetição possui a seguinte sintaxe
           for(<inicializador>; <expressão condicional>; <expressão de repetição)
          {
          Comenados a serem executados;
          }

          inicializador: elemento contador
           expressão condicional:especifica o teste a ser verificado quando o loop estiver executado
           o número definido de interações;]

           *expressão de repetição: especifica a ação a ser executada com a variavel contadora.
           *Geralmente um acumulo ou decrécimo (acumulador);

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
