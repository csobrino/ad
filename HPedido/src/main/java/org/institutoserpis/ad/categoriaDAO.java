package org.institutoserpis.ad;

import java.util.List;

import javax.persistence.EntityManager;
import javax.persistence.EntityManagerFactory;
import javax.persistence.Persistence;

public class categoriaDAO {
		
	
	public static void main(String[] args) {
		EntityManagerFactory entityManagerFactory = Persistence.createEntityManagerFactory("org.institutoserpis.ad.hpedido");
		EntityManager entityManager = entityManagerFactory.createEntityManager();
		entityManager.getTransaction().begin();
		
		 List<Categoria> categorias = entityManager.createQuery("from Categoria", Categoria.class).getResultList();
		
		entityManager.getTransaction().commit();
		entityManager.close();
		
	
	
	
	
	
	}

}
