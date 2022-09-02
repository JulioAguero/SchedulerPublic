using System.Globalization;
using EjercicioScheduler.ProgramaScheduler;

namespace EjercicioScheduler
{
	public class Once : ITiposHorario
	{
		public Input Variables { get; set; }
		public Once(Input variablesInput)
		{
			Variables = variablesInput;
		}

		public string Descripcion()
		{
			DateTime fechaDada = (DateTime)Variables.FechaDada;

			return $"Occurs once. Schedule will be used on {fechaDada:dd/MM/yyyy} at {fechaDada.ToString("h:mm tt", CultureInfo.InvariantCulture).ToLower()}" +
				$" starting on {Variables.StartDate?.ToString("dd/MM/yyyy")}";
		}
			
		public DateTime FechaFinal()
		{
			return (DateTime)Variables.FechaDada;
		}
	}
}
