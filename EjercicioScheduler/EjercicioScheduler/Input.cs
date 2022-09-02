using EjercicioScheduler.Enums;
using System.Globalization;

namespace EjercicioScheduler
{
	public class Input
	{
		public DateTime? CurrentDate { get; set; }
		public DateTime? FechaDada { get; set; }
		public TiposHorarioFecha TipoHorario { get; set; }
		public TipoTimeSteps TipoTimeSteps { get; set; }
		public int TimeSteps { get; set; }
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }

		// Nuevas variables de la parte 2.

		public DayOfWeek[] DaysAvailableWeek { get; set; }
		public TiposHorarioHoras TipoHorarioHoras { get; set; }
		public DateTime? OnceHour { get; set; }
		public HourMinSecSelected TipoHourSteps { get; set; }
		public int ValueHourSteps { get; set; }
		public DateTime? StartHourDay { get; set; }
		public DateTime? EndHourDay { get; set; }
		public TimeSpan RestoEndHour => RestoToEndHour();
		public DayStartWeekSelected? BeginningWeek { get; set; }/* = DayStartWeekSelected.StandardMonday;*/

		// Nuevas variables de la parte 3.

		public TiposMonthly TipoMonthly { get; set; }
		public int ValueDiaMes { get; set; }
		public PosicionesEnSemana PosicionEnSemana { get; set; }
		public DiasSemanaSelected DiaSemanaSelected { get; set; }


		// Métodos propios de la clase.

		public static DayOfWeek[] DiasSemanaFiltered(DayOfWeek[] DaysAvailableWeek)
		{
			var dia = DaysAvailableWeek
			.Distinct()
			.Select(x => (x, (int)x))
			.OrderBy(p => p.Item2);
			int j = 0;
			DayOfWeek[] diaSemana = new DayOfWeek[DaysAvailableWeek.Distinct().Count()];

			foreach (var item in dia)
			{
				diaSemana[j] = item.Item1;
				j++;
			}
			return diaSemana;
		}
		public static int StepsInADay(Input VariablesInput)
		{
			if (VariablesInput.TipoHorarioHoras == TiposHorarioHoras.SomeHoursADay)
			{
				DateTime nextFecha = ((DateTime)VariablesInput.CurrentDate);

				DateTime startHourDate = ((DateTime)VariablesInput.StartHourDay);
				DateTime endHourDate = ((DateTime)VariablesInput.EndHourDay);

				int startHour = startHourDate.Hour * 3600 + startHourDate.Minute * 60 + startHourDate.Second;
				int endHour = endHourDate.Hour * 3600 + endHourDate.Minute * 60 + endHourDate.Second;

				double totalStepsHourDouble = (double)(endHour - startHour) / (VariablesInput.ValueHourSteps
																					* (int)VariablesInput.TipoHourSteps);
				int totalStepsInADay = (int)Math.Floor(totalStepsHourDouble);

				return totalStepsInADay;
			}
			return 0;
		}
		public static int SecondsOfDayHour(TimeSpan horas)
		{
			int horasASegundos = horas.Hours * 3600 + horas.Minutes * 60 + horas.Seconds;
			return horasASegundos;
		}

		public TimeSpan RestoToEndHour()
		{
			if (TipoHorarioHoras is TiposHorarioHoras.OnceHour)
			{
				EndHourDay = OnceHour;
			}

			TimeSpan endTime = ((DateTime)EndHourDay).TimeOfDay;
			TimeSpan startTime = ((DateTime)StartHourDay).TimeOfDay;
			int startSec = SecondsOfDayHour(startTime);
			int endSec = SecondsOfDayHour(endTime);

			int hourStepsInSeconds = ValueHourSteps * (int)TipoHourSteps;
			TimeSpan restoSteps = new TimeSpan(0, 0, 0, 0);

			if (TipoHorarioHoras is TiposHorarioHoras.SomeHoursADay)
			{
				int resto = (endSec - startSec) % hourStepsInSeconds;
				restoSteps = TimeSpan.FromSeconds(resto);
			}
			return restoSteps;
		}
	}
}

