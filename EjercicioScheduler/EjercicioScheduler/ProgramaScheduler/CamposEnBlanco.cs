using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioScheduler.ProgramaScheduler
{
	public static class CamposEnBlanco
	{
		public static Input InputCorregido(Input variables)
		{
			if (variables.CurrentDate is null && variables.TipoHorario is Enums.TiposHorarioFecha.Recurring)
			{
				throw new ExceptionCurrentDateNull();
			}

			if (variables.EndDate is null)
			{
				variables.EndDate = DateTime.MaxValue;
			}

			if (variables.StartHourDay is null)
			{
				variables.StartHourDay = new DateTime(1990, 1, 1, 0, 0, 0);
			}

			if (variables.EndHourDay is null)
			{
				variables.EndHourDay = new DateTime(1990, 1, 1, 23, 59, 59);
			}

			return variables;
		}

		// Hay algunos campos del Scheduler que pueden permanecer en blanco. Aquí se tratan esos casos para
		// que el programa, pese a no recibir ciertos parámetros, siga funcionando.

		// Campos que pueden estar en blanco: 

		// - StartDate¿?, EndDate, StartHourDay, EndHourDay. En este caso el programa no sufre problemas,
		// no utiliza los campos explicitamente salvo en el caso de StartDate.
	}
}
