using EjercicioScheduler.Enums;
using System.Globalization;

namespace EjercicioScheduler.ProgramaScheduler
{
	internal class MetodosDescripcion
	{
		public static string Occurs_every_X_Time_on_Y_Days(Input variables)
		{
			string message_every_X_dayType = "every ";
			string message_the_dayMeses_of = "";
			string message_dayType = "";
			string message_on_daysOfWeek="";

			switch (variables.TipoTimeSteps)
			{
				case TipoTimeSteps.Daily:
					message_dayType = "day";
					break;

				case TipoTimeSteps.Weekly:
					ExcepcionesPersonalizadas.Excepciones_Weekly(variables);

					message_on_daysOfWeek = On_DayOfWeek(variables);
					message_dayType = "week";
					break;

				case TipoTimeSteps.Monthly:

					message_the_dayMeses_of = The_TipoDiaDelMes_Of(variables);
					message_dayType = "month";
					break;

				case TipoTimeSteps.Yearly:
					message_dayType = "year";
					break;
			}

			if (variables.TimeSteps > 1)
			{
				message_every_X_dayType += $"{variables.TimeSteps} " + message_dayType + "s";
			}
			else
			{
				message_every_X_dayType += message_dayType;
			}

			return $"Occurs {message_the_dayMeses_of}{message_every_X_dayType}{message_on_daysOfWeek} ";
		}

		public static string Every_X_Time_between_X_Hours(Input variables)
		{
			string message_hour_minute = variables.TipoHourSteps.ToString().ToLower(); // hour, minute or second.
			string message_at_X_Hour = "";

#pragma warning disable CS8629 // Nullable value type may be null.

			switch (variables.TipoHorarioHoras)
			{
				case TiposHorarioHoras.OnceHour:

					message_at_X_Hour = $"at {variables.OnceHour?.ToString("h:mm tt", CultureInfo.InvariantCulture).ToLower()}";
					break; // "at 04:00:00 am"

				case TiposHorarioHoras.SomeHoursADay:

					if (variables.ValueHourSteps != 1)
					{
						message_at_X_Hour = $"every {variables.ValueHourSteps} " + message_hour_minute + "s";
					}
					else
					{
						message_at_X_Hour = $"every " + message_hour_minute;
					}

					message_at_X_Hour += $" between {variables.StartHourDay?.ToString("h:mm tt", CultureInfo.InvariantCulture).ToLower()}" +
												$" and " +
												$"{variables.EndHourDay?.ToString("h:mm tt", CultureInfo.InvariantCulture).ToLower()}";
					break; // "every 2 hours between 4:00:00 am and 8:00:00 am"
			}
			return message_at_X_Hour;

#pragma warning restore CS8629
		}

		public static string The_TipoDiaDelMes_Of(Input variables)
		{
			string message_diaMeses = "the ";

			switch (variables.TipoMonthly)
			{
				case TiposMonthly.ValueDia:

					message_diaMeses += $"day {variables.ValueDiaMes}";
					break;
				case TiposMonthly.TipoDiaDelMes:

					message_diaMeses += $"{variables.PosicionEnSemana.ToString().ToLower()} {diaSemanaMonthly()}" ;
					break;
				default:
					break;
			}

			return message_diaMeses+ " of ";

			string diaSemanaMonthly()
			{
				string message_diaSemanaMonthly = variables.DiaSemanaSelected.ToString().ToLower();

				if (variables.DiaSemanaSelected is DiasSemanaSelected.weekend_day)
				{
					message_diaSemanaMonthly = "weekend day";
				}
					return message_diaSemanaMonthly;
			}
		}

		public static string On_DayOfWeek(Input variables)
		{
			DayOfWeek[] diasSemana = Input.DiasSemanaFiltered(variables.DaysAvailableWeek);

			string on_daysOfWeek = " on ";

			if (diasSemana.Length >= 2)
			{
				for (int i = 0; i < diasSemana.Length - 2; i++)
				{
					on_daysOfWeek += $"{diasSemana[i].ToString().ToLower()}, ";
				}
				on_daysOfWeek += $"{diasSemana[^2].ToString().ToLower()} and ";
			}

			on_daysOfWeek += $"{diasSemana[^1].ToString().ToLower()}";

			return on_daysOfWeek;
		}
	}
}
