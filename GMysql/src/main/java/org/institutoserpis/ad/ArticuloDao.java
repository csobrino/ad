
package org.institutoserpis.ad;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.PreparedStatement;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class ArticuloDao {

	public static void main(String[] args) throws SQLException {
		Connection connection = DriverManager.getConnection(
			"jdbc:mysql://localhost/dbprueba", "root", "SISTEMAS");
		PreparedStatement preparedStatement = connection.prepareStatement("select * from articulo where id > ?");
		preparedStatement.setObject(1,Long.parseLong("5"));
		ResultSet resultSet = preparedStatement.executeQuery();
			
//		Statement statement = connection.createStatement();
//		ResultSet resultSet = statement.executeQuery("select * from articulo");
		System.out.printf("%5s %-30s %10s %9s\n", "id", "nombre", "precio", "categoria");
		while (resultSet.next()) {
			System.out.printf("%5s %-30s %10s %9s\n", 
					resultSet.getObject("id"), 
					resultSet.getObject("nombre"),
					resultSet.getObject("precio"),
					resultSet.getObject("categoria")
			);
		}
		preparedStatement.close();
		connection.close();
		System.out.println("fin");
	}

}