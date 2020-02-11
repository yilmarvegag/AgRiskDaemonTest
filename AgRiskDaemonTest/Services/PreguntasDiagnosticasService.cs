using AgRiskDaemonTest.Model;
using AgRiskDaemonTest.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AgRiskDaemonTest.Services
{
    public class PreguntasDiagnosticasService
    {
        public async Task<List<PreguntaDiagnostica>> GetPreguntasDiagnosticasAsync(string idArchivoLibro)
        {
            var sessionInfo = await GraphHelper.CreateSession(idArchivoLibro, false);
            var result = await GraphHelper.GetRange(idArchivoLibro, "calificación de riesgo", "B37:H44", sessionInfo);

            var values = result.Values;

            List<PreguntaDiagnostica> ListaDePreguntas = new List<PreguntaDiagnostica>();

            for (int i = 3; i < values.Count(); i++)
            {
                var preguntadiagnostica = new PreguntaDiagnostica();

                preguntadiagnostica.IdPregunta = int.Parse(values[i][0].ToString());
                preguntadiagnostica.Pregunta = values[i][1].ToString();
                preguntadiagnostica.Respuesta = values[i][2].ToString();

                ListaDePreguntas.Add(preguntadiagnostica);
            }

            await GraphHelper.CloseSession(idArchivoLibro, sessionInfo);

            return ListaDePreguntas;
        }
    }
}