using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgRiskDaemonTest.Model
{
    public class SalidasModelo
    {
        public DateTime FechaFinVigencia { get; set; }
        public string CalificacionRiesgo { get; set; }
        public double ValorAjuste { get; set; }
        public double PorcentajeCobertura { get; set; }
        public int ValorAsegurado { get; set; }
        public double Tasa { get; set; }
        public double Deducible { get; set; }
        public double ValorPrimaSinIva { get; set; }
        public double ValorIva { get; set; }
        public double ValorPrimaSubsidiadaFinagro { get; set; }
        public double ValorPrimaAntesIvaCliente { get; set; }
        public double ValorPrimaTotalCliente { get; set; }
        public double ValorPrimaTotal { get; set; }
    }
}
