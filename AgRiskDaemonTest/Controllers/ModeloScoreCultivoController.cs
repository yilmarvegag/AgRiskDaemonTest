using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AgRiskDaemonTest.Helpers;
using AgRiskDaemonTest.Model;
using AgRiskDaemonTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AgRiskDaemonTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModeloScoreCultivoController : ControllerBase
    {
        private readonly ILogger<ModeloScoreCultivoController> _logger;
        private readonly SalidasModeloService salidasModeloService;
        private readonly InformacionCultivoService informacionCultivoService;
        private readonly PreguntasDiagnosticasService preguntasDiagnosticasService;
        //private const string fileID = "01F6EBM7BIGKQPV7OSRJE32JQYC5MQG5OJ";


        public ModeloScoreCultivoController(ILogger<ModeloScoreCultivoController> logger)
        {
            _logger = logger;
            salidasModeloService = new SalidasModeloService();
            informacionCultivoService = new InformacionCultivoService();
            preguntasDiagnosticasService = new PreguntasDiagnosticasService();
        }

        [HttpGet]
        [Route("GetIdLibro", Name = "Get Id Libro")]
        public string GetIdLibro()
        {
            var result = "01F6EBM7BIGKQPV7OSRJE32JQYC5MQG5OJ";
            return result;
        }

        // GET: api/ModeloScoreCultivo
        // GET api/<controller>/5
        [HttpGet]
        [Route("GetSalidasModelo", Name = "Get Salidas Modelo")]
        public async Task<SalidasModelo> GetSalidasModelo(string fileID)
        {
            var result = await salidasModeloService.GetSalidasModeloAsync(fileID).ConfigureAwait(true);
            return result;
        }

        [HttpGet]
        [Route("GetPreguntasDiagnosticas", Name = "Get Preguntas Diagnosticas")]
        public async Task<List<PreguntaDiagnostica>> GetPreguntasDiagnosticas(string fileID)
        {
            var result = await preguntasDiagnosticasService.GetPreguntasDiagnosticasAsync(fileID).ConfigureAwait(true);
            return result;
        }

        [HttpGet]
        [Route("GetInformacionCultivo", Name = "Get informacion cultivo")]
        public async Task<InformacionCultivo> GetInformacionCultivo(string fileID)
        {
            var result = await informacionCultivoService.GetInformacionCultivoAsync(fileID).ConfigureAwait(true);
            return result;
        }

        [HttpPut]
        [Route("UpdateInformacionCultivo", Name = "Update Informacion Cultivo")]
        public async Task<InformacionCultivo> UpdateInformacionCultivo(string fileID, [FromBody] InformacionCultivo informacionCultivo)
        {
            var result = await informacionCultivoService.UpdateInformacionCultivoAsync(fileID, informacionCultivo).ConfigureAwait(true);
            return result;
        }


    }
}
