package org.institutoserpis.ad;

import java.awt.Menu;
import java.util.Scanner;

public class MainActivity {

	public static void main(String[] args) {
		String optionSelected;
		Scanner sc = new Scanner(System.in);
		System.out.println("_________________________________");
		System.out.println("            HPedido            ");
		System.out.println("_________________________________");

		System.out.println("1) Menú Articulo");
		System.out.println("2) Menú Clientes");
		System.out.println("3) Menú Categoria");
		System.out.println("_________________________________");

		optionSelected = sc.nextLine();

		switch (optionSelected) {
		case "1":
				menuArticulo();
			break;

		case "2":
				menuCliente();

			break;

		case "3":
			menuCategoria();
			break;

		default:
			break;
		}
	}

	public static void menuArticulo() {
		String optionSelected;
		Scanner sc = new Scanner(System.in);

		System.out.println("_________________________________");
		System.out.println("          Menú Articulo");
		System.out.println("_________________________________");
		Menus.menu();
		
		optionSelected = sc.nextLine();

		switch (optionSelected) {
		case "1":

			break;

		case "2":

			break;

		case "3":

			break;

		case "0":
			main(null);
			break;

			
		default:
			break;
		}

	}
	
	public static void menuCliente() {

		String optionSelected;
		Scanner sc = new Scanner(System.in);

		System.out.println("_________________________________");
		System.out.println("          Menú Clientes");
		System.out.println("_________________________________");
		Menus.menu();
		
		optionSelected = sc.nextLine();

		switch (optionSelected) {
		case "1":

			break;

		case "2":

			break;

		case "3":

			break;

		case "0":
			main(null);
			break;

			
		default:
			break;
		}

	}
	public static void menuCategoria() {

		String optionSelected;
		Scanner sc = new Scanner(System.in);

		System.out.println("_________________________________");
		System.out.println("          Menú Categoria");
		System.out.println("_________________________________");
		Menus.menu();
		
		optionSelected = sc.nextLine();

		switch (optionSelected) {
		case "1":

			break;

		case "2":

			break;

		case "3":

			break;

		case "0":
			main(null);
			break;

			
		default:
			break;
		}

	}

}
