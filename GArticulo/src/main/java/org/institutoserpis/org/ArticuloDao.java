package org.institutoserpis.org;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.Scanner;

/*
GArticulo
0 Salir
1 Nuevo	
		Nombre
		Precio		--> Insert
		Categoria
2 Modificar
		Todos 		--> update
3 Eliminar
		Id 			--> delete -...-  wher
4 Consultar
		Id			--> select where
5 Listar Todos 
	

*/
public class ArticuloDao {

	public static void main(String[] args) throws SQLException {
		Scanner scanner = new Scanner(System.in);
		int opcion;
		boolean salir = false;
		Connection connection = DriverManager.getConnection("jdbc:mysql://localhost/dbprueba", "root", "SISTEMAS");
		do {
			System.out.println("***SELECCIONE UNA DE LAS SIGUIENTES OPCIONES***");
			System.out.println("1). Nuevo");
			System.out.println("2). Modificar");
			System.out.println("3). Eliminar");
			System.out.println("4). Consultar");
			System.out.println("5). Listar Todos");
			System.out.println("0). Salir");

			opcion = scanner.nextInt();

			switch (opcion) {
			case 0:
				salir = true;
				break;

			case 1:
				opcion_nuevo(connection);
				break;

			case 2:
				opcion_modificar(connection);
				break;

			case 3:
				opcion_eliminar(connection);
				break;

			case 4:
				opcion_consultar(connection);
				break;

			case 5:

				opcion_listar(connection);

				break;

			default:
				break;
			}

		} while (salir == false);
		connection.close();
		System.out.println("La conexion con la Base de Datos ha sido finalizada");

	}

	// CASE 1
	private static void opcion_nuevo(Connection connection) throws SQLException {
		Scanner scanner = new Scanner(System.in);
		System.out.println("Introduzca el Nombre");
		String nombreArticulo = scanner.nextLine();
		System.out.println("Introduzca la Categoria");
		int categoriaArticulo = scanner.nextInt();
		System.out.println("Introduzca el Precio");
		int precioArticulo = scanner.nextInt();

		PreparedStatement preparedStatement = connection
				.prepareStatement("INSERT INTO articulo (nombre,categoria,precio) VALUES (?,?,?) ");

		preparedStatement.setObject(1, nombreArticulo);
		preparedStatement.setObject(2, categoriaArticulo);
		preparedStatement.setObject(3, precioArticulo);
		int resultSet = preparedStatement.executeUpdate();

		System.out.println("");
		System.out.println("");
		System.out.println("¿Desea añadir algun articulo más?");
		System.out.println("1) Continuar ");
		System.out.println("2) Volver ");

		// boolean salir = false;
		// int opcion;
		// opcion = scanner.nextInt();
		// do {
		// switch (opcion) {
		// case 1:
		//
		// break;
		// case 2:
		// salir = true;
		// break;
		// default:
		// break;
		// }
		// }while(salir == false);

	}

	// CASE 2
	private static void opcion_modificar(Connection connection) throws SQLException {
		Scanner scanner = new Scanner(System.in);
		PreparedStatement preparedStatement = connection
				.prepareStatement("Update articulo SET nombre=?, precio=?, categoria=? WHERE id = ?");
		System.out.println("Introduzca el ID que desea Modificar");

		preparedStatement.setObject(4, Integer.parseInt(scanner.nextLine()));
		System.out.println("Introduzca el nombre deseado");
		preparedStatement.setObject(1, scanner.nextLine());
		System.out.println("Introduzca el precio deseado");
		preparedStatement.setObject(2, scanner.nextLine());
		System.out.println("Introduzca la categoria deseada");
		int modificarCategoria = scanner.nextInt();
		preparedStatement.setObject(3, modificarCategoria);

		//
		// preparedStatement.setObject(1, modificarNombre);
		// preparedStatement.setObject(2, modificarPrecio);
		// preparedStatement.setObject(3, modificarCategoria);

		preparedStatement.executeUpdate();

		// System.out.println("SELECCIONE UN ID PARA MODIFICAR: ");
		// preparedStatement.setObject(4, Integer.parseInt(sc.nextLi5ne()));
		// System.out.println("INTRODUZCA EL NOMBRE: ");
		// preparedStatement.setObject(1, sc.nextLine());
		// System.out.println("INTRODUZCA EL PRECIO: ");
		// preparedStatement.setObject(2, Integer.parseInt(sc.nextLine()));
		// System.out.println("INTRODUZCA EL CATEGORIA: ");
		// preparedStatement.setObject(3, Integer.parseInt(sc.nextLine()));
		// int rowsUpdated = preparedStatement.executeUpdate();
	}

	// CASE 3
	private static void opcion_eliminar(Connection connection) throws SQLException {
		Scanner scanner = new Scanner(System.in);
		System.out.println("Introduzca el ID que desea Eliminar");
		int eliminarArticulo = scanner.nextInt();
		PreparedStatement preparedStatement = connection.prepareStatement("DELETE FROM articulo WHERE id = ?");
		preparedStatement.setObject(1, eliminarArticulo);
		preparedStatement.executeUpdate();
	}

	// CASE 4
	private static void opcion_consultar(Connection connection) throws SQLException {
		Scanner scanner = new Scanner(System.in);
		System.out.println("Introduzca el ID que desea Consultar");

		int consultaArticulo = scanner.nextInt();
		PreparedStatement preparedStatement = connection.prepareStatement("SELECT * FROM articulo WHERE id = ?");

		preparedStatement.setObject(1, consultaArticulo);

		ResultSet resultSet = preparedStatement.executeQuery();
		System.out.printf("%5s %-30s %10s %9s\n", "id", "nombre", "precio", "categoria");
		while (resultSet.next()) {
			System.out.printf("%5s %-30s %10s %9s\n", resultSet.getObject("id"), resultSet.getObject("nombre"),
					resultSet.getObject("precio"), resultSet.getObject("categoria"));
		}
	}

	// CASE 5
	private static void opcion_listar(Connection connection) throws SQLException {
		PreparedStatement preparedStatement = connection.prepareStatement("SELECT * FROM articulo WHERE id > ?");
		preparedStatement.setObject(1, Long.parseLong("5"));
		ResultSet resultSet = preparedStatement.executeQuery();
		System.out.printf("%5s %-30s %10s %9s\n", "id", "nombre", "precio", "categoria");
		while (resultSet.next()) {
			System.out.printf("%5s %-30s %10s %9s\n", resultSet.getObject("id"), resultSet.getObject("nombre"),
					resultSet.getObject("precio"), resultSet.getObject("categoria"));
		}
	}

}
