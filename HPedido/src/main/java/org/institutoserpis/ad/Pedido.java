package org.institutoserpis.ad;

import java.math.BigDecimal;
import java.util.ArrayList;
import java.util.List;

import javax.persistence.CascadeType;
import javax.persistence.Entity;
import javax.persistence.GeneratedValue;
import javax.persistence.GenerationType;
import javax.persistence.Id;
import javax.persistence.JoinColumn;
import javax.persistence.ManyToOne;
import javax.persistence.*;;

@Entity(name = "Pedido")

public class Pedido {
	
	
	@Id
	@GeneratedValue
	private Long id;
	@OneToMany(mappedBy = "pedido", cascade = CascadeType.ALL, orphanRemoval = true)
	private List<PedidoLinea> pedidoLineas = new ArrayList<>();
	
	@ManyToOne
	@JoinColumn (name="cliente")
	private Cliente cliente;
	private String fecha;
	private BigDecimal importe;

	public Cliente getCliente() {
		return cliente;
	}

	public void setCliente(Cliente cliente) {
		this.cliente = cliente;
	}

	public String getFecha() {
		return fecha;
	}

	public void setFecha(String fecha) {
		this.fecha = fecha;
	}

	public BigDecimal getImporte() {
		return importe;
	}

	public void setImporte(BigDecimal importe) {
		this.importe = importe;
	}
	public void addPedidoLinea(PedidoLinea pedidoLinea){
		pedidoLineas.add(pedidoLinea);
		pedidoLinea.setPedido(this);
	}
	public void removePedidoLinea(PedidoLinea pedidoLinea){
		pedidoLineas.remove(pedidoLinea);
		pedidoLinea.setPedido(null);
		}
}
