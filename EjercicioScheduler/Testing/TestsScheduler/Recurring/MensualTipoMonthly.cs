using EjercicioScheduler;
using EjercicioScheduler.Enums;
using FluentAssertions;
using Xunit;

namespace Testing.TestsScheduler.Recurring
{
	public class MensualTipoMonthly // Faltan algunos correspondientes a Some
	{
		// Days of the Week, Once

		[Fact]
		public void Checking_MonthlyTipo_FirstMonday_Day1_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 5, 31, 0, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 8, 0, 0),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.First,
				DiaSemanaSelected = DiasSemanaSelected.Monday,
			};

			var result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 6, 1, 08, 00, 00);
			string descripcionFinal = $"Occurs the first monday of every 2 months at 8:00 am starting on 01/01/2020";

			result.Description.Should().Be(descripcionFinal);
			result.FechaFinal.Should().Be(fechaFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_FirstMonday_NotDay1_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1, 0, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 8, 0, 0),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.First,
				DiaSemanaSelected = DiasSemanaSelected.Monday,
			};

			var result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 1, 6, 08, 00, 00);
			string descripcionFinal = $"Occurs the first monday of every 2 months at 8:00 am starting on 01/01/2020";

			result.Description.Should().Be(descripcionFinal);
			result.FechaFinal.Should().Be(fechaFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_FirstMonday_FromGoodDay_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2019, 12, 2, 8, 0, 0), // Monday
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 8, 0, 0),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.First,
				DiaSemanaSelected = DiasSemanaSelected.Monday,
			};

			var result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 2, 3, 08, 00, 00);
			string descripcionFinal = $"Occurs the first monday of every 2 months at 8:00 am starting on 01/01/2020";

			result.Description.Should().Be(descripcionFinal);
			result.FechaFinal.Should().Be(fechaFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_FirstTuesday_NotDay1_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1, 0, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 8, 0, 0),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.First,
				DiaSemanaSelected = DiasSemanaSelected.Tuesday,
			};

			var result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 1, 7, 08, 00, 00);
			string descripcionFinal = $"Occurs the first tuesday of every 2 months at 8:00 am starting on 01/01/2020";

			result.Description.Should().Be(descripcionFinal);
			result.FechaFinal.Should().Be(fechaFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_FirstTuesday_Day1_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 8, 31, 13, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				TipoHorarioHoras = TiposHorarioHoras.SomeHoursADay,
				TipoHourSteps = HourMinSecSelected.Hour,
				ValueHourSteps = 2,
				StartHourDay = new DateTime(2020, 1, 1, 12, 0, 0),
				EndHourDay = new DateTime(2020, 1, 1, 14, 0, 0),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.First,
				DiaSemanaSelected = DiasSemanaSelected.Tuesday,
			};

			var result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 9, 1, 12, 00, 00);
			string descripcionFinal = $"Occurs the first tuesday of every 2 months every 2 hours between 12:00 pm and 2:00 pm starting on 01/01/2020";

			result.Description.Should().Be(descripcionFinal);
			result.FechaFinal.Should().Be(fechaFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_LastMonday_NotDay31_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1, 0, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 8, 0, 0),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.Last,
				DiaSemanaSelected = DiasSemanaSelected.Monday,
			};

			var result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 1, 27, 08, 00, 00);
			string descripcionFinal = $"Occurs the last monday of every 2 months at 8:00 am starting on 01/01/2020";

			result.Description.Should().Be(descripcionFinal);
			result.FechaFinal.Should().Be(fechaFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_LastMonday_Day31_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 7, 31, 0, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 1,
				StartDate = new DateTime(2020, 1, 1),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 8, 0, 0),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.Last,
				DiaSemanaSelected = DiasSemanaSelected.Monday,
			};

			var result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 8, 31, 08, 00, 00);
			string descripcionFinal = $"Occurs the last monday of every month at 8:00 am starting on 01/01/2020";

			result.Description.Should().Be(descripcionFinal);
			result.FechaFinal.Should().Be(fechaFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_FirstMonday_Day1_3Steps_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 2, 1, 0, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 8, 0, 0),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.First,
				DiaSemanaSelected = DiasSemanaSelected.Monday,
			};

			var result = Ejecutar.ProgramaScheduler(entrada);
			DateTime fechaFinal = new DateTime(2020, 2, 3, 08, 00, 00);
			result.FechaFinal.Should().Be(fechaFinal);

			result = Ejecutar.ProgramaScheduler(entrada);
			fechaFinal = new DateTime(2020, 4, 6, 08, 00, 00);
			result.FechaFinal.Should().Be(fechaFinal);

			result = Ejecutar.ProgramaScheduler(entrada);

			fechaFinal = new DateTime(2020, 6, 1, 08, 00, 00);
			string descripcionFinal = $"Occurs the first monday of every 2 months at 8:00 am starting on 01/01/2020";

			result.Description.Should().Be(descripcionFinal);
			result.FechaFinal.Should().Be(fechaFinal);
		}

		// Some __________________________________________

		[Fact]
		public void Checking_MonthlyTipo_FirstMonday_Day1_SomeHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2019, 12, 2, 14, 00, 00),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 1,
				StartDate = new DateTime(2020, 1, 1),
				TipoHorarioHoras = TiposHorarioHoras.SomeHoursADay,
				TipoHourSteps = HourMinSecSelected.Hour,
				ValueHourSteps = 2,
				StartHourDay = new DateTime(2020, 1, 1, 12, 0, 0),
				EndHourDay = new DateTime(2020, 1, 1, 14, 0, 0),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.First,
				DiaSemanaSelected = DiasSemanaSelected.Monday,
			};

			var result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 1, 6, 12, 00, 00);
			string descripcionFinal = $"Occurs the first monday of every month every 2 hours between 12:00 pm and 2:00 pm starting on 01/01/2020";

			result.Description.Should().Be(descripcionFinal);
			result.FechaFinal.Should().Be(fechaFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_FirstMonday_NotDay1_SomeHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 6, 14, 00, 00),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 1,
				StartDate = new DateTime(2020, 1, 1),
				TipoHorarioHoras = TiposHorarioHoras.SomeHoursADay,
				TipoHourSteps = HourMinSecSelected.Hour,
				ValueHourSteps = 2,
				StartHourDay = new DateTime(2020, 1, 1, 12, 0, 0),
				EndHourDay = new DateTime(2020, 1, 1, 14, 0, 0),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.First,
				DiaSemanaSelected = DiasSemanaSelected.Monday,
			};

			var result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 2, 3, 12, 00, 00);
			string descripcionFinal = $"Occurs the first monday of every month every 2 hours between 12:00 pm and 2:00 pm starting on 01/01/2020";

			result.Description.Should().Be(descripcionFinal);
			result.FechaFinal.Should().Be(fechaFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_FirstTuesday_NotDay1_SomeHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2019, 12, 3, 14, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 1,
				StartDate = new DateTime(2020, 1, 1),
				TipoHorarioHoras = TiposHorarioHoras.SomeHoursADay,
				TipoHourSteps = HourMinSecSelected.Hour,
				ValueHourSteps = 2,
				StartHourDay = new DateTime(2020, 1, 1, 12, 0, 0),
				EndHourDay = new DateTime(2020, 1, 1, 14, 0, 0),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.First,
				DiaSemanaSelected = DiasSemanaSelected.Tuesday,
			};

			var result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 1, 7, 12, 00, 00);
			string descripcionFinal = $"Occurs the first tuesday of every month every 2 hours between 12:00 pm and 2:00 pm starting on 01/01/2020";

			result.Description.Should().Be(descripcionFinal);
			result.FechaFinal.Should().Be(fechaFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_FirstTuesday_Day1_SomeHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 8, 20, 14, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				TipoHorarioHoras = TiposHorarioHoras.SomeHoursADay,
				TipoHourSteps = HourMinSecSelected.Hour,
				ValueHourSteps = 2,
				StartHourDay = new DateTime(2020, 1, 1, 12, 0, 0),
				EndHourDay = new DateTime(2020, 1, 1, 14, 0, 0),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.First,
				DiaSemanaSelected = DiasSemanaSelected.Tuesday,
			};

			var result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 9, 1, 12, 00, 00);
			string descripcionFinal = $"Occurs the first tuesday of every 2 months every 2 hours between 12:00 pm and 2:00 pm starting on 01/01/2020";

			result.Description.Should().Be(descripcionFinal);
			result.FechaFinal.Should().Be(fechaFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_FirstTuesday_HourSteps_SomeHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 9, 1, 12, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				TipoHorarioHoras = TiposHorarioHoras.SomeHoursADay,
				TipoHourSteps = HourMinSecSelected.Hour,
				ValueHourSteps = 2,
				StartHourDay = new DateTime(2020, 1, 1, 12, 0, 0),
				EndHourDay = new DateTime(2020, 1, 1, 14, 0, 0),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.First,
				DiaSemanaSelected = DiasSemanaSelected.Tuesday,
			};

			var result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 9, 1, 14, 00, 00);
			string descripcionFinal = $"Occurs the first tuesday of every 2 months every 2 hours between 12:00 pm and 2:00 pm starting on 01/01/2020";

			result.Description.Should().Be(descripcionFinal);
			result.FechaFinal.Should().Be(fechaFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_FourthTuesday_SomeHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1, 13, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				TipoHorarioHoras = TiposHorarioHoras.SomeHoursADay,
				TipoHourSteps = HourMinSecSelected.Hour,
				ValueHourSteps = 2,
				StartHourDay = new DateTime(2020, 1, 1, 12, 0, 0),
				EndHourDay = new DateTime(2020, 1, 1, 14, 0, 0),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.Fourth,
				DiaSemanaSelected = DiasSemanaSelected.Wednesday,
			};

			var result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 1, 22, 12, 00, 00);
			string descripcionFinal = $"Occurs the fourth wednesday of every 2 months every 2 hours between 12:00 pm and 2:00 pm starting on 01/01/2020";

			result.Description.Should().Be(descripcionFinal);
			result.FechaFinal.Should().Be(fechaFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_LastMonday_NotDay31_SomeHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1, 0, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				TipoHorarioHoras = TiposHorarioHoras.SomeHoursADay,
				TipoHourSteps = HourMinSecSelected.Hour,
				ValueHourSteps = 2,
				StartHourDay = new DateTime(2020, 1, 1, 12, 0, 0),
				EndHourDay = new DateTime(2020, 1, 1, 14, 0, 0),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.Last,
				DiaSemanaSelected = DiasSemanaSelected.Monday,
			};

			var result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 1, 27, 12, 00, 00);
			string descripcionFinal = $"Occurs the last monday of every 2 months every 2 hours between 12:00 pm and 2:00 pm starting on 01/01/2020";

			result.Description.Should().Be(descripcionFinal);
			result.FechaFinal.Should().Be(fechaFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_LastMonday_Day31_SomeHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 7, 31, 0, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 1,
				StartDate = new DateTime(2020, 1, 1),
				TipoHorarioHoras = TiposHorarioHoras.SomeHoursADay,
				TipoHourSteps = HourMinSecSelected.Hour,
				ValueHourSteps = 2,
				StartHourDay = new DateTime(2020, 1, 1, 12, 0, 0),
				EndHourDay = new DateTime(2020, 1, 1, 14, 0, 0),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.Last,
				DiaSemanaSelected = DiasSemanaSelected.Monday,
			};

			var result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 8, 31, 12, 00, 00);
			string descripcionFinal = $"Occurs the last monday of every month every 2 hours between 12:00 pm and 2:00 pm starting on 01/01/2020";

			result.Description.Should().Be(descripcionFinal);
			result.FechaFinal.Should().Be(fechaFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_FirstMonday_Day1_3Steps_SomeHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 4, 1, 0, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				TipoHorarioHoras = TiposHorarioHoras.SomeHoursADay,
				TipoHourSteps = HourMinSecSelected.Hour,
				ValueHourSteps = 2,
				StartHourDay = new DateTime(2020, 1, 1, 12, 0, 0),
				EndHourDay = new DateTime(2020, 1, 1, 14, 0, 0),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.First,
				DiaSemanaSelected = DiasSemanaSelected.Monday,
			};

			var result = Ejecutar.ProgramaScheduler(entrada);
			DateTime fechaFinal = new DateTime(2020, 4, 6, 12, 00, 00);
			result.FechaFinal.Should().Be(fechaFinal);

			result = Ejecutar.ProgramaScheduler(entrada);
			fechaFinal = new DateTime(2020, 4, 6, 14, 00, 00);
			result.FechaFinal.Should().Be(fechaFinal);

			result = Ejecutar.ProgramaScheduler(entrada);

			fechaFinal = new DateTime(2020, 6, 1, 12, 00, 00);
			string descripcionFinal = $"Occurs the first monday of every 2 months every 2 hours between 12:00 pm and 2:00 pm starting on 01/01/2020";

			result.Description.Should().Be(descripcionFinal);
			result.FechaFinal.Should().Be(fechaFinal);
		}

		// day, Once

		[Fact]
		public void Checking_MonthlyTipo_Firstday_3Steps_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1, 0, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 8, 0, 0),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.First,
				DiaSemanaSelected = DiasSemanaSelected.day,
			};

			var result = Ejecutar.ProgramaScheduler(entrada);
			DateTime fechaFinal = new DateTime(2020, 1, 1, 08, 00, 00);
			result.FechaFinal.Should().Be(fechaFinal);

			result = Ejecutar.ProgramaScheduler(entrada);
			fechaFinal = new DateTime(2020, 3, 1, 08, 00, 00);
			result.FechaFinal.Should().Be(fechaFinal);

			result = Ejecutar.ProgramaScheduler(entrada);

			fechaFinal = new DateTime(2020, 5, 1, 08, 00, 00);
			string descripcionFinal = $"Occurs the first day of every 2 months at 8:00 am starting on 01/01/2020";

			result.Description.Should().Be(descripcionFinal);
			result.FechaFinal.Should().Be(fechaFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_SecondDay_3Steps_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1, 0, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 8, 0, 0),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.Second,
				DiaSemanaSelected = DiasSemanaSelected.day,
			};

			var result = Ejecutar.ProgramaScheduler(entrada);
			DateTime fechaFinal = new DateTime(2020, 1, 2, 08, 00, 00);
			result.FechaFinal.Should().Be(fechaFinal);

			result = Ejecutar.ProgramaScheduler(entrada);
			fechaFinal = new DateTime(2020, 3, 2, 08, 00, 00);
			result.FechaFinal.Should().Be(fechaFinal);

			result = Ejecutar.ProgramaScheduler(entrada);

			fechaFinal = new DateTime(2020, 5, 2, 08, 00, 00);
			string descripcionFinal = $"Occurs the second day of every 2 months at 8:00 am starting on 01/01/2020";

			result.Description.Should().Be(descripcionFinal);
			result.FechaFinal.Should().Be(fechaFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_ThirdDay_3Steps_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1, 0, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 8, 0, 0),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.Third,
				DiaSemanaSelected = DiasSemanaSelected.day,
			};

			var result = Ejecutar.ProgramaScheduler(entrada);
			DateTime fechaFinal = new DateTime(2020, 1, 3, 08, 00, 00);
			result.FechaFinal.Should().Be(fechaFinal);

			result = Ejecutar.ProgramaScheduler(entrada);
			fechaFinal = new DateTime(2020, 3, 3, 08, 00, 00);
			result.FechaFinal.Should().Be(fechaFinal);

			result = Ejecutar.ProgramaScheduler(entrada);

			fechaFinal = new DateTime(2020, 5, 3, 08, 00, 00);
			string descripcionFinal = $"Occurs the third day of every 2 months at 8:00 am starting on 01/01/2020";

			result.Description.Should().Be(descripcionFinal);
			result.FechaFinal.Should().Be(fechaFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_FourthDay_3Steps_OnceHur()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1, 0, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 8, 0, 0),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.Fourth,
				DiaSemanaSelected = DiasSemanaSelected.day,
			};

			var result = Ejecutar.ProgramaScheduler(entrada);
			DateTime fechaFinal = new DateTime(2020, 1, 4, 08, 00, 00);
			result.FechaFinal.Should().Be(fechaFinal);

			result = Ejecutar.ProgramaScheduler(entrada);
			fechaFinal = new DateTime(2020, 3, 4, 08, 00, 00);
			result.FechaFinal.Should().Be(fechaFinal);

			result = Ejecutar.ProgramaScheduler(entrada);

			fechaFinal = new DateTime(2020, 5, 4, 08, 00, 00);
			string descripcionFinal = $"Occurs the fourth day of every 2 months at 8:00 am starting on 01/01/2020";

			result.Description.Should().Be(descripcionFinal);
			result.FechaFinal.Should().Be(fechaFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_LastDay_3Steps_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1, 0, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 1,
				StartDate = new DateTime(2020, 1, 1),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 8, 0, 0),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.Last,
				DiaSemanaSelected = DiasSemanaSelected.day,
			};

			var result = Ejecutar.ProgramaScheduler(entrada);
			DateTime fechaFinal = new DateTime(2020, 1, 31, 08, 00, 00);
			result.FechaFinal.Should().Be(fechaFinal);

			result = Ejecutar.ProgramaScheduler(entrada);
			fechaFinal = new DateTime(2020, 2, 29, 08, 00, 00);
			result.FechaFinal.Should().Be(fechaFinal);

			result = Ejecutar.ProgramaScheduler(entrada);

			fechaFinal = new DateTime(2020, 3, 31, 08, 00, 00);
			string descripcionFinal = $"Occurs the last day of every month at 8:00 am starting on 01/01/2020";

			result.Description.Should().Be(descripcionFinal);
			result.FechaFinal.Should().Be(fechaFinal);
		}

		// Some_________________________________________________________

		[Fact]
		public void Checking_MonthlyTipo_Firstday_3Steps_SomeHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1, 0, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				TipoHorarioHoras = TiposHorarioHoras.SomeHoursADay,
				TipoHourSteps = HourMinSecSelected.Hour,
				ValueHourSteps = 2,
				StartHourDay = new DateTime(2020, 1, 1, 12, 0, 0),
				EndHourDay = new DateTime(2020, 1, 1, 14, 0, 0),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.First,
				DiaSemanaSelected = DiasSemanaSelected.day,
			};

			var result = Ejecutar.ProgramaScheduler(entrada);
			DateTime fechaFinal = new DateTime(2020, 1, 1, 12, 00, 00);
			result.FechaFinal.Should().Be(fechaFinal);

			result = Ejecutar.ProgramaScheduler(entrada);
			fechaFinal = new DateTime(2020, 1, 1, 14, 00, 00);
			result.FechaFinal.Should().Be(fechaFinal);

			result = Ejecutar.ProgramaScheduler(entrada);

			fechaFinal = new DateTime(2020, 3, 1, 12, 00, 00);
			string descripcionFinal = $"Occurs the first day of every 2 months every 2 hours between 12:00 pm and 2:00 pm starting on 01/01/2020";

			result.Description.Should().Be(descripcionFinal);
			result.FechaFinal.Should().Be(fechaFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_SecondDay_3Steps_SomeHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1, 0, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				TipoHorarioHoras = TiposHorarioHoras.SomeHoursADay,
				TipoHourSteps = HourMinSecSelected.Hour,
				ValueHourSteps = 2,
				StartHourDay = new DateTime(2020, 1, 1, 12, 0, 0),
				EndHourDay = new DateTime(2020, 1, 1, 14, 0, 0),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.Second,
				DiaSemanaSelected = DiasSemanaSelected.day,
			};

			var result = Ejecutar.ProgramaScheduler(entrada);
			DateTime fechaFinal = new DateTime(2020, 1, 2, 12, 00, 00);
			result.FechaFinal.Should().Be(fechaFinal);

			result = Ejecutar.ProgramaScheduler(entrada);
			fechaFinal = new DateTime(2020, 1, 2, 14, 00, 00);
			result.FechaFinal.Should().Be(fechaFinal);

			result = Ejecutar.ProgramaScheduler(entrada);

			fechaFinal = new DateTime(2020, 3, 2, 12, 00, 00);
			string descripcionFinal = $"Occurs the second day of every 2 months every 2 hours between 12:00 pm and 2:00 pm starting on 01/01/2020";

			result.Description.Should().Be(descripcionFinal);
			result.FechaFinal.Should().Be(fechaFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_ThirdDay_3Steps_SomeHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1, 0, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				TipoHorarioHoras = TiposHorarioHoras.SomeHoursADay,
				TipoHourSteps = HourMinSecSelected.Hour,
				ValueHourSteps = 2,
				StartHourDay = new DateTime(2020, 1, 1, 12, 0, 0),
				EndHourDay = new DateTime(2020, 1, 1, 14, 0, 0),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.Third,
				DiaSemanaSelected = DiasSemanaSelected.day,
			};

			var result = Ejecutar.ProgramaScheduler(entrada);
			DateTime fechaFinal = new DateTime(2020, 1, 3, 12, 00, 00);
			result.FechaFinal.Should().Be(fechaFinal);

			result = Ejecutar.ProgramaScheduler(entrada);
			fechaFinal = new DateTime(2020, 1, 3, 14, 00, 00);
			result.FechaFinal.Should().Be(fechaFinal);

			result = Ejecutar.ProgramaScheduler(entrada);

			fechaFinal = new DateTime(2020, 3, 3, 12, 00, 00);
			string descripcionFinal = $"Occurs the third day of every 2 months every 2 hours between 12:00 pm and 2:00 pm starting on 01/01/2020";

			result.Description.Should().Be(descripcionFinal);
			result.FechaFinal.Should().Be(fechaFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_FourthDay_3Steps_SomeHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1, 0, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				TipoHorarioHoras = TiposHorarioHoras.SomeHoursADay,
				TipoHourSteps = HourMinSecSelected.Hour,
				ValueHourSteps = 2,
				StartHourDay = new DateTime(2020, 1, 1, 12, 0, 0),
				EndHourDay = new DateTime(2020, 1, 1, 14, 0, 0),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.Fourth,
				DiaSemanaSelected = DiasSemanaSelected.day,
			};

			var result = Ejecutar.ProgramaScheduler(entrada);
			DateTime fechaFinal = new DateTime(2020, 1, 4, 12, 00, 00);
			result.FechaFinal.Should().Be(fechaFinal);

			result = Ejecutar.ProgramaScheduler(entrada);
			fechaFinal = new DateTime(2020, 1, 4, 14, 00, 00);
			result.FechaFinal.Should().Be(fechaFinal);

			result = Ejecutar.ProgramaScheduler(entrada);

			fechaFinal = new DateTime(2020, 3, 4, 12, 00, 00);
			string descripcionFinal = $"Occurs the fourth day of every 2 months every 2 hours between 12:00 pm and 2:00 pm starting on 01/01/2020";

			result.Description.Should().Be(descripcionFinal);
			result.FechaFinal.Should().Be(fechaFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_LastDay_3Steps_SomeHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1, 0, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 1,
				StartDate = new DateTime(2020, 1, 1),
				TipoHorarioHoras = TiposHorarioHoras.SomeHoursADay,
				TipoHourSteps = HourMinSecSelected.Hour,
				ValueHourSteps = 2,
				StartHourDay = new DateTime(2020, 1, 1, 12, 0, 0),
				EndHourDay = new DateTime(2020, 1, 1, 14, 0, 0),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.Last,
				DiaSemanaSelected = DiasSemanaSelected.day,
			};

			var result = Ejecutar.ProgramaScheduler(entrada);
			DateTime fechaFinal = new DateTime(2020, 1, 31, 12, 00, 00);
			result.FechaFinal.Should().Be(fechaFinal);

			result = Ejecutar.ProgramaScheduler(entrada);
			fechaFinal = new DateTime(2020, 1, 31, 14, 00, 00);
			result.FechaFinal.Should().Be(fechaFinal);

			result = Ejecutar.ProgramaScheduler(entrada);

			fechaFinal = new DateTime(2020, 2, 29, 12, 00, 00);
			string descripcionFinal = $"Occurs the last day of every month every 2 hours between 12:00 pm and 2:00 pm starting on 01/01/2020";

			result.Description.Should().Be(descripcionFinal);
			result.FechaFinal.Should().Be(fechaFinal);
		}

		// weekend, Once

		[Fact]
		public void Checking_MonthlyTipo_FirstWeekend_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1, 14, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 3,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2023, 12, 14, 14, 00, 00),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 14, 00, 00),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.First,
				DiaSemanaSelected = DiasSemanaSelected.weekend_day,
			};

			Output result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 1, 4, 14, 0, 0);
			string descripcionFinal = "Occurs the first weekend day of every 3 months at 2:00 pm starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_FirstWeekend_FromDay1_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 2, 1, 14, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 3,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2023, 12, 14, 14, 00, 00),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 14, 00, 00),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.First,
				DiaSemanaSelected = DiasSemanaSelected.weekend_day,
			};

			Output result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 5, 2, 14, 0, 0);
			string descripcionFinal = "Occurs the first weekend day of every 3 months at 2:00 pm starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_FirstWeekend_ToDay1_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 4, 14, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 1,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2023, 12, 14, 14, 00, 00),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 14, 00, 00),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.First,
				DiaSemanaSelected = DiasSemanaSelected.weekend_day,
			};

			Output result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 2, 1, 14, 0, 0);
			string descripcionFinal = "Occurs the first weekend day of every month at 2:00 pm starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_SecondWeekend_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1, 14, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 3,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2023, 12, 14, 14, 00, 00),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 14, 00, 00),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.Second,
				DiaSemanaSelected = DiasSemanaSelected.weekend_day,
			};

			Output result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 1, 5, 14, 0, 0);
			string descripcionFinal = "Occurs the second weekend day of every 3 months at 2:00 pm starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_SecondWeekend_FromAvailable_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 5, 14, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 3,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2023, 12, 14, 14, 00, 00),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 14, 00, 00),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.Second,
				DiaSemanaSelected = DiasSemanaSelected.weekend_day,
			};

			Output result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 4, 5, 14, 0, 0);
			string descripcionFinal = "Occurs the second weekend day of every 3 months at 2:00 pm starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_ThirdWeekend_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1, 14, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 3,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2023, 12, 14, 14, 00, 00),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 14, 00, 00),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.Third,
				DiaSemanaSelected = DiasSemanaSelected.weekend_day,
			};

			Output result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 1, 11, 14, 0, 0);
			string descripcionFinal = "Occurs the third weekend day of every 3 months at 2:00 pm starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_ThirdWeekend_FromAvailable_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 11, 14, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 3,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2023, 12, 14, 14, 00, 00),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 14, 00, 00),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.Third,
				DiaSemanaSelected = DiasSemanaSelected.weekend_day,
			};

			Output result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 4, 11, 14, 0, 0);
			string descripcionFinal = "Occurs the third weekend day of every 3 months at 2:00 pm starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_FourthWeekend_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1, 14, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 3,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2023, 12, 14, 14, 00, 00),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 14, 00, 00),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.Fourth,
				DiaSemanaSelected = DiasSemanaSelected.weekend_day,
			};

			Output result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 1, 12, 14, 0, 0);
			string descripcionFinal = "Occurs the fourth weekend day of every 3 months at 2:00 pm starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_FourthWeekend_FromAvailable_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 12, 14, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 3,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2023, 12, 14, 14, 00, 00),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 14, 00, 00),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.Fourth,
				DiaSemanaSelected = DiasSemanaSelected.weekend_day,
			};

			Output result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 4, 12, 14, 0, 0);
			string descripcionFinal = "Occurs the fourth weekend day of every 3 months at 2:00 pm starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_LastWeekend_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1, 14, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 3,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2023, 12, 14, 14, 00, 00),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 14, 00, 00),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.Last,
				DiaSemanaSelected = DiasSemanaSelected.weekend_day,
			};

			Output result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 1, 26, 14, 0, 0);
			string descripcionFinal = "Occurs the last weekend day of every 3 months at 2:00 pm starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_LastWeekend_FromAvailable_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 26, 14, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 3,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2023, 12, 14, 14, 00, 00),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 14, 00, 00),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.Last,
				DiaSemanaSelected = DiasSemanaSelected.weekend_day,
			};

			Output result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 4, 26, 14, 0, 0);
			string descripcionFinal = "Occurs the last weekend day of every 3 months at 2:00 pm starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		// weekend, Some

		[Fact]
		public void Checking_MonthlyTipo_FirstWeekend_3Steps_SomeHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1, 14, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2023, 12, 14, 14, 00, 00),
				TipoHorarioHoras = TiposHorarioHoras.SomeHoursADay,
				TipoHourSteps = HourMinSecSelected.Hour,
				ValueHourSteps = 2,
				StartHourDay = new DateTime(2020, 1, 1, 12, 0, 0),
				EndHourDay = new DateTime(2020, 1, 1, 14, 0, 0),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.First,
				DiaSemanaSelected = DiasSemanaSelected.weekend_day,
			};

			var result = Ejecutar.ProgramaScheduler(entrada);
			DateTime fechaFinal = new DateTime(2020, 1, 4, 12, 00, 00);
			result.FechaFinal.Should().Be(fechaFinal);

			result = Ejecutar.ProgramaScheduler(entrada);
			fechaFinal = new DateTime(2020, 1, 4, 14, 00, 00);
			result.FechaFinal.Should().Be(fechaFinal);

			result = Ejecutar.ProgramaScheduler(entrada);

			fechaFinal = new DateTime(2020, 3, 1, 12, 00, 00);
			string descripcionFinal = $"Occurs the first weekend day of every 2 months every 2 hours between 12:00 pm and 2:00 pm starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_SecondWeekend_3Steps_SomeHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1, 14, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2023, 12, 14, 14, 00, 00),
				TipoHorarioHoras = TiposHorarioHoras.SomeHoursADay,
				TipoHourSteps = HourMinSecSelected.Hour,
				ValueHourSteps = 2,
				StartHourDay = new DateTime(2020, 1, 1, 12, 0, 0),
				EndHourDay = new DateTime(2020, 1, 1, 14, 0, 0),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.Second,
				DiaSemanaSelected = DiasSemanaSelected.weekend_day,
			};

			var result = Ejecutar.ProgramaScheduler(entrada);
			DateTime fechaFinal = new DateTime(2020, 1, 5, 12, 00, 00);
			result.FechaFinal.Should().Be(fechaFinal);

			result = Ejecutar.ProgramaScheduler(entrada);
			fechaFinal = new DateTime(2020, 1, 5, 14, 00, 00);
			result.FechaFinal.Should().Be(fechaFinal);

			result = Ejecutar.ProgramaScheduler(entrada);

			fechaFinal = new DateTime(2020, 3, 7, 12, 00, 00);
			string descripcionFinal = $"Occurs the second weekend day of every 2 months every 2 hours between 12:00 pm and 2:00 pm starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_ThirdWeekend_3Steps_SomeHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1, 14, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2023, 12, 14, 14, 00, 00),
				TipoHorarioHoras = TiposHorarioHoras.SomeHoursADay,
				TipoHourSteps = HourMinSecSelected.Hour,
				ValueHourSteps = 2,
				StartHourDay = new DateTime(2020, 1, 1, 12, 0, 0),
				EndHourDay = new DateTime(2020, 1, 1, 14, 0, 0),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.Third,
				DiaSemanaSelected = DiasSemanaSelected.weekend_day,
			};

			var result = Ejecutar.ProgramaScheduler(entrada);
			DateTime fechaFinal = new DateTime(2020, 1, 11, 12, 00, 00);
			result.FechaFinal.Should().Be(fechaFinal);

			result = Ejecutar.ProgramaScheduler(entrada);
			fechaFinal = new DateTime(2020, 1, 11, 14, 00, 00);
			result.FechaFinal.Should().Be(fechaFinal);

			result = Ejecutar.ProgramaScheduler(entrada);

			fechaFinal = new DateTime(2020, 3, 8, 12, 00, 00);
			string descripcionFinal = $"Occurs the third weekend day of every 2 months every 2 hours between 12:00 pm and 2:00 pm starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_FourthWeekend_3Steps_SomeHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1, 14, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2023, 12, 14, 14, 00, 00),
				TipoHorarioHoras = TiposHorarioHoras.SomeHoursADay,
				TipoHourSteps = HourMinSecSelected.Hour,
				ValueHourSteps = 2,
				StartHourDay = new DateTime(2020, 1, 1, 12, 0, 0),
				EndHourDay = new DateTime(2020, 1, 1, 14, 0, 0),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.Fourth,
				DiaSemanaSelected = DiasSemanaSelected.weekend_day,
			};

			var result = Ejecutar.ProgramaScheduler(entrada);
			DateTime fechaFinal = new DateTime(2020, 1, 12, 12, 00, 00);
			result.FechaFinal.Should().Be(fechaFinal);

			result = Ejecutar.ProgramaScheduler(entrada);
			fechaFinal = new DateTime(2020, 1, 12, 14, 00, 00);
			result.FechaFinal.Should().Be(fechaFinal);

			result = Ejecutar.ProgramaScheduler(entrada);

			fechaFinal = new DateTime(2020, 3, 14, 12, 00, 00);
			string descripcionFinal = $"Occurs the fourth weekend day of every 2 months every 2 hours between 12:00 pm and 2:00 pm starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_LastWeekend_3Steps_SomeHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 1, 14, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2023, 12, 14, 14, 00, 00),
				TipoHorarioHoras = TiposHorarioHoras.SomeHoursADay,
				TipoHourSteps = HourMinSecSelected.Hour,
				ValueHourSteps = 2,
				StartHourDay = new DateTime(2020, 1, 1, 12, 0, 0),
				EndHourDay = new DateTime(2020, 1, 1, 14, 0, 0),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.Last,
				DiaSemanaSelected = DiasSemanaSelected.weekend_day,
			};

			var result = Ejecutar.ProgramaScheduler(entrada);
			DateTime fechaFinal = new DateTime(2020, 1, 26, 12, 00, 00);
			result.FechaFinal.Should().Be(fechaFinal);

			result = Ejecutar.ProgramaScheduler(entrada);
			fechaFinal = new DateTime(2020, 1, 26, 14, 00, 00);
			result.FechaFinal.Should().Be(fechaFinal);

			result = Ejecutar.ProgramaScheduler(entrada);

			fechaFinal = new DateTime(2020, 3, 29, 12, 00, 00);
			string descripcionFinal = $"Occurs the last weekend day of every 2 months every 2 hours between 12:00 pm and 2:00 pm starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		// weekday, Once

		[Fact]
		public void Checking_MonthlyTipo_FirstWeekDay_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2019, 12, 31, 14, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 3,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2023, 12, 14, 14, 00, 00),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 14, 00, 00),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.First,
				DiaSemanaSelected = DiasSemanaSelected.weekday,
			};

			Output result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 1, 1, 14, 0, 0);
			string descripcionFinal = "Occurs the first weekday of every 3 months at 2:00 pm starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_FirstWeekDay_FromAvailable_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2019, 12, 2, 14, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2023, 12, 14, 14, 00, 00),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 14, 00, 00),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.First,
				DiaSemanaSelected = DiasSemanaSelected.weekday,
			};

			Output result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 2, 3, 14, 0, 0);
			string descripcionFinal = "Occurs the first weekday of every 2 months at 2:00 pm starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_FirstWeekDay_Day1Weekend_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 31, 14, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 3,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2023, 12, 14, 14, 00, 00),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 14, 00, 00),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.First,
				DiaSemanaSelected = DiasSemanaSelected.weekday,
			};

			Output result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 2, 3, 14, 0, 0);
			string descripcionFinal = "Occurs the first weekday of every 3 months at 2:00 pm starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_SecondWeekDay_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2019, 12, 31, 14, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 3,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2023, 12, 14, 14, 00, 00),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 14, 00, 00),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.Second,
				DiaSemanaSelected = DiasSemanaSelected.weekday,
			};

			Output result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 1, 2, 14, 0, 0);
			string descripcionFinal = "Occurs the second weekday of every 3 months at 2:00 pm starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_ThirdWeekDay_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2019, 12, 31, 14, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 3,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2023, 12, 14, 14, 00, 00),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 14, 00, 00),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.Third,
				DiaSemanaSelected = DiasSemanaSelected.weekday,
			};

			Output result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 1, 3, 14, 0, 0);
			string descripcionFinal = "Occurs the third weekday of every 3 months at 2:00 pm starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_FourthWeekDay_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2019, 12, 31, 14, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 3,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2023, 12, 14, 14, 00, 00),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 14, 00, 00),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.Fourth,
				DiaSemanaSelected = DiasSemanaSelected.weekday,
			};

			Output result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 1, 6, 14, 0, 0);
			string descripcionFinal = "Occurs the fourth weekday of every 3 months at 2:00 pm starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_LastWeekDay_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2019, 12, 31, 14, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 1,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2023, 12, 14, 14, 00, 00),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 14, 00, 00),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.Last,
				DiaSemanaSelected = DiasSemanaSelected.weekday,
			};

			Output result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 1, 31, 14, 0, 0);
			string descripcionFinal = "Occurs the last weekday of every month at 2:00 pm starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_LastWeekDay_FromAvailable_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2019, 12, 31, 14, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 2,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2023, 12, 14, 14, 00, 00),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 14, 00, 00),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.Last,
				DiaSemanaSelected = DiasSemanaSelected.weekday,
			};

			Output result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 2, 28, 14, 0, 0);
			string descripcionFinal = "Occurs the last weekday of every 2 months at 2:00 pm starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_MonthlyTipo_LastWeekDay_LastDayNotAvailable_OnceHour()
		{
			Input entrada = new()
			{
				CurrentDate = new DateTime(2020, 1, 31, 14, 0, 0),
				TipoHorario = TiposHorarioFecha.Recurring,
				TipoTimeSteps = TipoTimeSteps.Monthly,
				TimeSteps = 1,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2023, 12, 14, 14, 00, 00),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2020, 1, 1, 14, 00, 00),
				TipoMonthly = TiposMonthly.TipoDiaDelMes,
				PosicionEnSemana = PosicionesEnSemana.Last,
				DiaSemanaSelected = DiasSemanaSelected.weekday,
			};

			Output result = Ejecutar.ProgramaScheduler(entrada);

			DateTime fechaFinal = new DateTime(2020, 2, 28, 14, 0, 0);
			string descripcionFinal = "Occurs the last weekday of every month at 2:00 pm starting on 01/01/2020";

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}
	}
}
