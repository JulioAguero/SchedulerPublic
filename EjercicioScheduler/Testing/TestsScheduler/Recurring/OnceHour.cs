using EjercicioScheduler;
using EjercicioScheduler.Enums;
using EjercicioScheduler.ProgramaScheduler;
using FluentAssertions;
using Xunit;

namespace Testing.TestsScheduler.Recurring
{
	public class OnceHour
	{
		[Fact]
		public void CurrentDate_Over_Limit_By_StepUp_Daily_OnceHour_Exception()
		{
			Input entrada = new Input()
			{
				CurrentDate = new DateTime(2020, 1, 1, 00, 00, 00),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Daily,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2020, 1, 2),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 2, 00, 00, 00),
			};
			Assert.Throws<ExceptionFechaFinalExceedEndDate>(() => Ejecutar.ProgramaScheduler(entrada));
		}

		[Fact]
		public void CurrentDate_Over_Limit_By_StepUp_Weekly_OnceHour_Exception()
		{
			Input entrada = new Input()
			{
				CurrentDate = new DateTime(2020, 1, 1, 12, 00, 00), // Wednesday
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Weekly,
				TimeSteps = 2,
				DaysAvailableWeek = new DayOfWeek[] { DayOfWeek.Wednesday },
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2020, 1, 14),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 12, 00, 00),
			};
			Assert.Throws<ExceptionFechaFinalExceedEndDate>(() => Ejecutar.ProgramaScheduler(entrada));
		}

		[Fact]
		public void CurrentDate_Over_Limit_By_StepUp_Monthly_OnceHour_Exception()
		{
			Input entrada = new Input()
			{
				CurrentDate = new DateTime(2020, 1, 1, 00, 00, 00),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2020, 2, 29),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 00, 00, 00),
				TipoMonthly = TiposMonthly.ValueDia,
				ValueDiaMes = 1,
			};
			Assert.Throws<ExceptionFechaFinalExceedEndDate>(() => Ejecutar.ProgramaScheduler(entrada));
		}

		[Fact]
		public void CurrentDate_Over_Limit_By_StepUp_Yearly_OnceHour_Exception()
		{
			Input entrada = new Input()
			{
				CurrentDate = new DateTime(2020, 12, 31, 00, 00, 00),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Yearly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2021, 1, 4),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 00, 00, 00),
			};
			Assert.Throws<ExceptionFechaFinalExceedEndDate>(() => Ejecutar.ProgramaScheduler(entrada));
		}

		[Fact]
		public void Hour_StepUp_Over_End_OnceHour_Exception()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 4, 13, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Daily,
				TimeSteps = 1,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2020, 1, 4, 14, 00, 00),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 15, 00, 00),
			};
			Assert.Throws<ExceptionFechaFinalExceedEndDate>(() => Ejecutar.ProgramaScheduler(entrada));
		}

		[Fact]
		public void FechaFinal_Overflow_DateTime_Max_Limit_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = DateTime.MaxValue, //Friday 00:00:00
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Daily,
				TimeSteps = 1,
				StartDate = DateTime.MinValue,
				EndDate = DateTime.MaxValue,
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 14, 00, 00)
			};
			Assert.Throws<ArgumentOutOfRangeException>(() => Ejecutar.ProgramaScheduler(entrada));
		}

		[Fact]
		public void Checking_Weekly_CurrentDate_In_DayAvailableWeek_Next_Hour_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1, 0, 0, 0), // Wednesday
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Weekly,
				TimeSteps = 1,
				DaysAvailableWeek = new DayOfWeek[] { DayOfWeek.Wednesday },
				StartDate = new DateTime(2020, 1, 1),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 8, 0, 0)
			};

			var result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 1, 1, 8, 0, 0);
			string descripcionFinal = $"Occurs every week on wednesday at 8:00 am starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_Weekly_Current_In_DayAvailableWeek_Next_Day_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1), // Wednesday
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Weekly,
				TimeSteps = 2,
				DaysAvailableWeek = new DayOfWeek[] { DayOfWeek.Wednesday, DayOfWeek.Thursday },
				StartDate = new DateTime(2020, 1, 1),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 00, 00, 00),
				BeginningWeek = DayStartWeekSelected.StandardMonday,
			};

			var result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 1, 2, 00, 00, 00);
			string descripcionFinal = $"Occurs every 2 weeks on wednesday and thursday at 12:00 am starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_Weekly_Current_Not_In_DaysAvailableWeek_Next_Day_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1, 08, 00, 00), // Wednesday
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Weekly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				DaysAvailableWeek = new DayOfWeek[] { DayOfWeek.Thursday },
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 8, 0, 0)
			};

			var result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 1, 2, 8, 0, 0);
			string descripcionFinal = $"Occurs every 2 weeks on thursday at 8:00 am starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_Weekly_Current_In_DayAvailableWeek_Next_Weeks_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1), // Wednesday
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Weekly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				DaysAvailableWeek = new DayOfWeek[] { DayOfWeek.Wednesday },
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 00, 00, 00)
			};

			var result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 1, 15, 00, 00, 00);
			string descripcionFinal = $"Occurs every 2 weeks on wednesday at 12:00 am starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}


		[Fact]
		public void Checking_Current_Over_OnceHour_Next_Day_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1, 10, 00, 00), // Wednesday
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Daily,
				TimeSteps = 8,
				StartDate = new DateTime(2020, 1, 1),
				DaysAvailableWeek = new DayOfWeek[] { DayOfWeek.Thursday },
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 08, 00, 00)
			};

			var result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 1, 9, 8, 0, 0);
			string descripcionFinal = $"Occurs every 8 days at 8:00 am starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_Current_Over_OnceHour_Next_Week_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1, 10, 00, 00), // Wednesday
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Weekly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				DaysAvailableWeek = new DayOfWeek[] { DayOfWeek.Wednesday },
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 08, 00, 00)
			};

			var result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 1, 15, 8, 0, 0);
			string descripcionFinal = $"Occurs every 2 weeks on wednesday at 8:00 am starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_Daily_Near_End_Limit_3_Steps_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 4, 14, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Daily,
				TimeSteps = 1,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2020, 1, 7, 14, 00, 00),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 14, 00, 00),
			};

			Output result = Ejecutar.ProgramaScheduler(entrada);
			result = Ejecutar.ProgramaScheduler(entrada);
			result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 1, 7, 14, 0, 0);
			string descripcionFinal = "Occurs every day at 2:00 pm starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_Weekly_Near_End_Limit_3_Steps_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 4, 14, 0, 0), // Saturday
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Weekly,
				TimeSteps = 2,
				DaysAvailableWeek = new DayOfWeek[] { DayOfWeek.Sunday, DayOfWeek.Monday, DayOfWeek.Tuesday },
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2020, 1, 14, 14, 00, 00),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 14, 00, 00),
			};

			Output result = Ejecutar.ProgramaScheduler(entrada);
			result = Ejecutar.ProgramaScheduler(entrada);
			result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 1, 14, 14, 0, 0);
			string descripcionFinal = "Occurs every 2 weeks on sunday, monday and tuesday at 2:00 pm starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}
		
		[Fact]
		public void Checking_Yearly_Near_End_Limit_3_Steps_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2019, 12, 31, 14, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Yearly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2021, 1, 3, 14, 00, 00),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 14, 00, 00),
			};

			Output result = Ejecutar.ProgramaScheduler(entrada);
			result = Ejecutar.ProgramaScheduler(entrada);
			result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2021, 1, 3, 14, 0, 0);
			string descripcionFinal = "Occurs every 2 years at 2:00 pm starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}
	}
}