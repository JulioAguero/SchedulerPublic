using EjercicioScheduler;
using EjercicioScheduler.Enums;
using EjercicioScheduler.ProgramaScheduler;
using FluentAssertions;
using Xunit;

namespace Testing.TestsScheduler.Once
{
	public class Once
	{
		[Fact]
		public void FechaValue_Null_Excepcion()
		{
			Input entrada = new()
			{
				TipoHorario = TiposHorarioFecha.Once,
				FechaDada = null,
				StartDate = new DateTime(2020, 1, 1)
			};
			Assert.Throws<ExceptionFechaDadaNull>(() => Ejecutar.ProgramaScheduler(entrada));
		}

		[Fact]
		public void StartDate_Null_Exception()
		{
			Input entrada = new()
			{
				FechaDada = new DateTime(2020, 1, 4, 00, 00, 00),
				TipoHorario = TiposHorarioFecha.Once,
				StartDate = null,
			};
			Assert.Throws<ExceptionStartDateNull>(() => Ejecutar.ProgramaScheduler(entrada));
		}

		[Fact]
		public void StartDate_Greater_EndDate_Exception()
		{
			Input entrada = new()
			{
				FechaDada = new DateTime(2020, 1, 1),
				TipoHorario = TiposHorarioFecha.Once,
				StartDate = new DateTime(2020, 1, 9),
				EndDate = new DateTime(2020, 1, 1)
			};
			Assert.Throws<ExceptionIncoherentLimits>(() => Ejecutar.ProgramaScheduler(entrada));
		}

		[Fact]
		public void FechaFinal_Greater_End_Exception()
		{
			Input entrada = new()
			{
				TipoHorario = TiposHorarioFecha.Once,
				FechaDada = new DateTime(2020, 1, 8, 14, 0, 0),
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2020, 1, 2)
			};
			Assert.Throws<ExceptionIncoherentLimitsOnce>(() => Ejecutar.ProgramaScheduler(entrada));
		}

		[Fact]
		public void FechaValue_Lower_Start_Exception()
		{
			Input entrada = new()
			{
				FechaDada = new DateTime(2020, 1, 1),
				TipoHorario = TiposHorarioFecha.Once,
				StartDate = new DateTime(2020, 1, 2),
				EndDate = new DateTime(2020, 1, 3)
			};
			Assert.Throws<ExceptionIncoherentLimitsOnce>(() => Ejecutar.ProgramaScheduler(entrada));
		}

		[Fact]
		public void FechaDada_Hour_Lower_Start_Exception()
		{
			Input entrada = new()
			{
				TipoHorario = TiposHorarioFecha.Once,
				FechaDada = new DateTime(2020, 1, 1),
				StartDate = new DateTime(2020, 1, 1, 04, 00, 00),
				EndDate = new DateTime(2020, 1, 8),
			};
			Assert.Throws<ExceptionIncoherentLimitsOnce>(() => Ejecutar.ProgramaScheduler(entrada));
		}

		[Fact]
		public void FechaDada_Hour_Greater_End_Exception()
		{
			Input entrada = new()
			{
				CurrentDate = null,
				TipoHorario = TiposHorarioFecha.Once,
				FechaDada = new DateTime(2020, 1, 8, 04, 00, 00),
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2020, 1, 8),
			};
			Assert.Throws<ExceptionIncoherentLimitsOnce>(() => Ejecutar.ProgramaScheduler(entrada));
		}

		[Fact]
		public void Cheking_CurrentValue_EndDate_Not_Given()
		{
			Input entrada = new()
			{
				TipoHorario = TiposHorarioFecha.Once,
				FechaDada = new DateTime(2020, 1, 8, 14, 0, 0),
				StartDate = new DateTime(2020, 1, 1)
			};

			DateTime fechaFinal = new DateTime(2020, 1, 8, 14, 0, 0);
			string descripcionFinal = "Occurs once. Schedule will be used on 08/01/2020 at 2:00 pm starting on 01/01/2020";

			var result = Ejecutar.ProgramaScheduler(entrada);

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);

			result = Ejecutar.ProgramaScheduler(entrada);

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_RazonablesValues()
		{
			Input entrada = new()
			{
				TipoHorario = TiposHorarioFecha.Once,
				FechaDada = new DateTime(2020, 1, 8, 14, 0, 0),
				StartDate = new DateTime(2020, 1, 1)
			};

			DateTime fechaFinal = new DateTime(2020, 1, 8, 14, 0, 0);
			string descripcionFinal = "Occurs once. Schedule will be used on 08/01/2020 at 2:00 pm starting on 01/01/2020";

			var result = Ejecutar.ProgramaScheduler(entrada);

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);

			result = Ejecutar.ProgramaScheduler(entrada);

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_FechaDada_Equals_Start()
		{
			Input entrada = new()
			{
				TipoHorario = TiposHorarioFecha.Once,
				FechaDada = new DateTime(2020, 1, 1),
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2020, 1, 8),
			};

			DateTime fechaFinal = new DateTime(2020, 1, 1);
			string descripcionFinal = "Occurs once. Schedule will be used on 01/01/2020 at 12:00 am starting on 01/01/2020";

			var result = Ejecutar.ProgramaScheduler(entrada);

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_FechaDada_Equals_End()
		{
			Input entrada = new()
			{
				CurrentDate = null,
				TipoHorario = TiposHorarioFecha.Once,
				FechaDada = new DateTime(2020, 1, 8),
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2020, 1, 8),
			};

			DateTime fechaFinal = new DateTime(2020, 1, 8);
			string descripcionFinal = "Occurs once. Schedule will be used on 08/01/2020 at 12:00 am starting on 01/01/2020";

			var result = Ejecutar.ProgramaScheduler(entrada);

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_Recurring_SomeHoursADay_Values_No_Influence()
		{
			Input entrada = new()
			{
				CurrentDate = null,
				TipoHorario = TiposHorarioFecha.Once,
				FechaDada = new DateTime(2020, 1, 8),

				DaysAvailableWeek = new DayOfWeek[] { DayOfWeek.Monday },
				TipoTimeSteps = TipoTimeSteps.Yearly,
				TimeSteps = 1,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2020, 1, 8),
				TipoHorarioHoras = TiposHorarioHoras.SomeHoursADay,
				TipoHourSteps = HourMinSecSelected.Hour,
				ValueHourSteps = 2,
				StartHourDay = new DateTime(2020, 1, 1, 12, 00, 00),
				EndHourDay = new DateTime(2020, 1, 1, 00, 00, 00)
			};

			DateTime fechaFinal = new DateTime(2020, 1, 8);
			string descripcionFinal = "Occurs once. Schedule will be used on 08/01/2020 at 12:00 am starting on 01/01/2020";

			var result = Ejecutar.ProgramaScheduler(entrada);

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_Recurring_OnceADay_Values_No_Influence()
		{
			Input entrada = new()
			{
				CurrentDate = null,
				TipoHorario = TiposHorarioFecha.Once,
				FechaDada = new DateTime(2020, 1, 8),

				DaysAvailableWeek = new DayOfWeek[] { DayOfWeek.Monday },
				TipoTimeSteps = TipoTimeSteps.Yearly,
				TimeSteps = 1,
				StartDate = new DateTime(2020, 1, 1),
				EndDate = new DateTime(2020, 1, 8),
				TipoHorarioHoras = TiposHorarioHoras.OnceHour,
				OnceHour = new DateTime(2019, 1, 1, 00, 00, 00),
			};

			DateTime fechaFinal = new DateTime(2020, 1, 8);
			string descripcionFinal = "Occurs once. Schedule will be used on 08/01/2020 at 12:00 am starting on 01/01/2020";

			var result = Ejecutar.ProgramaScheduler(entrada);

			result.FechaFinal.Should().Be(fechaFinal);
			result.Description.Should().Be(descripcionFinal);
		}

		[Fact]
		public void Checking_Recurring_Exceptions_Not_Launch()
		{
			Input entrada = new()
			{
				FechaDada = new DateTime(2020, 1, 2),
				StartDate = new DateTime(2020, 1, 1),
				TipoHorario = TiposHorarioFecha.Once,
				ValueHourSteps = 0,
				StartHourDay = new DateTime(2020, 1, 1, 12, 00, 00),
				EndHourDay = new DateTime(2020, 1, 1, 00, 00, 00),
				TipoHourSteps = 0,

			};

			DateTime fechaFinal = new DateTime(2020, 1, 2);
			string descripcion = "Occurs once. Schedule will be used on 02/01/2020 at 12:00 am starting on 01/01/2020";

			Output salida = Ejecutar.ProgramaScheduler(entrada);

			salida.FechaFinal.Should().Be(fechaFinal);
			salida.Description.Should().Be(descripcion);

		}
	}
}