using System;
using System.Data;
using MySql.Data.MySqlClient;


namespace PdbPrueba
{
	class MainClass
	{
		public static void Main (string[] args)
		{



			String valor;

			Console.WriteLine ("Probando Acceso a dbprueba");



			//MySqlConnection mySqlConnection = new MySqlConnection (
			IDbConnection dbConnection = new MySqlConnection (	
			"Database=dbprueba;User Id=root;Password=SISTEMAS"
				);
			dbConnection.Open ();
			IDbCommand dbCommand = dbConnection.CreateCommand ();
			IDbDataParameter dbDataParameter = dbCommand.CreateParameter ();
		//mySqlConnection.CreateCommand().


			do {

				Console.Write ("0) Salir" + "\n");
				Console.Write ("1) Nuevo" + "\n");
				Console.Write ("2) Editar" +"\n");
				Console.Write ("3) Eliminar" +"\n");
				Console.Write ("4º) Listar Todos" +"\n");

				switch (Console.Read ()) {
				case '0':
					Console.Clear ();
					Console.Write ("\n" + "La conexion ha finalizado");
			
					dbConnection.Close ();
					dbConnection = null;
					break;



				case '1':
					Console.Clear();
					Console.Write ("Seleccionó Nuevo"+"\n");


					dbCommand.CommandText = "insert into categoria (nombre) values (@nombre)";
					dbDataParameter.ParameterName = "nombre";


					Console.Write("Porfavor Introduzca su nombre" + "\n");
					valor = Console.ReadLine();


					dbDataParameter.Value = valor;
					dbCommand.Parameters.Add (dbDataParameter);
					dbCommand.ExecuteNonQuery ();

				// Continuar lógica y extraer métodos //
					break;

				case '2':
					Console.Clear ();
					Console.Write ("Editar");

				// Continuar lógica y extraer métodos //
					break;

				case '3':
					Console.Write ("Eliminar");
				// Continuar lógica y extraer métodos //
					break;


				case '4':
					Console.Clear ();

					Console.Write ( "----------------------------"+ "\n"+"Seleccionó Listar" +"\n" + "----------------------------"+ "\n");
					dbCommand.CommandText = "SELECT * FROM categoria";
					IDataReader dataReader = dbCommand.ExecuteReader ();	


				
					while (dataReader.Read()) {
						Console.WriteLine ("Id" + dataReader ["id"] + "\t Nombre: " + dataReader ["nombre"] +"\n");
					}
					dataReader.Close ();

					break;
				}

			} while(dbConnection != null);
		}

			//operaciones...


		}
	}

