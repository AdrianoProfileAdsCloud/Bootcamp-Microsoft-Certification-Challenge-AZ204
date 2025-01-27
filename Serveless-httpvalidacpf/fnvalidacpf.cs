using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace httpvalidacpf
{
    public static class fnvalidacpf
    {
        [FunctionName("fnvalidacpf")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Iniciando Validação do CPF");

            string name = req.Query["name"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            if (data == null)
            {
                return new BadRequestObjectResult("Informe o cpf: ");
            }
            string cpf = data?.cpf;
            if (ValidaCpf(cpf) == false)
            {
                return new BadRequestObjectResult("CPF inválido");
            }
            var responseMessage = "CPF Validado com sucesso";
            return new OkObjectResult(responseMessage);
        }

        public static bool ValidaCpf(string cpf)
        {
            // Remove caracteres não numéricos
            cpf = new string(cpf.Where(char.IsDigit).ToArray());

            // Verifica se o CPF tem 11 dígitos
            if (cpf.Length != 11)
                return false;

            // Verifica se o CPF é composto por números repetidos, como 111.111.111-11
            if (cpf.All(c => c == cpf[0]))
                return false;

            // Cálculo dos dois últimos dígitos
            int soma = 0;
            int peso = 10;

            // Calcula o primeiro dígito verificador
            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * peso--;
            }

            int digito1 = (soma * 10) % 11;
            if (digito1 == 10 || digito1 == 11)
                digito1 = 0;

            // Calcula o segundo dígito verificador
            soma = 0;
            peso = 11;
            for (int i = 0; i < 9; i++)
            {
                soma += int.Parse(cpf[i].ToString()) * peso--;
            }

            int digito2 = (soma * 10) % 11;
            if (digito2 == 10 || digito2 == 11)
                digito2 = 0;

            // Verifica se os dígitos calculados coincidem com os fornecidos
            return cpf[9] == digito1.ToString()[0] && cpf[10] == digito2.ToString()[0];
        }
    }
}
