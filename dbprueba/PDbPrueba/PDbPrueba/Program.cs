using System;
using System.Data;
using MySql.Data.MySqlClient;


namespace PdbPrueba
{
	class MainClass
	{
		public static void Main (string[] args)
		{



			String valor,id;

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

				Console.Write ("0) Salir" + "\n"+ 
				               "1) Nuevo" + "\n"+
				               "2) Editar" +"\n"+
				               "3) Eliminar" +"\n"+
				               "4º) Listar Todos" +"\n");

				switch (Console.Read ()) {
				case '0': // CERRAR CONEXION.
					Console.Clear ();
					Console.Write ("\n" + "La conexion ha finalizado");
			
					dbConnection.Close ();
					dbConnection = null;
					break;



				case '1': //NUEVA ENTRADA PARA LA BASE DE DATOS (ID AUTOINCREMENT).
					Console.Clear();
					Console.Write ("Seleccionó Nuevo"+"\n");


					dbCommand.CommandText = "insert into categoria (nombre) values (@nombre)";
					dbDataParameter.ParameterName = "nombre";


					Console.Write("Porfavor Introduzca su nombre" + "\n");
					valor = Console.ReadLine();


					dbDataParameter.Value = valor;
					dbCommand.Parameters.Add (dbDataParameter);
					dbCommand.ExecuteNonQuery ();
					dbCommand.Dispose(); //Cierra la variable (recomendado usar siempre)


					break;

				case '2': // EDITAR CAMPO DE TABLA MEDIANTE UPDATE (SQL).
					Console.Clear ();
					Console.Write ("Editar");
					Console.WriteLine("Seleccione ID a modificar");
					id = Console.ReadLine();
					dbCommand.CommandText=("update categoria set nombre=(@nuevo) where id='"+id+"'");

					dbDataParameter.ParameterName = "nuevo";
					Console.Write("Porfavor Introduzca su nombre" + "\n");
					valor = Console.ReadLine();

					dbDataParameter.Value = valor;
					dbCommand.Parameters.Add (dbDataParameter);
					dbCommand.ExecuteNonQuery ();
					dbCommand.Dispose(); //Cierra la variable




				// Continuar lógica y extraer métodos //
					break;

				case '3': //ELIMINAR MEDIANTE INTRODUCCION DE ID A ELEGIR.
					Console.Write ("Eliminar");
					Console.WriteLine("Introducir un ID");
					id = Console.ReadLine();
					dbCommand.CommandText =("delete from categoria where id='" +id+ "'");
					dbCommand.ExecuteNonQuery();
					dbCommand.Dispose(); //Cierra la variable
					break;


				case '4': //LISTAR TODOS LOS CAMPOS DE LA TABLA.
					Console.Clear ();
					Console.Write ( "----------------------------"+ "\n"+"Seleccionó Listar" +"\n" + "----------------------------"+ "\n");
					dbCommand.CommandText = "SELECT * FROM categoria";
					IDataReader dataReader = dbCommand.ExecuteReader ();				
					while (dataReader.Read()) {
						Console.WriteLine ("Id" + dataReader ["id"] + "\t Nombre: " + dataReader ["nombre"] +"\n");
					}
					dataReader.Close ();
					dbCommand.Dispose(); //Cierra la variable
					break;
				}

			} while(dbConnection != null);
		}

			//operaciones...


		}
	}

