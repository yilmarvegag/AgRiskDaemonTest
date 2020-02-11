using AgRiskDaemonTest.Model;
using AgRiskDaemonTest.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AgRiskDaemonTest.Services
{
    public class InformacionCultivoService
    {
        public async Task<InformacionCultivo> GetInformacionCultivoAsync(string idArchivoLibro)
        {
            var sessionInfo = await GraphHelper.CreateSession("01PGXMMU5FTPPGEHFQVBEJTQU5FQ72HO7O", false);
            var result = await GraphHelper.GetRange("01PGXMMU5FTPPGEHFQVBEJTQU5FQ72HO7O", "calificación de riesgo", "B3:C21", sessionInfo);

             var values = result.Values;

            var informacionCultivo = new InformacionCultivo();
            informacionCultivo.ValidacionDatos = values[0][1].ToString();
            informacionCultivo.IdVereda = int.Parse(values[2][1].ToString());
            informacionCultivo.IdSistema = int.Parse(values[4][1].ToString());
            informacionCultivo.IdCultivo = int.Parse(values[6][1].ToString());
            informacionCultivo.AreaCultivo = double.Parse(values[8][1].ToString());
            informacionCultivo.TamanoProductor = int.Parse(values[10][1].ToString());
            informacionCultivo.CostoProduccion = int.Parse(values[12][1].ToString());
            informacionCultivo.Cosecha = int.Parse(values[14][1].ToString());
            informacionCultivo.FechaInicioVigenia = ParseFecha(values[16][1].ToString());
            informacionCultivo.FechaFinalVigencia = ParseFecha(values[18][1].ToString());

            await GraphHelper.CloseSession("01PGXMMU5FTPPGEHFQVBEJTQU5FQ72HO7O", sessionInfo);

            return informacionCultivo;
        }

        public async Task<InformacionCultivo> UpdateInformacionCultivoAsync(string idArchivoLibro, InformacionCultivo informacionCultivoUpdate)
        {
            var sessionInfo = await GraphHelper.CreateSession("01PGXMMU5FTPPGEHFQVBEJTQU5FQ72HO7O", true);
            
            //var workbookCell = await GraphHelper.GetCell("01PGXMMU5FTPPGEHFQVBEJTQU5FQ72HO7O", "calificación de riesgo", 10,2, sessionInfo);
            //workbookCell.Values[0][0] = 350;

            //var workbookCellUpdated = await GraphHelper.PatchCell("01PGXMMU5FTPPGEHFQVBEJTQU5FQ72HO7O", "calificación de riesgo", 10,2, workbookCell, sessionInfo);

            var workbookRange = await GraphHelper.GetRange("01PGXMMU5FTPPGEHFQVBEJTQU5FQ72HO7O", "calificación de riesgo", "B3:C21", sessionInfo);
            var values = workbookRange.Values;


            var informacionCultivoUpdated = new InformacionCultivo();
            var informacionCultivo = new InformacionCultivo();

            informacionCultivo.ValidacionDatos = values[0][1].ToString();
            informacionCultivo.IdVereda = int.Parse(values[2][1].ToString());
            informacionCultivo.IdSistema = int.Parse(values[4][1].ToString());
            informacionCultivo.IdCultivo = int.Parse(values[6][1].ToString());
            informacionCultivo.AreaCultivo = double.Parse(values[8][1].ToString());
            informacionCultivo.TamanoProductor = int.Parse(values[10][1].ToString());
            informacionCultivo.CostoProduccion = int.Parse(values[12][1].ToString());
            informacionCultivo.Cosecha = int.Parse(values[14][1].ToString());
            informacionCultivo.FechaInicioVigenia = ParseFecha(values[16][1].ToString());
            informacionCultivo.FechaFinalVigencia = ParseFecha(values[18][1].ToString());

            if (informacionCultivo.ValidacionDatos != informacionCultivoUpdate.ValidacionDatos)
            {
                values[0][1] = informacionCultivoUpdate.ValidacionDatos;
            }
            if (informacionCultivo.IdVereda != informacionCultivoUpdate.IdVereda)
            {
                values[2][1] = informacionCultivoUpdate.IdVereda;
            }
            if (informacionCultivo.IdSistema != informacionCultivoUpdate.IdSistema)
            {
                values[4][1] = informacionCultivoUpdate.IdSistema;
            }
            if (informacionCultivo.IdCultivo != informacionCultivoUpdate.IdCultivo)
            {
                values[6][1] = informacionCultivoUpdate.IdCultivo;
            }
            if (informacionCultivo.AreaCultivo != informacionCultivoUpdate.AreaCultivo)
            {
                values[8][1] = informacionCultivoUpdate.AreaCultivo;
            }
            if (informacionCultivo.TamanoProductor != informacionCultivoUpdate.TamanoProductor)
            {
                values[10][1] = informacionCultivoUpdate.TamanoProductor;
            }
            if (informacionCultivo.CostoProduccion != informacionCultivoUpdate.CostoProduccion)
            {
                values[12][1] = informacionCultivoUpdate.CostoProduccion;
            }
            if (informacionCultivo.Cosecha != informacionCultivoUpdate.Cosecha)
            {
                values[14][1] = informacionCultivoUpdate.Cosecha;
            }
            if (informacionCultivo.FechaInicioVigenia != informacionCultivoUpdate.FechaInicioVigenia)
            {
                values[16][1] = informacionCultivoUpdate.FechaInicioVigenia.ToOADate();
            }
            if (informacionCultivo.FechaFinalVigencia != informacionCultivoUpdate.FechaFinalVigencia)
            {
                values[18][1] = informacionCultivoUpdate.FechaFinalVigencia.ToOADate();
            }

            var workbookRangeUpdated = await GraphHelper.PatchRange("01PGXMMU5FTPPGEHFQVBEJTQU5FQ72HO7O", "calificación de riesgo", "B3:C21", workbookRange, sessionInfo);
            var updatedValues = workbookRangeUpdated.Values;

            informacionCultivoUpdated.ValidacionDatos = updatedValues[0][1].ToString();
            informacionCultivoUpdated.IdVereda = int.Parse(updatedValues[2][1].ToString());
            informacionCultivoUpdated.IdSistema = int.Parse(updatedValues[4][1].ToString());
            informacionCultivoUpdated.IdCultivo = int.Parse(updatedValues[6][1].ToString());
            informacionCultivoUpdated.AreaCultivo = double.Parse(updatedValues[8][1].ToString());
            informacionCultivoUpdated.TamanoProductor = int.Parse(updatedValues[10][1].ToString());
            informacionCultivoUpdated.CostoProduccion = int.Parse(updatedValues[12][1].ToString());
            informacionCultivoUpdated.Cosecha = int.Parse(updatedValues[14][1].ToString());
            informacionCultivoUpdated.FechaInicioVigenia = ParseFecha(updatedValues[16][1].ToString());
            informacionCultivoUpdated.FechaFinalVigencia = ParseFecha(updatedValues[18][1].ToString());

            await GraphHelper.CloseSession("01PGXMMU5FTPPGEHFQVBEJTQU5FQ72HO7O", sessionInfo);

            return informacionCultivoUpdated;
        }

        public static DateTime ParseFecha(string DateToPar)
        {
            double Jfecha = double.Parse(DateToPar);
            DateTime fecha = DateTime.FromOADate(Jfecha);

            return fecha;
        }
    }
}