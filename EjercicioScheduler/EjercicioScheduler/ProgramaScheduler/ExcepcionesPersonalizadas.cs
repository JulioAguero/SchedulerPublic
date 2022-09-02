using EjercicioScheduler.Enums;

namespace EjercicioScheduler.ProgramaScheduler
{
	public class ExcepcionesPersonalizadas : Exception
	{
		public static void TodasLasExcepciones(Input data)
		{
			ExceptionStartDateNull(data);
			ExceptionIncoherentLimits(data);
		}
		public static void ExcepcionesOnce(Input data)
		{
			ExceptionFechaDadaNull(data);
			ExceptionIncoherentLimitsOnce(data);
		}
		public static void ExcepcionesRecurring(Input data)
		{
			ExceptionCurrentDateNull(data); // Tb tratada en CamposEnBlanco
			ExceptionTimeStepsZeroOrNegative(data);
		}
		public static void ExcepcionesMonthlyDiaMesSelected(Input data)
		{
			ExceptionDiaMesMonthlyNullException(data);
		}

		public static void ExcepcionesMonthlyTipoDiaMes(Input data)
		{

		}

		public static void ExcepcionesAlAcabarPrograma(Input data, DateTime fechaFinal)
		{
			ExceptionOverflowDataTime(data);
			ExceptionFechaFinalExceedEndDate(data, fechaFinal);
		}

		// Excepciones nuevas para la Parte 2.

		public static void Excepciones_OnceHour(Input data)
		{

		}

		public static void Excepciones_Weekly(Input data)
		{
			ExceptionDaysAvailableWeekValueNull(data);
		}
		public static void Excepciones_SomeHours(Input data)
		{
			ExceptionIncoherentLimitsHours(data);
			ExceptionHourStepsZeroOrNegative(data);
			ExceptionHourStepsGreaterHourRange(data);
		}

		//--------------------------------------------------------------------


		// Métodos que usa TodasLasExcepciones.
		public static void ExceptionIncoherentLimits(Input data)
		{
			if (data.StartDate > data.EndDate)
			{
				throw new ExceptionIncoherentLimits();
			}
		}
		public static void ExceptionStartDateNull(Input data)
		{
			if (data.StartDate is null)
			{
				throw new ExceptionStartDateNull();
			}
		}


		// Métodos que usa ExcepcionesOnce.

		public static void ExceptionFechaDadaNull(Input data)
		{
			if (data.FechaDada is null)
			{
				throw new ExceptionFechaDadaNull();
			}
		}
		public static void ExceptionIncoherentLimitsOnce(Input data)
		{
			if (data.FechaDada < data.StartDate || data.FechaDada > data.EndDate)
			{
				throw new ExceptionIncoherentLimitsOnce();
			}
		}

		// Métodos de Recurring.

		public static void ExceptionCurrentDateNull(Input data)
		{
			if (data.CurrentDate is null)
			{
				throw new ExceptionCurrentDateNull();
			}
		}
		public static void ExceptionTimeStepsZeroOrNegative(Input data)
		{
			if (data.TimeSteps <= 0)
			{
				throw new ExceptionTimeStepsZeroOrNegative();
			}
		}
		public static void ExceptionOverflowDataTime(Input data)
		{
			ITiposHorario objetoOnceRecurring;
			switch (data.TipoHorario)
			{
				case TiposHorarioFecha.Once:
					objetoOnceRecurring = new Once(data);

					break;
				case TiposHorarioFecha.Recurring:
					objetoOnceRecurring = new Recurring(data);

					break;
				default:
					objetoOnceRecurring = new Once(data);

					break;
			}

			try
			{
				checked { objetoOnceRecurring.FechaFinal(); }
			}
			catch (ArgumentOutOfRangeException)
			{
				throw;
			}
		}

		// Métodos de ExcepcionesRecurring

		public static void ExceptionFechaFinalExceedEndDate(Input data, DateTime fechaFinal)
		{
			if (fechaFinal > data.EndDate)
			{
				throw new ExceptionFechaFinalExceedEndDate();
			}
		}
		public static void ExceptionDaysAvailableWeekValueNull(Input data)
		{
			if (data.DaysAvailableWeek.Length == 0)
			{
				throw new ExceptionDaysAvailableWeekValueNull();
			}
		}
		public static void ExceptionIncoherentLimitsHours(Input data)
		{
			if (data.StartHourDay?.TimeOfDay > data.EndHourDay?.TimeOfDay)
			{
				throw new ExceptionIncoherentLimitsHours();
			}
		}
		public static void ExceptionHourStepsZeroOrNegative(Input data)
		{
			if (data.ValueHourSteps <= 0)
			{
				throw new ExceptionHourStepsZeroOrNegative();
			}
		}
		public static void ExceptionHourStepsGreaterHourRange(Input data)
		{
			TimeSpan? startHour = data.StartHourDay?.TimeOfDay;
			TimeSpan? endHour = data.EndHourDay?.TimeOfDay;

			int secondsHourSteps = data.ValueHourSteps * (int)data.TipoHourSteps;
			TimeSpan? hourSteps = TimeSpan.FromSeconds(secondsHourSteps);

			if (hourSteps > (endHour - startHour) && data.TipoHorarioHoras is TiposHorarioHoras.SomeHoursADay)
			{
				throw new ExceptionHourStepsGreaterHourRange();
			}
		}

		// Métodos de ExcepcionesMonthly

		public static void ExceptionDiaMesMonthlyNullException(Input data)
		{
			if (data.ValueDiaMes <=0)
			{
				throw new ExceptionDiaMesMonthlyNullException();
			}
		}
	}

	public class ExceptionIncoherentLimits : Exception
	{
		public ExceptionIncoherentLimits() : base("Los límites de la fecha seleccionada no son válidos") { }
	}

	public class ExceptionStartDateNull : Exception
	{
		public ExceptionStartDateNull() : base("No ha introducido un valor para Start." +
					" Por favor, vuelva a introducirlo correctamente.")
		{ }
	}

	public class ExceptionFechaDadaNull : Exception
	{
		public ExceptionFechaDadaNull() : base("No ha introducido un valor para DateTime en la configuracón.") { }
	}

	public class ExceptionIncoherentLimitsOnce : Exception
	{
		public ExceptionIncoherentLimitsOnce() : base("Fecha seleccionada no contenida en los límites proporcionados") { }
	}

	public class ExceptionCurrentDateNull : Exception
	{
		public ExceptionCurrentDateNull() : base("No ha introducido un valor para Current Date, o éste es previo al día de hoy." +
					" Por favor, vuelva a introducirlo correctamente.")
		{ }
	}

	public class ExceptionFechaFinalExceedEndDate : Exception
	{
		public ExceptionFechaFinalExceedEndDate() : base("La fecha resultante sería mayor que el límite superior del interfalo ofrecido.") { }
	}

	public class ExceptionTimeStepsZeroOrNegative : Exception
	{
		public ExceptionTimeStepsZeroOrNegative() : base("Se ha introducido un valor 0 o negativo en el apartado Every.") { }
	}

	public class ExceptionIncoherentLimitsHours : Exception
	{
		public ExceptionIncoherentLimitsHours() : base("El rango de horas proporcionado no es válido") { }
	}

	public class ExceptionHourStepsZeroOrNegative : Exception
	{
		public ExceptionHourStepsZeroOrNegative() : base("Debe insertar" +
										" un valor entero mayor a 0 en OccursTimeDaily")
		{ }
	}

	public class ExceptionDaysAvailableWeekValueNull : Exception
	{
		public ExceptionDaysAvailableWeekValueNull() : base("No se ha proporcionado valor de DaysAvailableWeek.") { }
	}

	public class ExceptionHourStepsGreaterHourRange : Exception
	{
		public ExceptionHourStepsGreaterHourRange() : base("La frecuencia diaria es mayor que el rango de horas seleccionado.") { }
	}

	public class ExceptionDiaMesMonthlyNullException : Exception
	{
		public ExceptionDiaMesMonthlyNullException() : base("DiaMesMonthly tiene asignado un valor nulo o negativo.") { }
	}
}