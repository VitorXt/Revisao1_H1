using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Revisao1.Models.Request;

namespace Revisao1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MegaSenaController : ControllerBase
    {

        private readonly string _megacaminhoArquivo;

        public MegaSenaController()
        {
            _megacaminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), "Data", "MegaSena.json");
        }

        #region Operaçoes arquivo
        private List<RegistroJogoViewModel> LerjogosDoArquivo()
        {
            if (!System.IO.File.Exists(_megacaminhoArquivo))
            {
                return new List<RegistroJogoViewModel>();
            }

            string json = System.IO.File.ReadAllText(_megacaminhoArquivo);
            return JsonConvert.DeserializeObject<List<RegistroJogoViewModel>>(json);
        }

        private void EscreverJogosNoArquivo(List<RegistroJogoViewModel> jogos)
        {
            string json = JsonConvert.SerializeObject(jogos);
            System.IO.File.WriteAllText(_megacaminhoArquivo, json);
        }

        #endregion


        [HttpPost]
        public IActionResult Post(RegistroJogoViewModel registroJogoViewModel)
        {
            
            var jogosRealizaddos = LerjogosDoArquivo();

            registroJogoViewModel.DataJogo = DateTime.Now;

            if (
                registroJogoViewModel.Numero1 != registroJogoViewModel.Numero2
                && registroJogoViewModel.Numero2 != registroJogoViewModel.Numero3
                && registroJogoViewModel.Numero3 != registroJogoViewModel.Numero4
                && registroJogoViewModel.Numero4 != registroJogoViewModel.Numero5
                && registroJogoViewModel.Numero5 != registroJogoViewModel.Numero6
               )
            {
                jogosRealizaddos.Add(registroJogoViewModel);

                EscreverJogosNoArquivo(jogosRealizaddos);

                return Ok("Jogo registrado com sucesso");
            }
            else
                throw new Exception("Jogo não pode ser realizado, pois existem nros repetidos");
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(LerjogosDoArquivo());

        }
    }
}
