using FluentAssertions;
using EjercicioScheduler;
using EjercicioScheduler.Enums;
using EjercicioScheduler.ProgramaScheduler;
using Xunit;

namespace Testing.TestsScheduler.Recurring
{
	public class GeneralRecurring
	{
		[Fact]
		public void CurrentDate_Null_Recurring_Excepcion()
		{
			Input entrada = new Input()
			{
				CurrentDate = null,
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Daily,
				TimeSteps = 1,
				StartDate = new DateTime(2020, 1, 1)
			};
			Assert.Throws<ExceptionCurrentDateNull>(() => Ejecutar.ProgramaScheduler(entrada));
		}

		[Fact]
		public void TimeSteps_Zero_Or_Negative_Exception()
		{
			Input entrada = new Input()
			{
				CurrentDate = new DateTime(2020, 1, 4),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Daily,
				TimeSteps = 0,
				StartDate = new DateTime(2020, 1, 1),
			};
			Assert.Throws<ExceptionTimeStepsZeroOrNegative>(() => Ejecutar.ProgramaScheduler(entrada));
		}

		[Fact]
		public void CurrentDate_Over_End_Daily_Exception()
		{
			Input entrada = new Input()
			{
				CurrentDate = new DateTime(2020, 1, 4),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Daily,
				TimeSteps = 1,
				DaysAvailableWeek = new DayOfWeek[] { DayOfWeek.Sunday },
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2020, 1, 2),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 14, 00, 00),
			};
			Assert.Throws<ExceptionFechaFinalExceedEndDate>(() => Ejecutar.ProgramaScheduler(entrada));
		}

		[Fact]
		public void CurrentDate_Over_End_Weekly_Exception()
		{
			Input entrada = new Input()
			{
				CurrentDate = new DateTime(2020, 1, 4),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Weekly,
				TimeSteps = 1,
				DaysAvailableWeek = new DayOfWeek[] { DayOfWeek.Sunday },
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2020, 1, 2),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 14, 00, 00),
			};
			Assert.Throws<ExceptionFechaFinalExceedEndDate>(() => Ejecutar.ProgramaScheduler(entrada));
		}

		[Fact]
		public void CurrentDate_Over_End_Monthly_Exception()
		{
			Input entrada = new Input()
			{
				CurrentDate = new DateTime(2020, 1, 4),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 1,
				DaysAvailableWeek = new DayOfWeek[] { DayOfWeek.Sunday },
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2020, 1, 2),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 14, 00, 00),
			};
			Assert.Throws<ExceptionFechaFinalExceedEndDate>(() => Ejecutar.ProgramaScheduler(entrada));
		}

		[Fact]
		public void CurrentDate_Over_End_Yearly_Exception()
		{
			Input entrada = new Input()
			{
				CurrentDate = new DateTime(2020, 1, 4),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Yearly,
				TimeSteps = 1,
				DaysAvailableWeek = new DayOfWeek[] { DayOfWeek.Sunday },
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2020, 1, 2),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 14, 00, 00),
			};
			Assert.Throws<ExceptionFechaFinalExceedEndDate>(() => Ejecutar.ProgramaScheduler(entrada));
		}

		[Fact]
		public void Weekly_DaysAvailableWeek_Null_Exception()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1, 8, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Weekly,
				TimeSteps = 1,
				StartDate = new DateTime(2020, 1, 1, 8, 0, 0),
				TipoHorarioHoras = TiposHorarioHoras.SomeHoursADay,
				TipoHourSteps = HourMinSecSelected.Hour,
				ValueHourSteps = 1,
				DaysAvailableWeek = Array.Empty<DayOfWeek>(),
			};
			Assert.Throws<ExceptionDaysAvailableWeekValueNull>(() => Ejecutar.ProgramaScheduler(entrada));
		}
	}
}