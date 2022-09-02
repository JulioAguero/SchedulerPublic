using EjercicioScheduler.Enums;

namespace EjercicioScheduler.ProgramaScheduler
{
	public class MetodosDias
	{
		public static DateTime SiguienteDiaDaily(Input variables, DateTime nextFecha)
		{
			TimeSpan endTime = ((DateTime)variables.EndHourDay).TimeOfDay;
			TimeSpan nextTime = nextFecha.TimeOfDay;
			TimeSpan restoSteps = variables.RestoEndHour;

			if (nextTime >= endTime - restoSteps)
			{
				nextFecha = nextFecha.AddDays(variables.TimeSteps);
			}
			return nextFecha;
		}

		public static DateTime SiguienteDiaWeekly(Input variables, DateTime nextFecha)
		{
			DateTime currentDate = (DateTime)variables.CurrentDate;
			TimeSpan endTime = ((DateTime)variables.EndHourDay).TimeOfDay;
			TimeSpan restoSteps = variables.RestoEndHour;

			if (currentDate.TimeOfDay >= endTime - restoSteps || !DiaSemanaPermitido(variables, currentDate))
			{
				nextFecha = nextFecha.AddDays(1);
				nextFecha = IrADiaDisponible(variables, nextFecha);
			}

			if (nextFecha.SemanaDelAnho(variables) != currentDate.SemanaDelAnho(variables)) // && currentDate.TimeOfDay == endTime - restoSteps
																							// && DiaSemanaPermitido(variables, currentDate)
			{
				nextFecha = nextFecha.AddDays(variables.TimeSteps * 7 - 7);
			}
			return nextFecha;
		}

		public static DateTime SiguienteDiaMonthly(Input variables, DateTime nextFecha)
		{
			switch (variables.TipoMonthly)
			{
				case TiposMonthly.ValueDia:
					nextFecha = MetodosMensual.DiaMesDisponibleValue(variables, nextFecha);
					break;
				case TiposMonthly.TipoDiaDelMes:
					nextFecha = MetodosMensual.DiaMesDisponibleTipo(variables, nextFecha);
					break;
			}

			return nextFecha;
		}

		public static DateTime SiguienteDiaYearly(Input variables, DateTime nextFecha)
		{
			TimeSpan endTime = ((DateTime)variables.EndHourDay).TimeOfDay;
			DateTime currentDate = (DateTime)variables.CurrentDate;
			TimeSpan restoSteps = variables.RestoEndHour;

			if (nextFecha.TimeOfDay >= endTime - restoSteps)
			{
				nextFecha = nextFecha.AddDays(1);
			}

			if (currentDate.TimeOfDay == (endTime - restoSteps) && nextFecha.Year > currentDate.Year)
			{
				nextFecha = nextFecha.AddYears(variables.TimeSteps - 1);
			}
			return nextFecha;
		}

		public static DateTime IrADiaDisponible(Input variables, DateTime nextFecha)
		{
			for (byte i = 0; i < 7; i++)
			{
				if (DiaSemanaPermitido(variables, nextFecha.AddDays(i)))
				{
					return nextFecha.AddDays(i);
				}
			}
			throw new ArgumentException();
		}

		public static bool DiaSemanaPermitido(Input variables, DateTime fechaDada)
		{
			DayOfWeek[] diasFiltrados = Input.DiasSemanaFiltered(variables.DaysAvailableWeek);

			for (byte j = 0; j < diasFiltrados.Length; j++)
			{
				if (diasFiltrados[j] == fechaDada.DayOfWeek)
				{
					return true;
				}
			}
			return false;
		}
	}
}