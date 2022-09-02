using EjercicioScheduler.Enums;
using EjercicioScheduler.ProgramaScheduler;

namespace EjercicioScheduler
{
	public static class Ejecutar
	{
		public static Output ProgramaScheduler(Input VariablesInput)
		{
			ExcepcionesPersonalizadas.TodasLasExcepciones(VariablesInput);

			switch (VariablesInput.TipoHorario)
			{
				case TiposHorarioFecha.Once:

					ExcepcionesPersonalizadas.ExcepcionesOnce(VariablesInput);
					Once objetoOnce = new(VariablesInput);

					return HabemusProgram(objetoOnce, VariablesInput);

				case TiposHorarioFecha.Recurring:

					ExcepcionesPersonalizadas.ExcepcionesRecurring(VariablesInput);
					Recurring objetoRecurring = new(VariablesInput);

					return HabemusProgram(objetoRecurring, VariablesInput);

				default:
					throw new NotImplementedException("No ha incorporado un valor de Tipo Horario válido." +
														" Seleccione tipo Once o Recurring");
			}

			Output HabemusProgram(ITiposHorario TipoOnceORecurring, Input input)
			{
				input = CamposEnBlanco.InputCorregido(input);

				Output output = new()
				{
					Description = TipoOnceORecurring.Descripcion(),
					FechaFinal = TipoOnceORecurring.FechaFinal()
				};
				ExcepcionesPersonalizadas.ExcepcionesAlAcabarPrograma(input, output.FechaFinal);

				input.CurrentDate = TipoOnceORecurring.FechaFinal();

				return output;
			}
		}
	}
}