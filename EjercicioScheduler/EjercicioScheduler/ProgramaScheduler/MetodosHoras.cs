using EjercicioScheduler.Enums;

namespace EjercicioScheduler.ProgramaScheduler
{
	public class MetodosHoras
	{
		public static DateTime AvanzaHoras(Input variables, DateTime fechaDada)
		{
			

			TimeSpan currentTime = ((DateTime)variables.CurrentDate).TimeOfDay;
			TimeSpan startTime = ((DateTime)variables.StartHourDay).TimeOfDay;
			TimeSpan endTime = ((DateTime)variables.EndHourDay).TimeOfDay;

			if (variables.CurrentDate != fechaDada)
			{
				return fechaDada.Date + startTime;
			}

			int hourStepsInSeconds = variables.ValueHourSteps * (int)variables.TipoHourSteps;

			int currentDateSeconds = Input.SecondsOfDayHour(currentTime);
			int startHourSeconds = Input.SecondsOfDayHour(startTime);
			int endHourSeconds = Input.SecondsOfDayHour(endTime);

			int resto = (endHourSeconds - startHourSeconds) % hourStepsInSeconds;
			TimeSpan restoSteps = TimeSpan.FromSeconds(resto);

			int stepsToOverpassCurrent = 1 + (currentDateSeconds - startHourSeconds) / hourStepsInSeconds;
			
			if (stepsToOverpassCurrent < 0)
			{
				stepsToOverpassCurrent = 0;
			}

			TimeSpan timeStepsToOverpassCurrent = TimeSpan.FromSeconds(stepsToOverpassCurrent * hourStepsInSeconds);
			TimeSpan nextTime = startTime + timeStepsToOverpassCurrent;

			if (nextTime <= endTime - restoSteps && nextTime.Days == 0)
			{
				 return fechaDada.Date + nextTime;
			}
			return fechaDada.Date.Add(startTime);
		}
	}
}
