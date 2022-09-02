using System.Globalization;

DateTime fecha = new DateTime(2020, 1, 31, 11, 11, 11);
fecha = fecha.AddMonths(1);

//DateTime start = new DateTime(2010, 10, 10, 10, 10, 10);
//fecha = fecha.Date + start.TimeOfDay;

Console.WriteLine(fecha.ToString($"dd/MM/yyyy h:mm:ss tt")+fecha.DayOfWeek);
