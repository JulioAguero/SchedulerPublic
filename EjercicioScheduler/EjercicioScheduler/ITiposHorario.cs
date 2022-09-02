using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioScheduler
{
	internal interface ITiposHorario
	{
		Input Variables { get; set; }

		string Descripcion();
		DateTime FechaFinal();
	}
}
