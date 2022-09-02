using EjercicioScheduler;
using EjercicioScheduler.Enums;
using EjercicioScheduler.ProgramaScheduler;
using FluentAssertions;
using Xunit;

namespace Testing.TestsScheduler.Recurring
{
	public class MensualValueMonthly
	{
		[Fact]
		public void Checking_Monthly_Below_ValueDia_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1, 00, 00, 00),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2020, 12, 2, 00, 00, 00),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 00, 00, 00),
				TipoMonthly = TiposMonthly.ValueDia,
				ValueDiaMes = 13,

			};

			Output result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 1, 13, 00, 00, 00);
			string descripcionFinal = "Occurs the day 13 of every 2 months at 12:00 am starting on 01/01/2020";

			//result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
			result.FechaFinal.Should().Be(fechaFinal);
		}

		[Fact]
		public void Checking_Monthly_Equal_ValueDia_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 13, 00, 00, 00),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2020, 12, 2, 00, 00, 00),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 00, 00, 00),
				TipoMonthly = TiposMonthly.ValueDia,
				ValueDiaMes = 13,

			};

			Output result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 3, 13, 00, 00, 00);
			string descripcionFinal = "Occurs the day 13 of every 2 months at 12:00 am starting on 01/01/2020";

			//result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
			result.FechaFinal.Should().Be(fechaFinal);
		}

		[Fact]
		public void Checking_Monthly_Over_ValueDia_DiaMesSelected_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 14, 8, 0, 0), // Wednesday
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 8, 0, 0),
				TipoMonthly = TiposMonthly.ValueDia,
				ValueDiaMes = 13,
			};

			var result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 2, 13, 08, 0, 0);
			string descripcionFinal = $"Occurs the day 13 of every 2 months at 8:00 am starting on 01/01/2020";

			result.Description.Should().Be(descripcionFinal);
			result.FechaFinal.Should().Be(fechaFinal);
		}

		[Fact]
		public void Checking_Monthly_ChangeHour_Equal_ValueDia_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 13, 0, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 8, 0, 0),
				TipoMonthly = TiposMonthly.ValueDia,
				ValueDiaMes = 13,
			};

			var result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 1, 13, 08, 0, 0);
			string descripcionFinal = $"Occurs the day 13 of every 2 months at 8:00 am starting on 01/01/2020";

			result.Description.Should().Be(descripcionFinal);
			result.FechaFinal.Should().Be(fechaFinal);
		}

		[Fact]
		public void Checking_Monthly_ChangeHour_Equal_ValueDia_SomeHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 31, 12, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				TipoHorarioHoras = TiposHorarioHoras.SomeHoursADay,
				TipoHourSteps = HourMinSecSelected.Hour,
				ValueHourSteps = 2,
				StartHourDay = new DateTime(2020, 1, 1, 12, 0, 0),
				EndHourDay = new DateTime(2020, 1, 1, 14, 0, 0),
				TipoMonthly = TiposMonthly.ValueDia,
				ValueDiaMes = 31,
			};

			var result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 1, 31, 14, 0, 0);
			string descripcionFinal = $"Occurs the day 31 of every 2 months every 2 hours between 12:00 pm and 2:00 pm starting on 01/01/2020";

			result.Description.Should().Be(descripcionFinal);
			result.FechaFinal.Should().Be(fechaFinal);
		}

		[Fact]
		public void Checking_Monthly_Equal_31Day_To_29Day_ValueDia_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2019, 12, 31, 08, 00, 00),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 2,
				StartDate = new DateTime(2019, 1, 1),
				EndDate = new DateTime(2020, 12, 2, 00, 00, 00),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 08, 00, 00),
				TipoMonthly = TiposMonthly.ValueDia,
				ValueDiaMes = 31,
			};

			Output result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 2, 29, 08, 00, 00);
			string descripcionFinal = "Occurs the day 31 of every 2 months at 8:00 am starting on 01/01/2019";

			result.Description.Should().Be(descripcionFinal);
			result.FechaFinal.Should().Be(fechaFinal);
		}

		[Fact]
		public void Checking_Monthly_Near_End_Limit_3_ValueSteps_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1, 00, 00, 00),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2020, 5, 13, 14, 00, 00),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 14, 00, 00),
				TipoMonthly = TiposMonthly.ValueDia,
				ValueDiaMes = 13,
			};

			Output result = Ejecutar.ProgramaScheduler(entrada);
			result = Ejecutar.ProgramaScheduler(entrada);
			result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 5, 13, 14, 0, 0);
			string descripcionFinal = "Occurs the day 13 of every 2 months at 2:00 pm starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_MonthlyValue_Near_End_Limit_4Steps_February_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 2, 1, 00, 00, 00),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 14, 00, 00),
				TipoMonthly = TiposMonthly.ValueDia,
				ValueDiaMes = 31,
			};

			Output result = Ejecutar.ProgramaScheduler(entrada);
			DateTime fechaFinal = new DateTime(2020, 2, 29, 14, 0, 0);
			result.FechaFinal.Should().Be(fechaFinal);

			result = Ejecutar.ProgramaScheduler(entrada);
			fechaFinal = new DateTime(2020, 4, 30, 14, 0, 0);
			result.FechaFinal.Should().Be(fechaFinal);

			result = Ejecutar.ProgramaScheduler(entrada);
			fechaFinal = new DateTime(2020, 6, 30, 14, 0, 0);
			result.FechaFinal.Should().Be(fechaFinal);

			result = Ejecutar.ProgramaScheduler(entrada);

			fechaFinal = new DateTime(2020, 8, 31, 14, 0, 0);
			string descripcionFinal = "Occurs the day 31 of every 2 months at 2:00 pm starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_Monthly_ChangeHour_ChangeMonth_SomeHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 13, 14, 00, 00),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2020, 12, 31, 14, 00, 00),
				TipoHorarioHoras = TiposHorarioHoras.SomeHoursADay,
				TipoHourSteps = HourMinSecSelected.Hour,
				ValueHourSteps = 2,
				StartHourDay = new DateTime(2020, 1, 1, 12, 0, 0),
				EndHourDay = new DateTime(2020, 1, 1, 14, 0, 0),
				TipoMonthly = TiposMonthly.ValueDia,
				ValueDiaMes = 13,
			};

			Output result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 3, 13, 12, 0, 0);
			string descripcionFinal = "Occurs the day 13 of every 2 months every 2 hours between 12:00 pm and 2:00 pm starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_Monthly_Near_End_Limit_3_ValueSteps_SomeHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1, 14, 00, 00),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2020, 12, 31, 14, 00, 00),
				TipoHorarioHoras = TiposHorarioHoras.SomeHoursADay,
				TipoHourSteps = HourMinSecSelected.Hour,
				ValueHourSteps = 2,
				StartHourDay = new DateTime(2020, 1, 1, 12, 0, 0),
				EndHourDay = new DateTime(2020, 1, 1, 16, 0, 0),
				TipoMonthly = TiposMonthly.ValueDia,
				ValueDiaMes = 13,
			};

			Output result = Ejecutar.ProgramaScheduler(entrada);
			result = Ejecutar.ProgramaScheduler(entrada);
			result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 1, 13, 16, 0, 0);
			string descripcionFinal = "Occurs the day 13 of every 2 months every 2 hours between 12:00 pm and 4:00 pm starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}
	}
}