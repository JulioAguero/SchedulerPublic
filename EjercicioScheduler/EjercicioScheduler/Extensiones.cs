using EjercicioScheduler.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioScheduler
{
	internal static class Extensiones
	{
		public static int SemanaDelAnho(this DateTime fecha, Input variables)
		{
			DayOfWeek typeDay;
			switch (variables.BeginningWeek)
			{
				case DayStartWeekSelected.StandardMonday:

					typeDay = DayOfWeek.Monday;
					break;
				default:

					typeDay = DayOfWeek.Sunday;
					break;
			}

			CultureInfo cul = CultureInfo.CurrentCulture;

			int fechaRetorno = cul.Calendar.GetWeekOfYear(fecha, CalendarWeekRule.FirstFullWeek, typeDay);
			return fechaRetorno;
		}
	}
}
