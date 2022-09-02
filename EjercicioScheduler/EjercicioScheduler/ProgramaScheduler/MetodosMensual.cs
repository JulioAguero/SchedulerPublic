using EjercicioScheduler.Enums;

namespace EjercicioScheduler.ProgramaScheduler
{
	public class MetodosMensual
	{
		public static DateTime DiaMesDisponibleValue(Input variables, DateTime nextFecha)
		{
			TimeSpan endTime = ((DateTime)variables.EndHourDay).TimeOfDay;
			TimeSpan restoSteps = variables.RestoEndHour;

			int lastDay = DateTime.DaysInMonth(nextFecha.Year, nextFecha.Month);

			int diaDisponible = DiaMesPosible(variables, nextFecha);

			if (nextFecha.Day == diaDisponible && variables.CurrentDate?.TimeOfDay >= endTime - restoSteps)
			{
				nextFecha = nextFecha.AddMonths(variables.TimeSteps);
			}
			else if (nextFecha.Day > diaDisponible)
			{
				nextFecha = nextFecha.AddMonths(1);
			}

			lastDay = DateTime.DaysInMonth(nextFecha.Year, nextFecha.Month);
			diaDisponible = DiaMesPosible(variables, nextFecha);

			nextFecha = nextFecha.AddDays(-nextFecha.Day + diaDisponible);
			return nextFecha;

			int DiaMesPosible(Input variables, DateTime fecha)
			{
				int valorPosible = variables.ValueDiaMes;
				if (variables.ValueDiaMes > lastDay)
				{
					valorPosible = lastDay;
				}
				return valorPosible;
			}
		}

		public static DateTime DiaMesDisponibleTipo(Input variables, DateTime nextFecha)
		{
			DateTime cambioFecha = CambioDiaMes(variables, nextFecha);

			TimeSpan endTime = ((DateTime)variables.EndHourDay).TimeOfDay;
			TimeSpan restoSteps = variables.RestoEndHour;

			if (nextFecha.Date < cambioFecha.Date)
			{
				nextFecha = cambioFecha;
			}
			else if (nextFecha.Date == cambioFecha.Date && variables.CurrentDate?.TimeOfDay >= endTime - restoSteps)
			{
				nextFecha = nextFecha.AddMonths(variables.TimeSteps);
				nextFecha = CambioDiaMes(variables, nextFecha);
			}
			else if (nextFecha.Date > cambioFecha.Date)
			{
				nextFecha = nextFecha.AddMonths(1);
				nextFecha = CambioDiaMes(variables, nextFecha);
			}
			return nextFecha;
		}

		public static DateTime CambioDiaMes(Input variables, DateTime nextFecha)
		{
			DateTime fechaDelMes = nextFecha;

			switch (variables.DiaSemanaSelected)
			{
				case DiasSemanaSelected.day:

					fechaDelMes = DayDiaSemanaSelected(variables, fechaDelMes);
					break;
				case DiasSemanaSelected.weekday:

					fechaDelMes = WeekdayDiaSemanaSelected(variables, fechaDelMes);
					break;
				case DiasSemanaSelected.weekend_day:

					fechaDelMes = WeekendDiaSemanaSelected(variables, fechaDelMes);
					break;
				default:

					fechaDelMes = DiaDeSemana(variables, fechaDelMes);
					break;
			}
			return fechaDelMes;
		}

		public static DateTime DayDiaSemanaSelected(Input variables, DateTime nextFecha)
		{
			TimeSpan endTime = ((DateTime)variables.EndHourDay).TimeOfDay;
			TimeSpan restoSteps = variables.RestoEndHour;

			if (nextFecha.Day == diaPosible().Day && variables.CurrentDate?.TimeOfDay >= endTime - restoSteps)
			{
				nextFecha = nextFecha.AddMonths(variables.TimeSteps);
			}
			else if (nextFecha.Day > diaPosible().Day)
			{
				nextFecha = nextFecha.AddMonths(1);
			}
			nextFecha = diaPosible();
			return nextFecha;

			DateTime diaPosible()
			{
				DateTime diaActualizado = nextFecha.AddDays(-nextFecha.Day + 1);

				if (variables.PosicionEnSemana == PosicionesEnSemana.Last)
				{
					int lastDay = DateTime.DaysInMonth(diaActualizado.Year, diaActualizado.Month);
					diaActualizado = diaActualizado.AddDays(-1 + lastDay);
				}
				else
				{
					for (int i = 1; i < (int)variables.PosicionEnSemana; i++)
					{
						diaActualizado = diaActualizado.AddDays(1);
					}
				}
				return diaActualizado;
			}
		}

		public static DateTime WeekdayDiaSemanaSelected(Input variables, DateTime nextFecha)
		{
			TimeSpan endTime = ((DateTime)variables.EndHourDay).TimeOfDay;
			TimeSpan restoSteps = variables.RestoEndHour;

			if (nextFecha.Day == diaPosible().Day && variables.CurrentDate?.TimeOfDay >= endTime - restoSteps)
			{
				nextFecha = nextFecha.AddMonths(variables.TimeSteps);
			}
			else if (nextFecha.Day > diaPosible().Day)
			{
				nextFecha = nextFecha.AddMonths(1);
			}
			nextFecha = diaPosible();
			return nextFecha;

			DateTime diaPosible()
			{
				DateTime diaActualizado = nextFecha.AddDays(-nextFecha.Day + 1);

				if (variables.PosicionEnSemana == PosicionesEnSemana.Last)
				{
					int lastDay = DateTime.DaysInMonth(diaActualizado.Year, diaActualizado.Month);
					diaActualizado = diaActualizado.AddDays(lastDay - 1);

					while (diaActualizado.DayOfWeek == DayOfWeek.Saturday || diaActualizado.DayOfWeek == DayOfWeek.Sunday)
					{
						diaActualizado = diaActualizado.AddDays(-1);
					}
					return diaActualizado;
				}

				for (int i = 1; i < (int)variables.PosicionEnSemana; i++)
				{
					while (diaActualizado.DayOfWeek == DayOfWeek.Saturday || diaActualizado.DayOfWeek == DayOfWeek.Sunday)
					{
						diaActualizado = diaActualizado.AddDays(1);
					}
					diaActualizado = diaActualizado.AddDays(1);
				}
				while (diaActualizado.DayOfWeek == DayOfWeek.Saturday || diaActualizado.DayOfWeek == DayOfWeek.Sunday)
				{
					diaActualizado = diaActualizado.AddDays(1);
				}

				return diaActualizado;
			}
		}

		public static DateTime WeekendDiaSemanaSelected(Input variables, DateTime nextFecha)
		{
			TimeSpan endTime = ((DateTime)variables.EndHourDay).TimeOfDay;
			TimeSpan restoSteps = variables.RestoEndHour;

			if (nextFecha.Day == diaPosible().Day && variables.CurrentDate?.TimeOfDay >= endTime - restoSteps)
			{
				nextFecha = nextFecha.AddMonths(variables.TimeSteps);
			}
			else if (nextFecha.Day > diaPosible().Day)
			{
				nextFecha = nextFecha.AddMonths(1);
			}
			nextFecha = diaPosible();
			return nextFecha;

			DateTime diaPosible()
			{
				DateTime diaActualizado = nextFecha.AddDays(-nextFecha.Day + 1);

				if (variables.PosicionEnSemana == PosicionesEnSemana.Last)
				{
					int lastDay = DateTime.DaysInMonth(diaActualizado.Year, diaActualizado.Month);
					diaActualizado = diaActualizado.AddDays(lastDay - 1);

					while (diaActualizado.DayOfWeek != DayOfWeek.Saturday && diaActualizado.DayOfWeek != DayOfWeek.Sunday)
					{
						diaActualizado = diaActualizado.AddDays(-1);
					}
					return diaActualizado;
				}

				for (int i = 1; i < (int)variables.PosicionEnSemana; i++)
				{
					while (diaActualizado.DayOfWeek != DayOfWeek.Saturday && diaActualizado.DayOfWeek != DayOfWeek.Sunday)
					{
						diaActualizado = diaActualizado.AddDays(1);
					}
					diaActualizado = diaActualizado.AddDays(1);
				}
				while (diaActualizado.DayOfWeek != DayOfWeek.Saturday && diaActualizado.DayOfWeek != DayOfWeek.Sunday)
				{
					diaActualizado = diaActualizado.AddDays(1);
				}

				return diaActualizado;
			}
		}

		public static DateTime DiaDeSemana(Input variables, DateTime fechaDelMes)
		{
			DateTime primeroMes = fechaDelMes.AddDays(1 - fechaDelMes.Day);
			if (variables.PosicionEnSemana == PosicionesEnSemana.Last)
			{
				int lastDay = DateTime.DaysInMonth(fechaDelMes.Year, fechaDelMes.Month);
				fechaDelMes = primeroMes.AddDays(-1 + lastDay);

				while (fechaDelMes.DayOfWeek != DiaSemanaMonthly(variables))
				{
					fechaDelMes = fechaDelMes.AddDays(-1);
				}
				return fechaDelMes;
			}

			while (primeroMes.DayOfWeek != DiaSemanaMonthly(variables))
			{
				primeroMes = primeroMes.AddDays(1);
			}
			for (int i = 1; i < (int)variables.PosicionEnSemana; i++)
			{
				primeroMes = primeroMes.AddDays(7);
			}
			fechaDelMes = primeroMes;
			return fechaDelMes;
		}

		public static DayOfWeek DiaSemanaMonthly(Input variables)
		{
			string dia = variables.DiaSemanaSelected.ToString();
			DayOfWeek diaSemana = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), dia);
			return diaSemana;
		}
	}
}