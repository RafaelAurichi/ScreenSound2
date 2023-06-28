using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound2.Models
{
    internal interface IAvaliavel
    {
        protected void AddNotas(List<double> numbers);
        protected void AddNotas(double nota);
        protected double AverageDegree();
    }
}
