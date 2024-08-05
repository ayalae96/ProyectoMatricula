using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoMatricula.UtilidadesSQL
{
    public class DatoSQL
    {
        TipoDato tipoDato;
        object? variableLocal;
        string variableSQL;

        public DatoSQL(TipoDato tipoDato, object? variableLocal, string variableSQL)
        {
            this.TipoDato = tipoDato;
            this.VariableLocal = variableLocal;
            this.VariableSQL = variableSQL;
        }

        public TipoDato TipoDato { get => tipoDato; set => tipoDato = value; }
        public object? VariableLocal { get => variableLocal; set => variableLocal = value; }
        public string VariableSQL { get => variableSQL; set => variableSQL = value; }
    }
}

