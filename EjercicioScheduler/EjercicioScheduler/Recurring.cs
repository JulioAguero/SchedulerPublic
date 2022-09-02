using EjercicioScheduler.Enums;
using EjercicioScheduler.ProgramaScheduler;

namespace EjercicioScheduler
{
	internal class Recurring : ITiposHorario
	{
		public Recurring(Input variablesInput)
		{
			Variables = variablesInput;
		}

		public Input Variables { get; set; }

		public string Descripcion()
		{
			string descripcionOutput;

			switch (Variables.TipoHorarioHoras)
			{
				case TiposHorarioHoras.OnceHour:

					ExcepcionesPersonalizadas.Excepciones_OnceHour(Variables);

					descripcionOutput = $"{MetodosDescripcion.Occurs_every_X_Time_on_Y_Days(Variables)}" +
												$"{MetodosDescripcion.Every_X_Time_between_X_Hours(Variables)} " +
														$"starting on {Variables.StartDate?.ToString("dd/MM/yyyy")}";
					return descripcionOutput;

				case TiposHorarioHoras.SomeHoursADay:

					ExcepcionesPersonalizadas.Excepciones_SomeHours(Variables);

					descripcionOutput = $"{MetodosDescripcion.Occurs_every_X_Time_on_Y_Days(Variables)}" +
												$"{MetodosDescripcion.Every_X_Time_between_X_Hours(Variables)} " +
														$"starting on {Variables.StartDate?.ToString("dd/MM/yyyy")}";
					return descripcionOutput;

				default:
					throw new ArgumentException();
			}
		}

		public DateTime FechaFinal()
		{
			DateTime nextFecha = (DateTime)Variables.CurrentDate;

			if (Variables.TipoHorarioHoras is TiposHorarioHoras.OnceHour)
			{
				Variables.EndHourDay = Variables.OnceHour;
			}

			switch (Variables.TipoTimeSteps) // Cambio día
			{
				case TipoTimeSteps.Daily:
					nextFecha = MetodosDias.SiguienteDiaDaily(Variables, nextFecha);
					break;
				case TipoTimeSteps.Weekly:
					nextFecha = MetodosDias.SiguienteDiaWeekly(Variables, nextFecha);
					break;
				case TipoTimeSteps.Monthly:
					nextFecha = MetodosDias.SiguienteDiaMonthly(Variables, nextFecha);
					break;
				case TipoTimeSteps.Yearly:
					nextFecha = MetodosDias.SiguienteDiaYearly(Variables, nextFecha);
					break;
			}

			switch (Variables.TipoHorarioHoras) // Cambio hora
			{
				case TiposHorarioHoras.OnceHour:
					DateTime onceHour = (DateTime)Variables.OnceHour;

					nextFecha = nextFecha.Date.Add(onceHour.TimeOfDay);
					break;
				case TiposHorarioHoras.SomeHoursADay:
					nextFecha = MetodosHoras.AvanzaHoras(Variables, nextFecha);
					break;
				default:
					throw new ArgumentException();
			}
			return nextFecha;
		}
	}
}
