package org.institutoserpis.ad;

import java.math.BigDecimal;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;


@Entity (name="PedidoLinea")
public class PedidoLinea {
	
	@Id
	@GeneratedValue
	private Long id;
	private Pedido pedido;
	private Articulo articulo;
	private BigDecimal precio;
	private BigDecimal unidades;
	private BigDecimal importe;
	
	
	public Long getId() {
		return id;
	}
	public void setId(Long id) {
		this.id = id;
	}
	public Pedido getPedido() {
		return pedido;
	}
	public void setPedido(Pedido pedido) {
		this.pedido = pedido;
	}
	public Articulo getArticulo() {
		return articulo;
	}
	public void setArticulo(Articulo articulo) {
		this.articulo = articulo;
	}
	public BigDecimal getPrecio() {
		return precio;
	}
	public void setPrecio(BigDecimal precio) {
		this.precio = precio;
	}
	public BigDecimal getUnidades() {
		return unidades;
	}
	public void setUnidades(BigDecimal unidades) {
		this.unidades = unidades;
	}
	public BigDecimal getImporte() {
		return importe;
	}
	public void setImporte(BigDecimal importe) {
		this.importe = importe;
	}

	

}
