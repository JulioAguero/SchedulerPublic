using EjercicioScheduler;
using EjercicioScheduler.Enums;
using EjercicioScheduler.ProgramaScheduler;
using FluentAssertions;
using Xunit;

namespace Testing.TestsScheduler.Recurring
{
	public class SomeHours
	{
		[Fact]
		public void HourSteps_Zero_Or_Negative_Exception()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Daily,
				TimeSteps = 1,
				StartDate = new DateTime(2020, 1, 1),
				DaysAvailableWeek = new DayOfWeek[] { DayOfWeek.Monday },
				TipoHorarioHoras = TiposHorarioHoras.SomeHoursADay,
				StartHourDay = new DateTime(2020, 1, 1, 8, 0, 0),
				EndHourDay = new DateTime(2020, 1, 1, 12, 0, 0),
				TipoHourSteps = HourMinSecSelected.Hour,
				ValueHourSteps = 0
			};
			Assert.Throws<ExceptionHourStepsZeroOrNegative>(() => Ejecutar.ProgramaScheduler(entrada));
		}

		[Fact]
		public void HourSteps_Greater_HourInterval_Some_Exception()
		{
			Input entrada = new Input()
			{
				CurrentDate = new DateTime(2020, 1, 1),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Daily,
				TimeSteps = 1,
				DaysAvailableWeek = new DayOfWeek[] { DayOfWeek.Saturday },
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2020, 1, 2),
				TipoHorarioHoras = TiposHorarioHoras.SomeHoursADay,
				TipoHourSteps = HourMinSecSelected.Hour,
				ValueHourSteps = 2,
				StartHourDay = new DateTime(2020, 1, 1, 00, 00, 00),
				EndHourDay = new DateTime(2020, 1, 1, 01, 00, 00)
			};
			Assert.Throws<ExceptionHourStepsGreaterHourRange>(() => Ejecutar.ProgramaScheduler(entrada));
		}

		[Fact]
		public void FechaFinal_Overflow_Date_Time_Max_Limit_Some_Exception()
		{
			Input entrada = new()
			{
				CurrentDate = DateTime.MaxValue, // Friday 00:00:00
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Daily,
				TimeSteps = 1,
				StartDate = DateTime.MinValue,
				EndDate = DateTime.MaxValue,
				TipoHorarioHoras = TiposHorarioHoras.SomeHoursADay,
				TipoHourSteps = HourMinSecSelected.Hour,
				ValueHourSteps = 1,
				StartHourDay = new DateTime(2020, 1, 1, 00, 00, 00),
				EndHourDay = new DateTime(2020, 1, 1, 02, 00, 00)
			};
			Assert.Throws<ArgumentOutOfRangeException>(() => Ejecutar.ProgramaScheduler(entrada));
		}

		[Fact]
		public void EndHour_Greater_StartHour_Some_Exception()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Daily,
				TimeSteps = 1,
				StartDate = new DateTime(2020, 1, 1),
				DaysAvailableWeek = new DayOfWeek[] { DayOfWeek.Monday },
				TipoHorarioHoras = TiposHorarioHoras.SomeHoursADay,
				TipoHourSteps = HourMinSecSelected.Hour,
				StartHourDay = new DateTime(2020, 1, 1, 12, 0, 0),
				EndHourDay = new DateTime(2020, 1, 6, 0, 0, 0)
			};
			Assert.Throws<ExceptionIncoherentLimitsHours>(() => Ejecutar.ProgramaScheduler(entrada));
		}

		[Fact]
		public void CurrentDate_Over_DateLimit_By_StepUp_Exception()
		{
			Input entrada = new Input()
			{
				CurrentDate = new DateTime(2020, 12, 31, 2, 0, 0), //Thursday
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Yearly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2020, 12, 31),
				TipoHorarioHoras = TiposHorarioHoras.SomeHoursADay,
				TipoHourSteps = HourMinSecSelected.Hour,
				ValueHourSteps = 2,
				StartHourDay = new DateTime(2020, 1, 1, 00, 00, 00),
				EndHourDay = new DateTime(2020, 1, 1, 02, 00, 00)

			};
			Assert.Throws<ExceptionFechaFinalExceedEndDate>(() => Ejecutar.ProgramaScheduler(entrada));
		}

		[Fact]
		public void CurrentDate_Over_DateLimit_By_DayChange_Exception()
		{
			Input entrada = new Input()
			{
				CurrentDate = new DateTime(2020, 1, 1, 2, 0, 0), //Thursday
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Daily,
				TimeSteps = 2,
				StartDate = new DateTime(2019, 12, 31),
				EndDate = new DateTime(2020, 1, 1),
				TipoHorarioHoras = TiposHorarioHoras.SomeHoursADay,
				TipoHourSteps = HourMinSecSelected.Hour,
				ValueHourSteps = 2,
				StartHourDay = new DateTime(2020, 1, 1, 00, 00, 00),
				EndHourDay = new DateTime(2020, 1, 1, 03, 00, 00) // 03:00, but last step in 02:00, so day-jump

			};
			Assert.Throws<ExceptionFechaFinalExceedEndDate>(() => Ejecutar.ProgramaScheduler(entrada));
		}

		[Fact]
		public void CurrentDate_Over_DateLimit_By_Hour_StepUp_Exception()
		{
			Input entrada = new Input()
			{
				CurrentDate = new DateTime(2020, 1, 1, 02, 00, 00),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Daily,
				TimeSteps = 1,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2020, 1, 1, 03, 00, 00),
				TipoHorarioHoras = TiposHorarioHoras.SomeHoursADay,
				TipoHourSteps = HourMinSecSelected.Hour,
				ValueHourSteps = 2,
				StartHourDay = new DateTime(2020, 1, 1, 00, 00, 00),
				EndHourDay = new DateTime(2020, 1, 1, 04, 00, 00)
			};
			Assert.Throws<ExceptionFechaFinalExceedEndDate>(() => Ejecutar.ProgramaScheduler(entrada));
		}

		[Fact]
		public void CurrentDate_LastHour_NotEndHour_StepUp_NextDay_Some()
		{
			Input entrada = new Input()
			{
				CurrentDate = new DateTime(2020, 1, 1, 2, 0, 0), //Thursday
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Daily,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2021, 1, 1),
				TipoHorarioHoras = TiposHorarioHoras.SomeHoursADay,
				TipoHourSteps = HourMinSecSelected.Hour,
				ValueHourSteps = 2,
				StartHourDay = new DateTime(2020, 1, 1, 00, 00, 00),
				EndHourDay = new DateTime(2020, 1, 1, 03, 00, 00) // 03:00, but last step in 02:00, so day-jump

			};

			var result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 1, 3, 00, 00, 00);
			string descripcionFinal = "Occurs every 2 days every " +
				"2 hours between 12:00 am and 3:00 am starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_ChangeDay_Leads_NextWeek_Weekly_Some()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1, 10, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Weekly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				DaysAvailableWeek = new DayOfWeek[] { DayOfWeek.Wednesday },
				TipoHorarioHoras = TiposHorarioHoras.SomeHoursADay,
				EndHourDay = new DateTime(2020, 1, 1, 10, 0, 0),
				TipoHourSteps = HourMinSecSelected.Hour,
				ValueHourSteps = 2,
			};

			var result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 1, 15, 00, 00, 00);
			string descripcionFinal = "Occurs every 2 weeks on wednesday every " +
				"2 hours between 12:00 am and 10:00 am starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_Start_Not_Equal_To_DaysAvailableWeek_Some()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 2), // Thursday
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Daily,
				TimeSteps = 1,
				StartDate = new DateTime(2020, 1, 1),
				TipoHorarioHoras = TiposHorarioHoras.SomeHoursADay,
				StartHourDay = new DateTime(2020, 1, 1, 8, 0, 0),
				EndHourDay = new DateTime(2020, 1, 1, 12, 0, 0),
				TipoHourSteps = HourMinSecSelected.Hour,
				ValueHourSteps = 2
			};

			var result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 1, 2, 8, 0, 0);
			string descripcionFinal = $"Occurs every day every 2 hours between 8:00 am and 12:00 pm" +
									$" starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_Near_EndLimit_2_Steps_Daily_Some()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1), // Saturday
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Daily,
				TimeSteps = 1,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2020, 1, 1, 04, 00, 00),
				TipoHorarioHoras = TiposHorarioHoras.SomeHoursADay,
				TipoHourSteps = HourMinSecSelected.Hour,
				ValueHourSteps = 2,
				StartHourDay = new DateTime(2020, 1, 1, 00, 00, 00),
				EndHourDay = new DateTime(2020, 1, 1, 04, 00, 00)
			};

			Output result = Ejecutar.ProgramaScheduler(entrada);
			result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 1, 1, 04, 00, 00);
			string descripcionFinal = "Occurs every day every 2 hours " +
											"between 12:00 am and 4:00 am starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_HourStep_Inside_NextDay_NotAffect_FinalHour_Some()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1, 23, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Daily,
				TimeSteps = 1,
				StartDate = new DateTime(2020, 1, 1),
				DaysAvailableWeek = new DayOfWeek[] { DayOfWeek.Wednesday, DayOfWeek.Thursday },
				TipoHorarioHoras = TiposHorarioHoras.SomeHoursADay,
				TipoHourSteps = HourMinSecSelected.Hour,
				ValueHourSteps = 4
			};

			Output result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 1, 2, 00, 00, 00);
			string descripcionFinal = "Occurs every day every " +
				"4 hours between 12:00 am and 11:59 pm starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_NextHour_Minutes_Some()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1, 13, 30, 00),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Daily,
				TimeSteps = 1,
				StartDate = new DateTime(2020, 1, 1),
				TipoHorarioHoras = TiposHorarioHoras.SomeHoursADay,
				EndHourDay = new DateTime(2020, 1, 1, 14, 00, 00),
				TipoHourSteps = HourMinSecSelected.Minute,
				ValueHourSteps = 30
			};

			Output result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 1, 1, 14, 00, 00);
			string descripcionFinal = "Occurs every day every " +
				"30 minutes between 12:00 am and 2:00 pm starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_Hour_Between_Steps_NextStep_Minutes_Some()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1, 13, 59, 00),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Daily,
				TimeSteps = 1,
				StartDate = new DateTime(2020, 1, 1),
				TipoHorarioHoras = TiposHorarioHoras.SomeHoursADay,
				EndHourDay = new DateTime(2020, 1, 1, 14, 00, 00),
				TipoHourSteps = HourMinSecSelected.Minute,
				ValueHourSteps = 30
			};

			Output result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 1, 1, 14, 00, 00);
			string descripcionFinal = "Occurs every day every " +
				"30 minutes between 12:00 am and 2:00 pm starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_NextHour_Seconds_Some()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1, 13, 59, 30),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Daily,
				TimeSteps = 1,
				StartDate = new DateTime(2020, 1, 1),
				TipoHorarioHoras = TiposHorarioHoras.SomeHoursADay,
				EndHourDay = new DateTime(2020, 1, 1, 14, 00, 00),
				TipoHourSteps = HourMinSecSelected.Second,
				ValueHourSteps = 30
			};

			Output result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 1, 1, 14, 00, 00);
			string descripcionFinal = "Occurs every day every " +
				"30 seconds between 12:00 am and 2:00 pm starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}
	}
}