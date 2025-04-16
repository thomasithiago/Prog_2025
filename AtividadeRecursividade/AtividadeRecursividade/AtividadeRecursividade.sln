using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace Recursividade.Controllers
{
    public class RecursividadeController : Controller 
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Atividade1(int n) 
        {
            StringBuilder resultado = new StringBuilder();
            NumerosDecrescentes(n, resultado);
            ViewBag.Resultado = resultado.ToString();
            return View(); 
        }

        public void NumerosDecrescentes(int atual, StringBuilder resultado)
        {
            if (atual >= 1)
            {
                resultado.Append(atual).Append(" ");
                NumerosDecrescentes(atual - 1, resultado);
            }
        }

        [HttpPost]
        public IActionResult Atividade2(int n)
        {
            StringBuilder resultado = new StringBuilder();
            NumerosCrescentes(n, resultado);
            ViewBag.Resultado = resultado.ToString();
            return View();
        }

        private void NumerosCrescentes(int n, StringBuilder resultado)
        {
            int soma = 0;
            for (int i = 1; i <= n; i++)
            {
                resultado.Append(i);

                if (i < n)
                {
                    resultado.Append(" + ");
                }

                soma += i;
            }

            resultado.Append(" = ").Append(soma);
        }

        [HttpPost]
        public IActionResult Atividade3(string texto)
        {
            int quantidade = ContarCaracteresRecursivo(texto);
            ViewBag.Quantidade = quantidade;
            ViewBag.TextoOriginal = texto;
            return View("Atividade3");
        }

        private int ContarCaracteresRecursivo(string texto)
        {
            if (string.IsNullOrEmpty(texto))
            {
                return 0;
            }
            else
            {
                return 1 + ContarCaracteresRecursivo(texto.Substring(1));
            }
        }

        [HttpPost]
        public IActionResult Atividade4(string palavra)
        {
            bool ehPalindromo = EhPalindromoRecursivo(palavra);
            ViewBag.Palavra = palavra;
            ViewBag.Resultado = ehPalindromo ? "é um palíndromo" : "não é um palíndromo";
            return View("Atividade4");
        }

        private bool EhPalindromoRecursivo(string palavra)
        {
          
            if (string.IsNullOrEmpty(palavra) || palavra.Length == 1)
            {
                return true;
            }

            
            if (palavra[0] != palavra[^1])
            {
                return false;
            }

            
            return EhPalindromoRecursivo(palavra.Substring(1, palavra.Length - 2));
        }
    }
}
