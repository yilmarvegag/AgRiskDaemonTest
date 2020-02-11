using AgRiskDaemonTest.Model;
using AgRiskDaemonTest.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AgRiskDaemonTest.Services
{
    public class SalidasModeloService
    {
        public async Task<SalidasModelo> GetSalidasModeloAsync(string idArchivoLibro)
        {
            var salidaModelo = new SalidasModelo();
            var sessionInfo = await GraphHelper.CreateSession(idArchivoLibro, false);
            var result = await GraphHelper.GetRange(idArchivoLibro, "calificación de riesgo", "B49:C62", sessionInfo);
            
            //var range = getRangeTask.Result;
            var values = result.Values;
            //var ValueTypes = range.ValueTypes;

            double Jfecha = double.Parse(values[1][1].ToString());
            DateTime fecha = DateTime.FromOADate(Jfecha);

            salidaModelo.FechaFinVigencia = fecha;
            salidaModelo.CalificacionRiesgo = values[2][1].ToString();
            salidaModelo.ValorAjuste = double.Parse(values[3][1].ToString());
            salidaModelo.PorcentajeCobertura = double.Parse(values[4][1].ToString());
            salidaModelo.ValorAsegurado = int.Parse(values[5][1].ToString());
            salidaModelo.Tasa = double.Parse(values[6][1].ToString());
            salidaModelo.Deducible = double.Parse(values[7][1].ToString());
            salidaModelo.ValorPrimaSinIva = double.Parse(values[8][1].ToString());
            salidaModelo.ValorIva = double.Parse(values[9][1].ToString());
            salidaModelo.ValorPrimaSubsidiadaFinagro = double.Parse(values[10][1].ToString());
            salidaModelo.ValorPrimaAntesIvaCliente = double.Parse(values[11][1].ToString());
            salidaModelo.ValorPrimaTotalCliente = double.Parse(values[12][1].ToString());
            salidaModelo.ValorPrimaTotal = double.Parse(values[13][1].ToString());


            await GraphHelper.CloseSession(idArchivoLibro, sessionInfo);

            //pasar values al SalidasModleo
            return salidaModelo;
        }
    }
}